/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using iText.Commons;
using iText.Commons.Datastructures;
using iText.Commons.Utils;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Html;
using iText.Html2pdf.Logs;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.StyledXmlParser.Node;
using iText.StyledXmlParser.Node.Impl.Jsoup.Node;

namespace iText.Html2pdf.Attach.Impl {
    /// <summary>
    /// A
    /// <see cref="OutlineHandler"/>
    /// handles creating outlines for tags.
    /// </summary>
    /// <remarks>
    /// A
    /// <see cref="OutlineHandler"/>
    /// handles creating outlines for tags.
    /// <para />
    /// This class is not reusable and a new instance shall be created for every new conversion process.
    /// </remarks>
    public class OutlineHandler {
        /// <summary>The Constant DEFAULT_DESTINATION_PREFIX.</summary>
        private const String DEFAULT_DESTINATION_NAME_PREFIX = "pdfHTML-iText-outline-";

        /// <summary>The destination counter.</summary>
        /// <remarks>
        /// The destination counter.
        /// Counts the number of created the destinations with the same prefix in name,
        /// to achieve the uniqueness of the destination names.
        /// </remarks>
        private IDictionary<String, int?> destCounter = new Dictionary<String, int?>();

        /// <summary>The current outline.</summary>
        private PdfOutline currentOutline;

        /// <summary>The destinations in process.</summary>
        private LinkedList<Tuple2<String, PdfDictionary>> destinationsInProcess = new LinkedList<Tuple2<String, PdfDictionary
            >>();

        /// <summary>The levels in process.</summary>
        private LinkedList<int> levelsInProcess = new LinkedList<int>();

        /// <summary>The tag priorities mapping.</summary>
        private IDictionary<String, int?> tagPrioritiesMapping = new Dictionary<String, int?>();

        /// <summary>The destination prefix.</summary>
        private String destinationNamePrefix = DEFAULT_DESTINATION_NAME_PREFIX;

        /// <summary>Creates an OutlineHandler with standard predefined mappings.</summary>
        /// <returns>the outline handler</returns>
        public static OutlineHandler CreateStandardHandler() {
            OutlineHandler handler = new OutlineHandler();
            handler.PutTagPriorityMapping(TagConstants.H1, 1);
            handler.PutTagPriorityMapping(TagConstants.H2, 2);
            handler.PutTagPriorityMapping(TagConstants.H3, 3);
            handler.PutTagPriorityMapping(TagConstants.H4, 4);
            handler.PutTagPriorityMapping(TagConstants.H5, 5);
            handler.PutTagPriorityMapping(TagConstants.H6, 6);
            return handler;
        }

        /// <summary>Put tag priority mapping.</summary>
        /// <param name="tagName">the tag name</param>
        /// <param name="priority">the priority</param>
        /// <returns>the outline handler</returns>
        public virtual OutlineHandler PutTagPriorityMapping(String tagName, int? priority) {
            tagPrioritiesMapping.Put(tagName, priority);
            return this;
        }

        /// <summary>Put all tag priority mappings.</summary>
        /// <param name="mappings">the mappings</param>
        /// <returns>the outline handler</returns>
        public virtual OutlineHandler PutAllTagPriorityMappings(IDictionary<String, int?> mappings) {
            tagPrioritiesMapping.AddAll(mappings);
            return this;
        }

        /// <summary>Gets the tag priority mapping.</summary>
        /// <param name="tagName">the tag name</param>
        /// <returns>the tag priority mapping</returns>
        public virtual int? GetTagPriorityMapping(String tagName) {
            return tagPrioritiesMapping.Get(tagName);
        }

        /// <summary>Checks for tag priority mapping.</summary>
        /// <param name="tagName">the tag name</param>
        /// <returns>true, if the tag name is listed in the tag priorities mapping</returns>
        public virtual bool HasTagPriorityMapping(String tagName) {
            return tagPrioritiesMapping.ContainsKey(tagName);
        }

        /// <summary>
        /// Resets the current state so that this
        /// <see cref="OutlineHandler"/>
        /// is ready to process new document
        /// </summary>
        public virtual void Reset() {
            currentOutline = null;
            destinationsInProcess.Clear();
            levelsInProcess.Clear();
            destCounter.Clear();
        }

        /// <summary>Sets the destination name prefix.</summary>
        /// <remarks>
        /// Sets the destination name prefix.
        /// The destination name prefix serves as the prefix for the destination names created in the
        /// <see cref="GenerateUniqueDestinationName(iText.StyledXmlParser.Node.IElementNode)"/>
        /// method.
        /// </remarks>
        /// <param name="destinationNamePrefix">the destination name prefix</param>
        public virtual void SetDestinationNamePrefix(String destinationNamePrefix) {
            this.destinationNamePrefix = destinationNamePrefix;
        }

        /// <summary>Gets the destination name prefix.</summary>
        /// <remarks>
        /// Gets the destination name prefix.
        /// The destination name prefix serves as the prefix for the destination names created in the
        /// <see cref="GenerateUniqueDestinationName(iText.StyledXmlParser.Node.IElementNode)"/>
        /// method.
        /// </remarks>
        /// <returns>the destination name prefix</returns>
        public virtual String GetDestinationNamePrefix() {
            return destinationNamePrefix;
        }

        /// <summary>Generate the unique destination name.</summary>
        /// <remarks>
        /// Generate the unique destination name.
        /// The destination name is a unique identifier for the outline so it is generated for the outline
        /// in the
        /// <see cref="AddOutlineAndDestToDocument(iText.Html2pdf.Attach.ITagWorker, iText.StyledXmlParser.Node.IElementNode, iText.Html2pdf.Attach.ProcessorContext)
        ///     "/>
        /// method. You can override this method to set
        /// your own way to generate the destination names, to avoid the destination name conflicts when
        /// merging several PDF files created by html2pdf.
        /// </remarks>
        /// <param name="element">the element</param>
        /// <returns>the unique destination name</returns>
        protected internal virtual String GenerateUniqueDestinationName(IElementNode element) {
            return GetUniqueID(destinationNamePrefix);
        }

        /// <summary>Generate the outline name.</summary>
        /// <remarks>
        /// Generate the outline name.
        /// This method is used in the
        /// <see cref="AddOutlineAndDestToDocument(iText.Html2pdf.Attach.ITagWorker, iText.StyledXmlParser.Node.IElementNode, iText.Html2pdf.Attach.ProcessorContext)
        ///     "/>
        /// method.
        /// You can override this method to set your own way to generate the outline names.
        /// </remarks>
        /// <param name="element">the element</param>
        /// <returns>the unique destination name</returns>
        protected internal virtual String GenerateOutlineName(IElementNode element) {
            String tagName = element.Name();
            String content = ((JsoupElementNode)element).Text();
            if (String.IsNullOrEmpty(content)) {
                content = GetUniqueID(tagName);
            }
            return content;
        }

        /// <summary>Adds the outline and the destination.</summary>
        /// <remarks>
        /// Adds the outline and the destination.
        /// Adds the outline and its corresponding the destination to the PDF document
        /// if the priority mapping is set for the element.
        /// </remarks>
        /// <param name="tagWorker">the tag worker</param>
        /// <param name="element">the element</param>
        /// <param name="context">the processor context</param>
        /// <returns>the outline handler</returns>
        internal virtual OutlineHandler AddOutlineAndDestToDocument(ITagWorker tagWorker, IElementNode element, ProcessorContext
             context) {
            String tagName = element.Name();
            if (null != tagWorker && HasTagPriorityMapping(tagName) && context.GetPdfDocument() != null) {
                int level = (int)GetTagPriorityMapping(tagName);
                if (null == currentOutline) {
                    currentOutline = context.GetPdfDocument().GetOutlines(false);
                }
                PdfOutline parent = currentOutline;
                while (!levelsInProcess.IsEmpty() && level <= levelsInProcess.JGetFirst()) {
                    parent = parent.GetParent();
                    levelsInProcess.JRemoveFirst();
                }
                PdfOutline outline = parent.AddOutline(GenerateOutlineName(element));
                String destination = GenerateUniqueDestinationName(element);
                PdfAction action = PdfAction.CreateGoTo(destination);
                outline.AddAction(action);
                destinationsInProcess.AddFirst(new Tuple2<String, PdfDictionary>(destination, action.GetPdfObject()));
                levelsInProcess.AddFirst(level);
                currentOutline = outline;
            }
            return this;
        }

        /// <summary>Sets the destination to element.</summary>
        /// <remarks>
        /// Sets the destination to element.
        /// Sets the destination previously created in the
        /// <see cref="AddOutlineAndDestToDocument(iText.Html2pdf.Attach.ITagWorker, iText.StyledXmlParser.Node.IElementNode, iText.Html2pdf.Attach.ProcessorContext)
        ///     "/>
        /// method
        /// to the tag worker element.
        /// </remarks>
        /// <param name="tagWorker">the tag worker</param>
        /// <param name="element">the element</param>
        /// <returns>the outline handler</returns>
        internal virtual OutlineHandler SetDestinationToElement(ITagWorker tagWorker, IElementNode element) {
            String tagName = element.Name();
            if (null != tagWorker && HasTagPriorityMapping(tagName) && destinationsInProcess.Count > 0) {
                Tuple2<String, PdfDictionary> content = destinationsInProcess.JRemoveFirst();
                if (tagWorker.GetElementResult() is IElement) {
                    tagWorker.GetElementResult().SetProperty(Property.DESTINATION, content);
                }
                else {
                    ILogger logger = ITextLogManager.GetLogger(typeof(OutlineHandler));
                    logger.LogWarning(MessageFormatUtil.Format(Html2PdfLogMessageConstant.NO_IPROPERTYCONTAINER_RESULT_FOR_THE_TAG
                        , tagName));
                }
            }
            return this;
        }

        /// <summary>Gets the unique ID.</summary>
        /// <remarks>
        /// Gets the unique ID.
        /// This method is used in the
        /// <see cref="GenerateUniqueDestinationName(iText.StyledXmlParser.Node.IElementNode)"/>
        /// method to generate the unique
        /// destination names and in the
        /// <see cref="GenerateOutlineName(iText.StyledXmlParser.Node.IElementNode)"/>
        /// method to generate the unique
        /// outline names. The
        /// <see cref="destCounter"/>
        /// map serves to achieve the uniqueness of an ID.
        /// </remarks>
        /// <param name="key">the key</param>
        /// <returns>the unique ID</returns>
        private String GetUniqueID(String key) {
            if (!destCounter.ContainsKey(key)) {
                destCounter.Put(key, 1);
            }
            int id = (int)destCounter.Get(key);
            destCounter.Put(key, id + 1);
            return key + id;
        }
    }
}

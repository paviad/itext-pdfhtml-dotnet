/*
    This file is part of the iText (R) project.
    Copyright (c) 1998-2017 iText Group NV
    Authors: iText Software.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS

    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
    http://itextpdf.com/terms-of-use/

    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.

    In accordance with Section 7(b) of the GNU Affero General Public License,
    a covered work must retain the producer line in every PDF that is created
    or manipulated using iText.

    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the iText software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving PDFs on the fly in a web application, shipping iText with a closed
    source product.

    For more information, please contact iText Software Corp. at this
    address: sales@itextpdf.com */
using System;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Util;
using iText.Html2pdf.Attach.Wrapelement;
using iText.Html2pdf.Html.Node;
using iText.Layout;
using iText.Layout.Element;

namespace iText.Html2pdf.Attach.Impl.Tags {
    public class TableTagWorker : ITagWorker {
        private TableWrapper tableWrapper;

        private Table table;

        private bool footer;

        private bool header;

        private ITagWorker parentTagWorker;

        private WaitingColgroupsHelper colgroupsHelper;

        public TableTagWorker(IElementNode element, ProcessorContext context) {
            tableWrapper = new TableWrapper();
            parentTagWorker = context.GetState().Empty() ? null : context.GetState().Top();
            if (parentTagWorker is iText.Html2pdf.Attach.Impl.Tags.TableTagWorker) {
                ((iText.Html2pdf.Attach.Impl.Tags.TableTagWorker)parentTagWorker).ApplyColStyles();
            }
            else {
                colgroupsHelper = new WaitingColgroupsHelper(element);
            }
        }

        public virtual void ProcessEnd(IElementNode element, ProcessorContext context) {
            table = tableWrapper.ToTable();
        }

        public virtual bool ProcessContent(String content, ProcessorContext context) {
            return parentTagWorker != null && parentTagWorker.ProcessContent(content, context);
        }

        public virtual bool ProcessTagChild(ITagWorker childTagWorker, ProcessorContext context) {
            if (childTagWorker is TrTagWorker) {
                TableRowWrapper wrapper = ((TrTagWorker)childTagWorker).GetTableRowWrapper();
                tableWrapper.NewRow();
                foreach (Cell cell in wrapper.GetCells()) {
                    tableWrapper.AddCell(cell);
                }
                return true;
            }
            else {
                if (childTagWorker is iText.Html2pdf.Attach.Impl.Tags.TableTagWorker) {
                    if (((iText.Html2pdf.Attach.Impl.Tags.TableTagWorker)childTagWorker).header) {
                        Table header = ((iText.Html2pdf.Attach.Impl.Tags.TableTagWorker)childTagWorker).tableWrapper.ToTable();
                        for (int i = 0; i < header.GetNumberOfRows(); i++) {
                            tableWrapper.NewHeaderRow();
                            for (int j = 0; j < header.GetNumberOfColumns(); j++) {
                                tableWrapper.AddHeaderCell(header.GetCell(i, j));
                            }
                        }
                        return true;
                    }
                    else {
                        if (((iText.Html2pdf.Attach.Impl.Tags.TableTagWorker)childTagWorker).footer) {
                            Table footer = ((iText.Html2pdf.Attach.Impl.Tags.TableTagWorker)childTagWorker).tableWrapper.ToTable();
                            for (int i = 0; i < footer.GetNumberOfRows(); i++) {
                                tableWrapper.NewFooterRow();
                                for (int j = 0; j < footer.GetNumberOfColumns(); j++) {
                                    tableWrapper.AddFooterCell(footer.GetCell(i, j));
                                }
                            }
                            return true;
                        }
                    }
                }
                else {
                    if (childTagWorker is ColgroupTagWorker) {
                        if (colgroupsHelper != null) {
                            colgroupsHelper.Add(((ColgroupTagWorker)childTagWorker).GetColgroup());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual IPropertyContainer GetElementResult() {
            return table;
        }

        public virtual void SetFooter() {
            footer = true;
        }

        public virtual void SetHeader() {
            header = true;
        }

        public virtual void ApplyColStyles() {
            if (colgroupsHelper != null) {
                colgroupsHelper.ApplyColStyles();
            }
        }
    }
}

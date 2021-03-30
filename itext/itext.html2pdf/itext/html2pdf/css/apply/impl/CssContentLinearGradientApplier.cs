/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
Authors: Bruno Lowagie, Paulo Soares, et al.

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
address: sales@itextpdf.com
*/
using System;
using System.Collections.Generic;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Css;
using iText.Html2pdf.Css.Apply;
using iText.Html2pdf.Css.Apply.Util;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Node;

namespace iText.Html2pdf.Css.Apply.Impl {
    /// <summary>
    /// <see cref="iText.Html2pdf.Css.Apply.ICssApplier"/>
    /// implementation for linear-gradient elements in content CSS property.
    /// </summary>
    public class CssContentLinearGradientApplier : ICssApplier {
        /// <summary>The default width of the div content in the points, and this will be 300 pixels.</summary>
        private const float DEFAULT_CONTENT_WIDTH_PT = 225;

        /// <summary>The default height of the div content in the points, and this will be 150 pixels.</summary>
        private const float DEFAULT_CONTENT_HEIGHT_PT = 112.5f;

        /* (non-Javadoc)
        * @see com.itextpdf.html2pdf.css.apply.ICssApplier#apply(com.itextpdf.html2pdf.attach.ProcessorContext, com.itextpdf.html2pdf.html.node.IStylesContainer, com.itextpdf.html2pdf.attach.ITagWorker)
        */
        public virtual void Apply(ProcessorContext context, IStylesContainer stylesContainer, ITagWorker tagWorker
            ) {
            IDictionary<String, String> cssProps = stylesContainer.GetStyles();
            IPropertyContainer container = tagWorker.GetElementResult();
            if (container != null) {
                if (container is Div) {
                    if (!cssProps.ContainsKey(CssConstants.WIDTH) || CssConstants.AUTO.Equals(cssProps.Get(CssConstants.WIDTH)
                        )) {
                        ((Div)container).SetWidth(DEFAULT_CONTENT_WIDTH_PT);
                    }
                    if (!cssProps.ContainsKey(CssConstants.HEIGHT) || CssConstants.AUTO.Equals(cssProps.Get(CssConstants.HEIGHT
                        ))) {
                        ((Div)container).SetHeight(DEFAULT_CONTENT_HEIGHT_PT);
                    }
                }
                WidthHeightApplierUtil.ApplyWidthHeight(cssProps, context, container);
                BackgroundApplierUtil.ApplyBackground(cssProps, context, container);
            }
        }
    }
}

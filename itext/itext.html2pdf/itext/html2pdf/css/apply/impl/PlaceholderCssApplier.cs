/*
This file is part of the iText (R) project.
Copyright (c) 1998-2023 Apryse Group NV
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
using iText.Forms.Form.Element;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Css.Apply;
using iText.Html2pdf.Css.Apply.Util;
using iText.Layout;
using iText.StyledXmlParser.Css.Pseudo;
using iText.StyledXmlParser.Node;

namespace iText.Html2pdf.Css.Apply.Impl {
    /// <summary>
    /// <see cref="iText.Html2pdf.Css.Apply.ICssApplier"/>
    /// implementation for input's placeholder.
    /// </summary>
    public class PlaceholderCssApplier : ICssApplier {
        public virtual void Apply(ProcessorContext context, IStylesContainer stylesContainer, ITagWorker tagWorker
            ) {
            IDictionary<String, String> cssStyles = stylesContainer.GetStyles();
            IStylesContainer parentToBeProcessed = (IStylesContainer)((CssPseudoElementNode)stylesContainer).ParentNode
                ();
            IPropertyContainer elementResult = context.GetState().Top().GetElementResult();
            if (elementResult is IPlaceholderable) {
                IPropertyContainer element = ((IPlaceholderable)elementResult).GetPlaceholder();
                FontStyleApplierUtil.ApplyFontStyles(cssStyles, context, parentToBeProcessed, element);
                BackgroundApplierUtil.ApplyBackground(cssStyles, context, element);
                OpacityApplierUtil.ApplyOpacity(cssStyles, context, element);
            }
        }
    }
}

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
using iText.Html2pdf.Css.W3c;
using iText.Html2pdf.Logs;
using iText.Test.Attributes;

namespace iText.Html2pdf.Css.W3c.Css_flexbox {
    //TODO DEVSIX-7554 change after column-gap is supported
    //TODO DEVSIX-7616 change after row-gap is supported
    //TODO DEVSIX-5164 change after align-content: space-around is supported
    //TODO DEVSIX-5163 change after more complex justify-content values are supported
    [LogMessage(Html2PdfLogMessageConstant.FLEX_PROPERTY_IS_NOT_SUPPORTED_YET, Count = 8)]
    public class FlexboxColumnRowGap003Test : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "flexbox-column-row-gap-003.html";
        }
    }
}

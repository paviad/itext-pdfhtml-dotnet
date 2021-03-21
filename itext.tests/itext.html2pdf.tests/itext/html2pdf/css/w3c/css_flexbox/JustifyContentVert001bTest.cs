/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
Authors: iText Software.

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
using iText.Test.Attributes;

namespace iText.Html2pdf.Css.W3c.Css_flexbox {
    // TODO DEVSIX-5003 support case when flex-direction is vertical
    //TODO DEVSIX-5163 support more complex justify-content values
    //TODO DEVSIX-5087 support floating for FlexContainerRenderer
    //This test should be verified in firefox as far as chrome doesn't support some justify-content values
    [LogMessage(iText.Html2pdf.LogMessageConstant.FLEX_PROPERTY_IS_NOT_SUPPORTED_YET, Count = 36)]
    public class JustifyContentVert001bTest : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "flexbox-justify-content-vert-001b.xhtml";
        }
    }
}

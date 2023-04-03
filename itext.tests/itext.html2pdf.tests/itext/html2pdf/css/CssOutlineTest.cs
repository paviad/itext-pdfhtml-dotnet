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
using iText.Html2pdf;

namespace iText.Html2pdf.Css {
    [NUnit.Framework.Category("IntegrationTest")]
    public class CssOutlineTest : ExtendedHtmlConversionITextTest {
        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/html2pdf/css/CssOutlineTest/";

        public static readonly String destinationFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/html2pdf/css/CssOutlineTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateDestinationFolder(destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void CssOutlineTest01() {
            ConvertToPdfAndCompare("cssOutline01", sourceFolder, destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void CssOutlineTest02() {
            ConvertToPdfAndCompare("cssOutline02", sourceFolder, destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void CssOutlineTest03() {
            ConvertToPdfAndCompare("cssOutline03", sourceFolder, destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void CssOutlineTest04() {
            ConvertToPdfAndCompare("cssOutline04", sourceFolder, destinationFolder, true);
        }

        [NUnit.Framework.Test]
        public virtual void CssOutlineTest05() {
            ConvertToPdfAndCompare("cssOutline05", sourceFolder, destinationFolder);
        }
    }
}

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
using iText.Html2pdf;

namespace iText.Html2pdf.Css.Selector.Item {
    [NUnit.Framework.Category("IntegrationTest")]
    public class NonStandardNodesMatchingTest : ExtendedHtmlConversionITextTest {
        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/html2pdf/css/selector/item/NonStandardNodesMatchingTest/";

        public static readonly String destinationFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/html2pdf/css/selector/item/NonStandardNodesMatchingTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateOrClearDestinationFolder(destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void PseudoElementMatchingTest01() {
            ConvertToPdfAndCompare("pseudoElementMatchingTest01", sourceFolder, destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void PseudoElementMatchingTest02() {
            ConvertToPdfAndCompare("pseudoElementMatchingTest02", sourceFolder, destinationFolder);
        }

        [NUnit.Framework.Test]
        public virtual void DocumentNodeMatchingTest01() {
            ConvertToPdfAndCompare("documentNodeMatchingTest01", sourceFolder, destinationFolder);
        }
    }
}

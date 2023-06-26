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

namespace iText.Html2pdf.Css.Multicol {
    [NUnit.Framework.Category("IntegrationTest")]
    public class ColumnCountTest : ExtendedHtmlConversionITextTest {
        public static readonly String SOURCE_FOLDER = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/html2pdf/css/multicol/ColumnCountTest/";

        public static readonly String DESTINATION_FOLDER = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/html2pdf/css/multicol/ColumnCountTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateOrClearDestinationFolder(DESTINATION_FOLDER);
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicArticleTest() {
            RunTest("basicArticleTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicDivTest() {
            RunTest("basicDivTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicDivWithImageTest() {
            RunTest("basicDivWithImageTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicPTest() {
            RunTest("basicPTest");
        }

        [NUnit.Framework.Test]
        public virtual void DiffElementsInsidePTest() {
            RunTest("diffElementsInsidePTest");
        }

        //TODO: DEVSIX-7591 support nested multicol layouting
        [NUnit.Framework.Test]
        public virtual void ConvertBasicFormTest() {
            RunTest("basicFormTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicUlTest() {
            RunTest("basicUlTest");
        }

        //TODO: DEVSIX-7591 Support nested multicol layouting
        [NUnit.Framework.Test]
        public virtual void ConvertBasicOlTest() {
            RunTest("basicOlTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicTableTest() {
            RunTest("basicTableTest");
        }

        [NUnit.Framework.Test]
        public virtual void TableColspanTest() {
            RunTest("tableColspanTest");
        }

        [NUnit.Framework.Test]
        public virtual void TableRowspanTest() {
            RunTest("tableRowspanTest");
        }

        [NUnit.Framework.Test]
        public virtual void TableColspanRowspanTest() {
            RunTest("tableColspanRowspanTest");
        }

        //TODO: DEVSIX-7591 Support nested multicol layouting
        [NUnit.Framework.Test]
        public virtual void ConvertBasicSectionTest() {
            RunTest("basicSectionTest");
        }

        //TODO: DEVSIX-7584 add multipage support
        [NUnit.Framework.Test]
        public virtual void ConvertBasicDivMultiPageDocumentsTest() {
            RunTest("basicDivMultiPageTest");
        }

        //TODO: DEVSIX-7584 add multipage support
        [NUnit.Framework.Test]
        public virtual void ConvertBasicFormMultiPageDocumentsTest() {
            RunTest("basicFormMultiPageTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicDisplayPropertyTest() {
            RunTest("basicDisplayPropertyTest");
        }

        //TODO: DEVSIX-7591 Support nested multicol layouting
        [NUnit.Framework.Test]
        public virtual void ConvertBasicDisplayPropertyWithNestedColumnsTest() {
            RunTest("basicDisplayPropertyWithNestedColumnsTest");
        }

        //TODO: DEVSIX-7556
        [NUnit.Framework.Test]
        public virtual void ConvertBasicFloatPropertyTest() {
            RunTest("basicFloatPropertyTest");
        }

        [NUnit.Framework.Test]
        public virtual void ConvertBasicFlexPropertyTest() {
            RunTest("basicFlexPropertyTest");
        }

        //TODO: DEVSIX-7587 adjust approximate height calculation
        [NUnit.Framework.Test]
        public virtual void ConvertImagesWithDifferentColValuesTest() {
            RunTest("imagesWithDifferentColValuesTest");
        }

        [NUnit.Framework.Test]
        public virtual void PaddingsMarginsBorderBackgrounds() {
            RunTest("paddingsMarginsBorderBackgrounds");
        }

        [NUnit.Framework.Test]
        public virtual void BorderOnlyTest() {
            RunTest("borderOnly");
        }

        [NUnit.Framework.Test]
        public virtual void PaddingOnlyTest() {
            RunTest("paddingOnly");
        }

        [NUnit.Framework.Test]
        public virtual void MarginOnlyTest() {
            RunTest("marginOnly");
        }

        [NUnit.Framework.Test]
        public virtual void SplitInnerParagraphBetweenColumns() {
            RunTest("splitInnerParagraphBetweenColumns");
        }

        [NUnit.Framework.Test]
        public virtual void SplitInnerParagraphWithoutMarginBetweenColumns() {
            RunTest("splitInnerParagraphWithoutMarginBetweenColumns");
        }

        [NUnit.Framework.Test]
        public virtual void SplitEmptyBlockElementsBetweenColumns() {
            RunTest("splitEmptyBlockElementsBetweenColumns");
        }

        [NUnit.Framework.Test]
        public virtual void SplitEmptyParagraphElementsBetweenColumns() {
            RunTest("splitEmptyParagraphElementsBetweenColumns");
        }

        [NUnit.Framework.Test]
        public virtual void SplitEmptyContinuousBlockElementBetweenColumns() {
            RunTest("splitEmptyContinuousBlockElementBetweenColumns");
        }

        [NUnit.Framework.Test]
        public virtual void BasicHiTest() {
            RunTest("basicHiTest");
        }

        [NUnit.Framework.Test]
        public virtual void BasicFooterHeaderTest() {
            RunTest("basicFooterHeaderTest");
        }

        [NUnit.Framework.Test]
        public virtual void BasicDlTest() {
            RunTest("basicDlTest");
        }

        [NUnit.Framework.Test]
        public virtual void BasicInlineElementsTest() {
            RunTest("basicInlineElementsTest");
        }

        [NUnit.Framework.Test]
        public virtual void BasicBlockquoteTest() {
            RunTest("basicBlockquoteTest");
        }

        private void RunTest(String testName) {
            ConvertToPdfAndCompare(testName, SOURCE_FOLDER, DESTINATION_FOLDER, false, new ConverterProperties().SetMulticolEnabled
                (true).SetBaseUri(SOURCE_FOLDER));
        }
    }
}

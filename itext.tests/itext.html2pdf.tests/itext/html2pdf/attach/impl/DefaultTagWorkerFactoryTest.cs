/*
This file is part of the iText (R) project.
Copyright (c) 1998-2022 iText Group NV
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
using iText.Html2pdf;
using iText.Html2pdf.Attach;
using iText.Layout;
using iText.StyledXmlParser.Node;
using iText.StyledXmlParser.Node.Impl.Jsoup.Node;
using iText.Test;

namespace iText.Html2pdf.Attach.Impl {
    [NUnit.Framework.Category("Unit test")]
    public class DefaultTagWorkerFactoryTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void CannotGetTagWorkerForCustomTagViaReflection() {
            ITagWorker tagWorker = new TestTagWorkerFactory().GetTagWorker(new JsoupElementNode(new iText.StyledXmlParser.Jsoup.Nodes.Element
                (iText.StyledXmlParser.Jsoup.Parser.Tag.ValueOf("custom-tag"), "")), new ProcessorContext(new ConverterProperties
                ()));
            NUnit.Framework.Assert.AreEqual(typeof(TestClass), tagWorker.GetType());
        }
    }

    internal class TestTagWorkerFactory : DefaultTagWorkerFactory {
        public TestTagWorkerFactory() {
            GetDefaultMapping().PutMapping("custom-tag", (lhs, rhs) => new TestClass());
        }
    }

    internal class TestClass : ITagWorker {
        public virtual void ProcessEnd(IElementNode element, ProcessorContext context) {
        }

        public virtual bool ProcessContent(String content, ProcessorContext context) {
            return false;
        }

        public virtual bool ProcessTagChild(ITagWorker childTagWorker, ProcessorContext context) {
            return false;
        }

        public virtual IPropertyContainer GetElementResult() {
            return null;
        }
    }
}

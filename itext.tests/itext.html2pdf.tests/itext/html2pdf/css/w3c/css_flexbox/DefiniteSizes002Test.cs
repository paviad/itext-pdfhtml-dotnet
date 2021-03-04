using System;
using iText.Html2pdf.Css.W3c;

namespace iText.Html2pdf.Css.W3c.Css_flexbox {
    //TODO DEVSIX-5040 layout: support justify-content and align-items
    //TODO DEVSIX-5137 support margin collapse
    public class DefiniteSizes002Test : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "flexbox-definite-sizes-002.html";
        }
    }
}

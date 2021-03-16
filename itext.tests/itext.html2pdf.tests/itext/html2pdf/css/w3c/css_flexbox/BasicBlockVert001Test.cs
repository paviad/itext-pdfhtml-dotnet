using System;
using iText.Html2pdf.Css.W3c;

namespace iText.Html2pdf.Css.W3c.Css_flexbox {
    //TODO DEVSIX-4443 improve segment frequency for dashed border
    //TODO DEVSIX-5096 support flex-direction: column
    public class BasicBlockVert001Test : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "flexbox-basic-block-vert-001.xhtml";
        }
    }
}

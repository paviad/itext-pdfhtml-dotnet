using System;
using iText.Html2pdf.Css.W3c;
using iText.Test.Attributes;

namespace iText.Html2pdf.Css.W3c.Css21.Positioning {
    [LogMessage(iText.IO.LogMessageConstant.TYPOGRAPHY_NOT_FOUND, Count = 8)]
    public class AbsoluteNonReplacedWidth019Test : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "absolute-non-replaced-width-019.xht";
        }
    }
}

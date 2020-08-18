using System;
using iText.Html2pdf.Css.W3c;

namespace iText.Html2pdf.Css.W3c.Css_backgrounds.Background_clip {
    // TODO DEVSIX-2105 background-clip is not supported
    // TODO DEVSIX-1457 background-position is not supported
    public class ClipPaddingBoxWithPositionTest : W3CCssTest {
        protected internal override String GetHtmlFileName() {
            return "clip-padding-box_with_position.html";
        }
    }
}

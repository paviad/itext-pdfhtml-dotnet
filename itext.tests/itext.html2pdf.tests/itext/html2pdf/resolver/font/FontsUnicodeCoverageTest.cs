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
using System.Collections.Generic;
using iText.Commons.Utils;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Test;

namespace iText.Html2pdf.Resolver.Font {
    [NUnit.Framework.Category("Unit test")]
    public class FontsUnicodeCoverageTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void CompareShippedFontsCoverageTest() {
            IList<int> actualUnicodeRange = new List<int>();
            IList<PdfFont> allFonts = ReadFontCollection();
            IList<int> actualUnicodeRanges = new List<int>();
            IList<int> actualUniCharsNumber = new List<int>();
            foreach (PdfFont font in allFonts) {
                bool gap = false;
                int unicodeCounter = 0;
                for (int unicode = 0; unicode < 0x30D40; ++unicode) {
                    if (gap && !actualUnicodeRange.IsEmpty()) {
                        actualUnicodeRanges.Add(actualUnicodeRange[0]);
                        actualUnicodeRanges.Add(actualUnicodeRange[actualUnicodeRange.Count - 1]);
                        actualUnicodeRange.Clear();
                    }
                    if (font.ContainsGlyph(unicode)) {
                        gap = false;
                        actualUnicodeRange.Add(unicode);
                        unicodeCounter = unicodeCounter + 1;
                    }
                    else {
                        gap = true;
                    }
                }
                actualUniCharsNumber.Add(unicodeCounter);
            }
            IList<int> expectedUnicodeRanges = JavaUtil.ArraysAsList(0, 0, 13, 13, 32, 126, 160, 887, 890, 895, 900, 906
                , 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957, 7960, 7965
                , 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064, 8116, 8118
                , 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305, 8308, 8334
                , 8336, 8348, 8352, 8382, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 8592, 8597, 8604, 8606, 8608
                , 8608, 8610, 8612, 8614, 8614, 8656, 8660, 8666, 8667, 8678, 8678, 8680, 8680, 8704, 8718, 8720, 8720
                , 8722, 8722, 8728, 8730, 8734, 8734, 8736, 8736, 8739, 8739, 8743, 8746, 8756, 8760, 8764, 8765, 8769
                , 8769, 8771, 8771, 8773, 8773, 8775, 8779, 8788, 8789, 8791, 8791, 8799, 8802, 8804, 8805, 8812, 8812
                , 8814, 8821, 8826, 8827, 8834, 8841, 8846, 8846, 8849, 8860, 8866, 8869, 8884, 8885, 8888, 8888, 8898
                , 8900, 8902, 8902, 8904, 8906, 8909, 8910, 8912, 8913, 8930, 8931, 8968, 8971, 8976, 8976, 8985, 8985
                , 8992, 8993, 9014, 9082, 9109, 9109, 9115, 9134, 9136, 9149, 9180, 9185, 9332, 9333, 9472, 9727, 9837
                , 9839, 10038, 10038, 10072, 10074, 10197, 10199, 10214, 10219, 10229, 10230, 10631, 10632, 10680, 10680
                , 10752, 10752, 10757, 10758, 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999
                , 43007, 43310, 43310, 43824, 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65371, 65371
                , 65373, 65373, 65532, 65533, 128636, 128639, 0, 0, 13, 13, 32, 126, 160, 887, 890, 895, 900, 906, 908
                , 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957, 7960, 7965, 7968
                , 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064, 8116, 8118, 8132
                , 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305, 8308, 8334, 8336
                , 8348, 8352, 8382, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 8592, 8597, 8604, 8606, 8608, 8608
                , 8610, 8612, 8614, 8614, 8656, 8660, 8666, 8667, 8678, 8678, 8680, 8680, 8704, 8718, 8720, 8720, 8722
                , 8722, 8728, 8730, 8734, 8734, 8736, 8736, 8739, 8739, 8743, 8746, 8756, 8760, 8764, 8765, 8769, 8769
                , 8771, 8771, 8773, 8773, 8775, 8779, 8788, 8789, 8791, 8791, 8799, 8802, 8804, 8805, 8812, 8812, 8814
                , 8821, 8826, 8827, 8834, 8841, 8846, 8846, 8849, 8860, 8866, 8869, 8884, 8885, 8888, 8888, 8898, 8900
                , 8902, 8902, 8904, 8906, 8909, 8910, 8912, 8913, 8930, 8931, 8968, 8971, 8976, 8976, 8985, 8985, 8992
                , 8993, 9014, 9082, 9109, 9109, 9115, 9134, 9136, 9149, 9180, 9185, 9332, 9333, 9472, 9727, 9837, 9839
                , 10038, 10038, 10072, 10074, 10197, 10199, 10214, 10219, 10229, 10230, 10631, 10632, 10680, 10680, 10752
                , 10752, 10757, 10758, 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007
                , 43310, 43310, 43824, 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65371, 65371, 65373
                , 65373, 65532, 65533, 128636, 128639, 0, 0, 13, 13, 32, 126, 160, 887, 890, 895, 900, 906, 908, 908, 
                910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957, 7960, 7965, 7968, 8005
                , 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064, 8116, 8118, 8132, 8134
                , 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305, 8308, 8334, 8336, 8348
                , 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 9676, 9676, 11360, 11391, 11744, 11844, 
                42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 43310, 43824, 43877, 64256, 64262, 65024
                , 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13, 32, 126, 160, 887, 890, 895, 900, 906
                , 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957, 7960, 7965
                , 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064, 8116, 8118
                , 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305, 8308, 8334
                , 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 9676, 9676, 11360, 11391, 11744
                , 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 43310, 43824, 43877, 64256, 64262
                , 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13, 32, 126, 160, 887, 890, 895, 900
                , 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957, 7960, 
                7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064, 8116, 
                8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305, 8308, 
                8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 9676, 9676, 11360, 11391
                , 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 43310, 43824, 43877, 64256
                , 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13, 32, 126, 160, 887, 890, 
                895, 900, 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675, 7957
                , 7960, 7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061, 8064
                , 8116, 8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294, 8305
                , 8308, 8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 9676, 9676, 11360
                , 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 43310, 43824, 43877
                , 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13, 32, 126, 160, 887
                , 890, 895, 900, 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 7669, 7675
                , 7957, 7960, 7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 8031, 8061
                , 8064, 8116, 8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 8292, 8294
                , 8305, 8308, 8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 9676, 9676
                , 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 43310, 43824
                , 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13, 32, 126, 
                160, 887, 890, 895, 900, 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304, 7424, 
                7669, 7675, 7957, 7960, 7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029, 8029, 
                8031, 8061, 8064, 8116, 8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190, 8192, 
                8292, 8294, 8305, 8308, 8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585, 8585, 
                9676, 9676, 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007, 43310, 
                43310, 43824, 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 0, 13, 13
                , 32, 126, 160, 887, 890, 895, 900, 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846, 7296, 7304
                , 7424, 7669, 7675, 7957, 7960, 7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027, 8027, 8029
                , 8029, 8031, 8061, 8064, 8116, 8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180, 8182, 8190
                , 8192, 8292, 8294, 8305, 8308, 8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580, 8580, 8585
                , 8585, 9676, 9676, 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 42999, 43007
                , 43310, 43310, 43824, 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532, 65533, 0, 
                0, 13, 13, 32, 126, 160, 887, 890, 895, 900, 906, 908, 908, 910, 929, 931, 993, 1008, 1327, 6832, 6846
                , 7296, 7304, 7424, 7669, 7675, 7957, 7960, 7965, 7968, 8005, 8008, 8013, 8016, 8023, 8025, 8025, 8027
                , 8027, 8029, 8029, 8031, 8061, 8064, 8116, 8118, 8132, 8134, 8147, 8150, 8155, 8157, 8175, 8178, 8180
                , 8182, 8190, 8192, 8292, 8294, 8305, 8308, 8334, 8336, 8348, 8352, 8383, 8432, 8432, 8448, 8543, 8580
                , 8580, 8585, 8585, 9676, 9676, 11360, 11391, 11744, 11844, 42560, 42655, 42752, 42926, 42928, 42935, 
                42999, 43007, 43310, 43310, 43824, 43877, 64256, 64262, 65024, 65024, 65056, 65071, 65279, 65279, 65532
                , 65533);
            IList<int> expectedUniCharsNumber = JavaUtil.ArraysAsList(3324, 3324, 2794, 2794, 2794, 2794, 2794, 2794, 
                2794, 2794);
            NUnit.Framework.Assert.AreEqual(expectedUniCharsNumber, actualUniCharsNumber, "The number of Unicode glyphs within shipped fonts has been changed"
                );
            NUnit.Framework.Assert.AreEqual(expectedUnicodeRanges, actualUnicodeRanges, "The Unicode ranges within fonts have been changed"
                );
        }

        private static IList<PdfFont> ReadFontCollection() {
            PdfFont font;
            IList<PdfFont> pdfFontList = new List<PdfFont>();
            foreach (String file in DefaultFontProvider.SHIPPED_FONT_NAMES) {
                font = PdfFontFactory.CreateFont(DefaultFontProvider.SHIPPED_FONT_RESOURCE_PATH + file, PdfEncodings.IDENTITY_H
                    );
                pdfFontList.Add(font);
            }
            return pdfFontList;
        }
    }
}

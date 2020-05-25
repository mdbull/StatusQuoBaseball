using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NTextUtilities.
    /// </summary>
    [TestFixture]
    public class NTextUtilities
    {
        private string text = "Balderdash";

        /// <summary>
        /// Tests the left justification filler.
        /// </summary>
        [Test]
        public void TestLeftJustificationFiller()
        {
            string finalText = "Balderdash     ";
            string justified = TextUtilities.FillString(text, ' ', (uint)text.Length + 5);
            Assert.IsTrue(justified.Equals(finalText));
        }

        /// <summary>
        /// Tests the right justification filler.
        /// </summary>
        [Test]
        public void TestRightJustificationFiller()
        {
            string finalText = "     Balderdash";
            string justified = TextUtilities.FillString(text, ' ', (uint)text.Length + 5,TextFillJustification.Right);
            Assert.IsTrue(justified.Equals(finalText));
        }

        /// <summary>
        /// Tests the center justification filler.
        /// </summary>
        [Test]
        public void TestCenterJustificationFiller()
        {
            string finalText1 = "   Balderdash  ";//odd total number
            string finalText2 = "   Balderdash   ";//even total number
            string justifiedOdd = TextUtilities.FillString(text, ' ', (uint)text.Length + 5, TextFillJustification.Center);
            string justifiedEven= TextUtilities.FillString(text, ' ', (uint)text.Length + 6, TextFillJustification.Center);
           
            Assert.IsTrue(justifiedOdd.Equals(finalText1));
            Assert.IsTrue(justifiedEven.Equals(finalText2));
        }
    }
}

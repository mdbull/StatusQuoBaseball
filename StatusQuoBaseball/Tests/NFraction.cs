using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NFraction.
    /// </summary>
    [TestFixture]
    public class NFraction
    {
        /// <summary>
        /// Tests the fraction reduction.
        /// </summary>
        [Test]
        public void TestFractionReduction()
        {
            Fraction f = new Fraction(13, 39);
            Assert.IsTrue(f.ToString() == "1/3");
            Console.WriteLine(f);
        }
    }
}

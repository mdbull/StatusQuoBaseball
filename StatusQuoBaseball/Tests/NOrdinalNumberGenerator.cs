using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NOrdinalNumberGenerator.
    /// </summary>
    [TestFixture]
    public class NOrdinalNumberGenerator
    {
        /// <summary>
        /// Tests the ordinal number generator.
        /// </summary>
        [Test]
        public void TestOrdinalNumberGenerator()
        {
            Assert.IsTrue(OrdinalNumberGenerator.Generate(1) == "1st");
            Assert.IsTrue(OrdinalNumberGenerator.Generate(22) == "22nd");
            Assert.IsTrue(OrdinalNumberGenerator.Generate(333) == "333rd");
            Assert.IsTrue(OrdinalNumberGenerator.Generate(10) == "10th");
        }
    }
}

using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NArrayUtilities.
    /// </summary>
    [TestFixture]
    public class NArrayUtilities
    {
        /// <summary>
        /// Tests the array contains.
        /// </summary>
        [Test]
        public void TestArrayContains()
        {
            string[] countries = { "JP", "KR", "CH" };
            Assert.IsTrue(ArrayUtilities<string>.ArrayContains("JP",countries));
        }
    }
}

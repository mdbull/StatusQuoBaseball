using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NArrayUtilities.
    /// </summary>
    [TestFixture]
    public class NSABRMetricsManager
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            SABRMetricsManager.Init(@"./Data/SABRmetrics/metrics.csv",true);
        }

        /// <summary>
        /// Tests the get fip.
        /// </summary>
        [Test]
        public void TestGetFIP()
        {
            double EXPECTED_FIP = 3.214;//cFIP constant for 2019
            Assert.IsTrue(SABRMetricsManager.GetFIPConstantByYear(2019) == EXPECTED_FIP);
        }


    }
}

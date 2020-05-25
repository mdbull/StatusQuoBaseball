using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NFielding stats.
    /// </summary>
    [TestFixture]
    public class NFieldingStats
    {
        /// <summary>
        /// Tests the load fielding stats from file.
        /// </summary>
        [Test]
        public void TestLoadFieldingStatsFromFile()
        {
            int expectedLines = 45;
            string path = @"./Data/BaseballReference/Arizona Diamondbacks_(2001)/Arizona Diamondbacks_(2001) Fielding.dat";
            Assert.IsTrue(File.Exists(path));
            try
            {
                FieldingStats[] fStats = FieldingStats.LoadFieldingStats(path);
                Assert.IsTrue(fStats.Length == expectedLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

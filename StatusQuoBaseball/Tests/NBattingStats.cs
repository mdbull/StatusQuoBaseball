using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NB atting stats.
    /// </summary>
    [TestFixture]
    public class NBattingStats
    {
        private BattingStats ps;

        /// <summary>
        /// Tests the length of the batting results array.
        /// </summary>
        [Test]
        public void TestBattingResultsArrayLength()
        {
            ps = new BattingStats(10,80, 1, 20, 30, 50, 70, 80, 90, 91, 100);
            Assert.IsTrue(ps.BattingResults.Length == 100);
            Assert.IsTrue(ps.BattingResultsRanges.Count == 9);
            ps.BattingResultsRanges.ForEach((x, y) =>
            {
                Console.WriteLine($"(Key: {x}, value: {y})");
            });
           
        }

        /// <summary>
        /// Tests the batting results outcomes.
        /// </summary>
        [Test]
        public void TestBattingResultsOutcomes()
        {
            ps = new BattingStats(10,80, 1, 20, 30, 50, 70, 80, 90, 91, 100);
            Assert.IsTrue(ps.BattingResults[0] == BattingResults.HBP);
            Assert.IsTrue(ps.BattingResults[28] == BattingResults.K);
            Assert.IsTrue(ps.BattingResults[99] == BattingResults.HR);
        }

        /// <summary>
        /// Tests the power rating.
        /// </summary>
        [Test]
        public void TestPowerRating()
        {
            ps = new BattingStats(10, 80, 1, 20, 30, 50, 70, 80, 90, 91, 100);
            Assert.IsTrue(ps.PowerRating == 81);
        }

        /// <summary>
        /// Tests the load batting stats from file.
        /// </summary>
        [Test]
        public void TestLoadBattingStatsFromFile()
        {
            int expectedLines = 41;
            string path = @"./Data/BaseballReference/Arizona Diamondbacks_(2001)/Arizona Diamondbacks_(2001) Batting.dat";
            Assert.IsTrue(File.Exists(path));
            try
            {
                BattingStats[] bStats = BattingStats.LoadBattingStats(path);
                Assert.IsTrue(bStats.Length == expectedLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

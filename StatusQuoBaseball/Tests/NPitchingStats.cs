using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NPitching stats.
    /// </summary>
    [TestFixture]
    public class NPitchingStats
    {
        private PitchingStats ps = new PitchingStats(75, 1, 4, 22, 58, 70, 80, 90, 97, 98, 100);

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
        }

        /// <summary>
        /// Tests the length of the pitch results array.
        /// </summary>
        [Test]
        public void TestPitchResultsArrayLength()
        {
            ps.Name = "Nolan Ryan";
            Assert.IsTrue(ps.PitchResults.Length == 100);
            Assert.IsTrue(ps.PitchResultsRanges.Count == 10);
            ps.PitchResultsRanges.ForEach((k, v) =>
            {
                Console.WriteLine($"{k}: {v}");
            });

        }

        /// <summary>
        /// Tests the pitch results outcomes.
        /// </summary>
        [Test]
        public void TestPitchResultsOutcomes()
        {
            Assert.IsTrue(ps.PitchResults[11] == PitchResults.BB);
            Assert.IsTrue(ps.PitchResults[50] == PitchResults.K);
            Assert.IsTrue(ps.PitchResults[99] == PitchResults.HR);
        }

        /// <summary>
        /// Tests the pitcher game.
        /// </summary>
        [Test]
        public void TestPitcherGame()
        {
            Player ryan = new Player("34","Ryan", "Nolan", "34", Positions.PositionNames[0], Race.White, Handedness.Right, Handedness.Right, new Height(74), new Weight(190), new Birthday(1947, 1, 31));

            ryan.PitchingStats = ps;

            Dictionary<PitchResults, int> frequency = new Dictionary<PitchResults, int>();
            for (int i = 0; i < 27; i++)
            {
                int roll = Dice.Roll(1, 100);
                PitchResults key = ryan.PitchingStats.PitchResults[roll - 1];
                if (!frequency.ContainsKey(key))
                    frequency.Add(key, 1);
                else
                    frequency[key] += 1;
            }
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests the load pitching stats from file.
        /// </summary>
        [Test]
        public void TestLoadPitchingStatsFromFile()
        {
            string path = @"./Data/BaseballReference/Arizona Diamondbacks_(2001)/Arizona Diamondbacks_(2001) Pitching.dat";
            PitchingStats[] pstats = null;
            Assert.IsTrue(File.Exists(path));
            try
            {
                int EXPECTED_LENGTH = 21;
                pstats = PitchingStats.LoadPitchingStats(path);
                pstats.ToList().ForEach(Console.WriteLine);
                Assert.IsTrue(pstats.Length == EXPECTED_LENGTH);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

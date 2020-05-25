using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NFieldingStatistics.
    /// </summary>
    [TestFixture]
    public class NFieldingStatistics
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
        }

        /// <summary>
        /// Tests the fielding statistics.
        /// </summary>
        [Test]
        public void TestFieldingStatistics()
        {
            Player bonds = new Player("1","Bonds", "Barry", "25", Positions.PositionNames[6], Race.Black, Handedness.Left, Handedness.Left, new Height(74), new Weight(225), new Birthday(1964, 7, 24));
            Player ryan = new Player("2","Ryan", "Nolan", "34", Positions.PositionNames[0], Race.White, Handedness.Right, Handedness.Right, new Height(74), new Weight(190), new Birthday(1947, 1, 31));
            Player rodriguez = new Player("3","Rodriguez", "Alex", "13", Positions.PositionNames[4], Race.Hispanic, Handedness.Right, Handedness.Right, new Height(75), new Weight(230), new Birthday(1975, 7, 27));
            FieldingStatisticsContainer container = new FieldingStatisticsContainer(rodriguez);
            container.LogStat(new Error(rodriguez, new DeepFlyOut(bonds, ryan, bonds), bonds, ryan,bonds));
            container.LogStat(new DeepFlyOut(bonds, ryan, bonds));
            container.LogStat(new Flyout(bonds, ryan, bonds));
            container.LogStat(new PopFlyOut(bonds, ryan, bonds));
            Console.WriteLine(container);
            Assert.IsTrue(container.Errors == 1);
            Assert.IsTrue(container.Assists == 0);
            Assert.IsTrue(container.Putouts == 3);

        }
    }
}

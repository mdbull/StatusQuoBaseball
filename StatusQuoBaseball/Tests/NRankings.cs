using NUnit.Framework;
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Base.RankingSorters;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NRankings.
    /// </summary>
    [TestFixture]
    public class NRankings
    {
        private string conn;

        private Db database;

        TeamGroupTree americanLeague;
        TeamGroupTree nationalLeague;
        int year = 2005;

        private List<Player> players=new List<Player>();

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(@"./Data/StoredProcedures/");
            VenueManager.Init(ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY"),true);
            conn = Constants.SQLITE3_CONNECTION_STRING;

            database = new Db(conn);
            americanLeague = DatabaseGroupLoader.LoadRoot("AL", year, database);
            americanLeague.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            nationalLeague = DatabaseGroupLoader.LoadRoot("NL", year, database);
            nationalLeague.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");

            try
            {
                americanLeague.Execute();
                nationalLeague.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        /// <summary>
        /// Tests the rank batting average.
        /// </summary>
        [Test]
        public void TestRankBattingAverage()
        {
            StringBuilder sb = new StringBuilder();
            Rankings<double> rankings = new Rankings<double>(nationalLeague,"AVG","SeasonStatistics.SeasonBattingStatistics.BattingAverage");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingAverageDescending(),10);
            Logger logger = new Logger("./Rankings/NLBattingAverageRankings.rankings");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
            Assert.IsTrue(rankings.RankedPlayers.Length == 10);
        }

        /// <summary>
        /// Tests the rank strikeouts.
        /// </summary>
        [Test]
        public void TestRankStrikeouts()
        {
            StringBuilder sb = new StringBuilder();
            Rankings<int> rankings = new Rankings<int>(americanLeague,"K","SeasonStatistics.SeasonPitchingStatistics.Strikeouts");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingByStrikeouts(), 10);
            Logger logger = new Logger("./Rankings/ALStrikeoutRankings.rankings");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
            Assert.IsTrue(rankings.RankedPlayers.Length == 10);
        }

        /// <summary>
        /// Tests the rank earned run average.
        /// </summary>
        [Test]
        public void TestRankEarnedRunAverage()
        {
            StringBuilder sb = new StringBuilder();
            Rankings<double> rankings = new Rankings<double>(nationalLeague,"ERA","SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingByERADescending(), 10);
            Logger logger = new Logger("./Rankings/NLERARankings.rankings");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
            Assert.IsTrue(rankings.RankedPlayers.Length == 10);
        }

        /// <summary>
        /// Tests the rank earned run average bottom 10 pitchers.
        /// </summary>
        [Test]
        public void TestRankEarnedRunAverageBottom()
        {
            StringBuilder sb = new StringBuilder();
            Rankings<double> rankings = new Rankings<double>(americanLeague, "ERA","SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingByERADescending(), 10);
            Logger logger = new Logger("./Rankings/ALERARankingsASC.rankings");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
            Assert.IsTrue(rankings.RankedPlayers.Length == 10);
        }

        /// <summary>
        /// Tests the rank by hits.
        /// </summary>
        [Test]
        public void TestRankByHits()
        {
            StringBuilder sb = new StringBuilder();
            Rankings<int> rankings = new Rankings<int>(americanLeague,"H","SeasonStatistics.SeasonBattingStatistics.Hits");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingByHits(),10);
            Logger logger = new Logger("./Rankings/ALHitRankings.rankings");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
            Assert.IsTrue(rankings.RankedPlayers.Length == 10);

        }
    }
}

using NUnit.Framework;
using System;
using System.IO;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NRoundRobin.
    /// </summary>
    [TestFixture]
    public class NRoundRobin
    {
        private string conn;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(@"./Data/StoredProcedures/");
            VenueManager.Init(ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY"), true);
            conn = Constants.SQLITE3_CONNECTION_STRING;
        }

        /// <summary>
        /// Tests the round robin.
        /// </summary>
        [Test]
        public void TestRoundRobinOdd()
        {
            Db database = new Db(conn);
            Team yankees2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("NYY", 2001, database);
            Team diamondbacks2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("ARI", 2001, database);
            Team mariners2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("SEA", 2001, database);
            Team giants2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("SFG", 2001, database);
            Team marlins2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("FLA", 2001, database);
            Team redsox2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("BOS", 2001, database);
            Team athletics2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("OAK", 2001, database);
            Team []teams = { yankees2001,diamondbacks2001,mariners2001,giants2001,redsox2001,marlins2001,athletics2001};
            RoundRobin roundRobin = new RoundRobin(1,true,true,true,500,teams);
            roundRobin.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            roundRobin.RoundRobinProgressHandled += ReportProgress;
            roundRobin.Execute();
            Assert.IsTrue(roundRobin.TotalGamesPlayed == 21);
        }

        /// <summary>
        /// Tests the round robin - even games
        /// </summary>
        [Test]
        public void TestRoundRobinEven()
        {
            Db database = new Db(conn);
            Team diamondbacks2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("ARI", 2001, database);
            Team mariners2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("SEA", 2001, database);
            Team giants2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("SFG", 2001, database);
            Team marlins2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("FLA", 2001, database);
            Team redsox2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("BOS", 2001, database);
            Team athletics2001 = DatabaseTeamLoader.LoadTeamFromFranchiseID("OAK", 2001, database);
            Team[] teams = {diamondbacks2001, mariners2001, giants2001, marlins2001, redsox2001, athletics2001 };
            RoundRobin roundRobin = new RoundRobin(1,true, true, true, 500, teams);
            roundRobin.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            roundRobin.RoundRobinProgressHandled += ReportProgress;
            roundRobin.Execute();
            Assert.IsTrue(roundRobin.TotalGamesPlayed == 15);
        }

        /// <summary>
        /// Reports the progress of the round robin.
        /// </summary>
        /// <param name="e">ProgressReporterEventArgs</param>
        private void ReportProgress(ProgressReporterEventArgs e)
        {
            try
            {
                Console.Write(TextUtilities.ProgressBar($"Played game {e.GamesPlayed} of {e.NumGames}", e.GamesPlayed, e.NumGames, 10, '.'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Tests the round robin full divisions1980.
        /// </summary>
        [Test]
        public void TestRoundRobinFullDivisions2019()
        {
            Db database = new Db(conn);
            TeamGroupTree americanLeague1980 = DatabaseGroupLoader.LoadRoot("AL", 2018, database);
            Assert.IsTrue(americanLeague1980.Count == 3);
            Assert.IsTrue(americanLeague1980.GetTotalItemCount<Team>() == 15);

            TeamGroupTree nationalLeague1980 = DatabaseGroupLoader.LoadRoot("NL", 2018, database);
            Assert.IsTrue(nationalLeague1980.Count == 3);
            Assert.IsTrue(nationalLeague1980.GetTotalItemCount<Team>() == 15);

            bool finished = false;
            americanLeague1980.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            americanLeague1980.Execute();
            nationalLeague1980.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            nationalLeague1980.Execute();
            finished = true;
            Assert.IsTrue(finished);
        }

        /// <summary>
        /// Tests the round robin full divisions1969.
        /// </summary>
        [Test]
        public void TestRoundRobinFullDivisions1969()
        {
            Db database = new Db(conn);
            TeamGroupTree americanLeague1969 = DatabaseGroupLoader.LoadRoot("AL", 1969, database,1);
            americanLeague1969.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            Assert.IsTrue(americanLeague1969.Count == 2);
            Assert.IsTrue(americanLeague1969.GetTotalItemCount<Team>() == 12);

            TeamGroupTree nationalLeague1969 = DatabaseGroupLoader.LoadRoot("NL", 1969, database,1);
            nationalLeague1969.ParentDirectoryPath= System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
            Assert.IsTrue(nationalLeague1969.Count == 2);
            Assert.IsTrue(nationalLeague1969.GetTotalItemCount<Team>() == 12);

            bool finished = false;
            americanLeague1969.Execute();
            nationalLeague1969.Execute();
            finished = true;
            Assert.IsTrue(finished);
        }
    }
}

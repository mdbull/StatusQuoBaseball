using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Runtime;
using NUnit.Framework;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NLoaders.
    /// </summary>
    [TestFixture]
    public class NLoaders
    {
        private string conn;

        private Db database;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(@"./Data/StoredProcedures/");
            conn = Constants.SQLITE3_CONNECTION_STRING;
        }

        /// <summary>
        /// Tests the database loader ex.
        /// </summary>
        //[Test]
        //public void TestDatabaseLoaderEx()
        //{
        //    database = new Db(conn);
        //    Team team = DatabaseTeamLoader.LoadTeamFromTeamID("Ari", 2001, database);
        //    Assert.IsTrue(team.Roster.Players.Length == 45);
        //    Assert.IsTrue(team.Name == "Arizona");
        //    Assert.IsTrue(team.Mascot == "Diamondbacks");
        //    Assert.IsTrue(team.Coach.FullName == "Bob Brenly");
        //    Console.WriteLine(new TeamInfoDisplayer(team).GetTeamStats(false));
        //}

        /// <summary>
        /// Tests the get multiple franchise keys.
        /// </summary>
        [Test]
        public void TestGetMultipleFranchiseKeys()
        {
            database = new Db(conn);
            Dictionary<string,string> keys = DatabaseTeamLoader.GetMultipleKeys("New York", 2001, database);
            Assert.IsTrue(keys.Count == 2);//NYY and NYM
            Assert.IsTrue(keys.ContainsKey("NYY"));
            Assert.IsTrue(keys.ContainsKey("NYM"));
        }

        /// <summary>
        /// Tests the database coach loader yankees2001.
        /// </summary>
        [Test]
        public void TestDatabaseCoachLoaderYankees2001()
        {
            string teamKey = "NYA";
            int year = 2001;
            database = new Db(conn);
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetCoachInfo");
            sp.Parameters = new object[] { teamKey, year };
            Coach coach = (Coach)new DatabaseCoachLoader(teamKey, year, database, sp.Text).Load();
            Assert.IsTrue(coach.FirstName == "Joe");
            Assert.IsTrue(coach.LastName == "Torre");
            Assert.IsTrue(coach.Handedness == Handedness.Right);
            Assert.IsTrue(coach.Height.ToString() == "6-2");
            Assert.IsTrue(coach.Birthday.Year == 1940);
            Assert.IsTrue(coach.CoachingAwards.Length == 3);
            Console.WriteLine(coach);
            //Dumper.Dump(coach);
        }

        /// <summary>
        /// Tests the database coach loader marlins2001.
        /// </summary>
        [Test]
        public void TestDatabaseCoachLoaderMarlins2001()
        {
            string teamKey = "FLO";
            int year = 2001;
            database = new Db(conn);
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetCoachInfo");
            sp.Parameters = new object[] { teamKey, year };
            Coach coach = (Coach)new DatabaseCoachLoader(teamKey, year, database, sp.Text).Load();
            Assert.IsTrue(coach.FirstName == "John");
            Assert.IsTrue(coach.LastName == "Boles");
            Assert.IsTrue(coach.Handedness == Handedness.Right);
            Assert.IsTrue(coach.Height.ToString() == "6-0");
            Assert.IsTrue(coach.Birthday.Year == 1948);
            Console.WriteLine(coach);
            //Dumper.Dump(coach);
        }

        /// <summary>
        /// Tests the database coach loader diamondbacks2001.
        /// </summary>
        [Test]
        public void TestDatabaseCoachLoaderDiamondbacks2001()
        {
            database = new Db(conn);
            string teamKey = "ARI";
            int year = 2001;
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetCoachInfo");
            sp.Parameters = new object[] { teamKey, year };
            Coach coach = (Coach)new DatabaseCoachLoader(teamKey, year, database, sp.Text).Load();
            Assert.IsTrue(coach.FirstName == "Bob");
            Assert.IsTrue(coach.LastName == "Brenly");
            Assert.IsTrue(coach.Handedness == Handedness.Right);
            Assert.IsTrue(coach.Height.ToString() == "6-2");
            Assert.IsTrue(coach.Birthday.Year == 1954);
            Console.WriteLine(coach);
            //Dumper.Dump(coach);
        }

        /// <summary>
        /// Tests the database roster loader.
        /// </summary>
        [Test]
        public void TestDatabaseRosterLoader()
        {
            database = new Db(conn);
            SQLStoredProcedure sql = StoredProcedureManager.Get("GetPlayerInfo");
            sql.Parameters = new object[] { "NYA", 2001 };
            Player[] players = (Player[])new DatabaseRosterLoader("NYA", 2001, database, sql.Text).Load();
            Roster roster = new Roster(null, players);
        }

        /// <summary>
        /// Tests the database team loader.
        /// </summary>
        //[Test]
        //public void TestDatabaseTeamLoader()
        //{
        //    database = new Db(conn);
        //    Team team = DatabaseTeamLoader.LoadTeam("New York", "Yankees", "NYA", 2001, database);
        //    Assert.IsTrue(team.Roster.Players.Length == 47);
        //    Assert.IsTrue(team.Name == "New York");
        //    Assert.IsTrue(team.Mascot == "Yankees");
        //    Assert.IsTrue(team.Coach.FullName == "Joe Torre");
        //    Console.WriteLine(new TeamInfoDisplayer(team).GetTeamStats(false));
        //}

        /// <summary>
        /// Tests the database team loader mets2001.
        /// </summary>
        //[Test]
        //public void TestDatabaseTeamLoaderMets2001()
        //{
        //    database = new Db(conn);
        //    Team team = DatabaseTeamLoader.LoadTeam("New York", "Mets", "NYN", 2001, database);
        //    Assert.IsTrue(team.Roster.Players.Length == 44);
        //    Assert.IsTrue(team.Name == "New York");
        //    Assert.IsTrue(team.Mascot == "Mets");
        //    Assert.IsTrue(team.Coach.FullName == "Bobby Valentine");
        //    Console.WriteLine(new TeamInfoDisplayer(team).GetTeamStats(false));
        //}

        /// <summary>
        /// Tests the database division loader parts.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderParts()
        {

            database = new Db(conn);
            Team yankees2001 = DatabaseTeamLoader.LoadTeam("New York", "Yankees", "NYA", 2001, database);
            Team diamondbacks2001 = DatabaseTeamLoader.LoadTeam("Arizona", "Diamondbacks", "ARI", 2001, database);
            Team mariners2001 = DatabaseTeamLoader.LoadTeam("Seattle", "Mariners", "SEA", 2001, database);

            Team orioles2001 = DatabaseTeamLoader.LoadTeam("Baltimore", "Orioles", "BAL", 2001, database);
            Team redsox2001 = DatabaseTeamLoader.LoadTeam("Boston", "Red Sox", "BOS", 2001, database);
            Team astros2001 = DatabaseTeamLoader.LoadTeam("Houston", "Astros", "HOU", 2001, database);
           

            Team[] teams = { yankees2001, diamondbacks2001, mariners2001 };
            Team[] teams2 = { orioles2001, redsox2001, astros2001 };

            TeamGroupTree nationalLeague2001 = new TeamGroupTree("NL2001", "National League 2001");
            nationalLeague2001.Add(new TeamGroup("NLW2001", "National League West 2001", teams));
            nationalLeague2001.Add(new TeamGroup("NLE2001", "National League East 2001", teams2));
            Assert.IsTrue(nationalLeague2001.GetTotalItemCount<Team>() == 6);
            Console.WriteLine(nationalLeague2001[0]);
            Console.WriteLine(nationalLeague2001[1]);
            Console.WriteLine(nationalLeague2001);
        }

        /// <summary>
        /// Tests the database division loader full MLB 1980.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderFullMLB1980()
        {
            database = new Db(conn);
            TeamGroupTree americanLeague1980 = DatabaseGroupLoader.LoadRoot("AL", 1980, database);
            Assert.IsTrue(americanLeague1980.Count == 2);
            Assert.IsTrue(americanLeague1980.GetTotalItemCount<Team>() == 14);

            TeamGroupTree nationalLeague1980 = DatabaseGroupLoader.LoadRoot("NL", 1980, database);
            Assert.IsTrue(nationalLeague1980.Count == 2);
            Assert.IsTrue(nationalLeague1980.GetTotalItemCount<Team>() == 12);

        }

        /// <summary>
        /// Tests the database division loader full AL 1980.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderFullAL1980()
        {
            database = new Db(conn);
            TeamGroupTree americanLeague1980 = DatabaseGroupLoader.LoadRoot("AL", 1980, database);
            Assert.IsTrue(americanLeague1980.Count == 2);
            Assert.IsTrue(americanLeague1980.GetTotalItemCount<Team>() == 14);
        }

        /// <summary>
        /// Tests the database division loader full NL 1980.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderFullNL1980()
        {
            database = new Db(conn);
            TeamGroupTree nationalLeague1980 = DatabaseGroupLoader.LoadRoot("NL", 1980, database);
            Assert.IsTrue(nationalLeague1980.Count == 2);
            Assert.IsTrue(nationalLeague1980.GetTotalItemCount<Team>() == 12);
        }

        /// <summary>
        /// Tests the database division loader full NL 2001.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderFullNL2001()
        {
            database = new Db(conn);
            TeamGroupTree nationalLeague2001 = DatabaseGroupLoader.LoadRoot("NL", 2001, database);
            Assert.IsTrue(nationalLeague2001.Count == 3);
            Assert.IsTrue(nationalLeague2001.GetTotalItemCount<Team>() == 16);
        }

        /// <summary>
        /// Tests the database division loader full AL 2001.
        /// </summary>
        [Test]
        public void TestDatabaseDivisionLoaderFullAL2001()
        {
            database = new Db(conn);
            TeamGroupTree americanLeague2001 = DatabaseGroupLoader.LoadRoot("AL", 2001, database);
            Assert.IsTrue(americanLeague2001.Count == 3);
            Assert.IsTrue(americanLeague2001.GetTotalItemCount<Team>() == 14);
        }

        /// <summary>
        /// Tests the database player statistics loader.
        /// </summary>
        [Test]
        public void TestDatabasePlayerStatisticsLoader()
        {
            database = new Db(conn);
           
            SQLStoredProcedure sql1 = StoredProcedureManager.Get("GetBattingInfo");
            sql1.Parameters = new object[] { "NYA", 2001 };
            SQLStoredProcedure sql2 = StoredProcedureManager.Get("GetPitchingInfo");
            sql2.Parameters = new object[] { "NYA", 2001 };
            SQLStoredProcedure sql3 = StoredProcedureManager.Get("GetFieldingInfo");
            sql3.Parameters = new object[] { "NYA", 2001 };

            Dictionary<string, DataTable> results = (Dictionary<string, DataTable>)new DatabasePlayerStatisticsLoader("NYA", 2001,database, string.Empty, new SQLStoredProcedure[] { sql1, sql2, sql3 }).Load();
            Assert.IsTrue(results.Count == 3);
            Assert.IsTrue(results.ContainsKey("Batting"));
            Assert.IsTrue(results.ContainsKey("Fielding"));

        }

    }
}

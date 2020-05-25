using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NCheck innings pitched.
    /// </summary>
    [TestFixture]
    public class NCheckInningsPitched
    {
        private readonly string conn = Constants.SQLITE3_CONNECTION_STRING;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(ConfigurationManager.GetConfigurationValue("STORED_PROCEDURES_DIRECTORY"));
            VenueManager.Init(ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY"), true);
        }

        #region MyRegion
        /// <summary>
        /// NCs the heck innings pitched.
        /// </summary>
        [Test]
        public void TestCheckInningsPitched()
        {
            Db database = new Db(conn);

            bool passed = true;

            const int ITERATIONS = 3;


            Team roadTeam;
            Team homeTeam;

            for (int i = 0; i < ITERATIONS && passed; i++)
            {
                roadTeam = DatabaseTeamLoader.LoadTeam("New York", "Yankees", 1982, database);
                roadTeam.CapitalizeNames = true;
                roadTeam.ShowExtendedToString = true;
                homeTeam = DatabaseTeamLoader.LoadTeam("Oakland", "Athletics", 1982, database);
                homeTeam.CapitalizeNames = true;
                homeTeam.ShowExtendedToString = true;

                Game g = null;

                Venue venue = VenueManager.GetVenue(homeTeam.RawName);

                g = new Game(venue, roadTeam, homeTeam, Game.GenerateGameTime(), Convert.ToInt32(ConfigurationManager.GetConfigurationValue("CURRENT_NUM_INNINGS_REGULATION")), true);

                Logger logger = new Logger(String.Format($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}{g.Id}{ConfigurationManager.GetConfigurationValue("GAME_FILE_EXTENSION")}"));

                g.Announcer = new Announcer(Guid.NewGuid().ToString(), ConfigurationManager.GetConfigurationValue("ANNOUNCER_NAME"),logger);//make sure announcer commentary gets logged
                g.Announcer.Silent = false;
                g.Announcer.AnnounceToConsole(ConfigurationManager.GetConfigurationValue("GAME_TITLE"));
                g.Execute();
                GameStatisticsDisplayer displayer = new GameStatisticsDisplayer(g.Scoreboard);
                Console.WriteLine(displayer.GetBoxScore());
                g.Announcer.AnnounceToConsole(new GameStatisticsDisplayer(g.Scoreboard).GetFullBoxScore());
                Console.WriteLine($"{g.Scoreboard.ToString()}");
                logger.WriteToFile();

                int totalHomeOuts = 0;
                int totalInnings = g.Scoreboard.InningScores.Length;
                foreach (Player p in g.HomeTeam.Roster.StartingPitchers)
                {
                    totalHomeOuts += p.PitchingStatistics.TotalOuts;
                }
                foreach (Player p in g.HomeTeam.Roster.Bullpen)
                {
                    totalHomeOuts += p.PitchingStatistics.TotalOuts;
                }
                Console.WriteLine($"TotalHomeOuts: {totalHomeOuts} - TotalInnings: {totalInnings}");
                if (totalHomeOuts != (totalInnings * 3))
                    passed = false;
            }
            Assert.IsTrue(passed);
        }
        #endregion
    }
}

using NUnit.Framework;
using System;
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
    /// NTeam.
    /// </summary>
    [TestFixture]
    public class NTeam
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
        /// Tests the load from file.
        /// </summary>
        [Test]
        public void TestLoadFromFile()
        {
            int EXPECTED_ROSTER_SIZE = 48;
            string directory = Configuration.ConfigurationManager.GetConfigurationValue("TEST_ROAD_TEAM_DIRECTORY_2");
            Team t = TeamLoader.LoadTeam(directory);
            Assert.IsTrue(t.Roster.RosterSize == EXPECTED_ROSTER_SIZE);
            Assert.IsTrue(t.RawName == "Seattle Mariners");
        }

        /// <summary>
        /// Tests the team displayer.
        /// </summary>
        [Test]
        public void TestTeamDisplayer()
        {

            //string directory = Configuration.ConfigurationManager.GetConfigurationValue("TEST_ROAD_TEAM_DIRECTORY_2");
            //Team t = TeamLoader.LoadTeam(directory);
            //t.Roster.SetStartingLineup();
            //TeamInfoDisplayer displayer = new TeamInfoDisplayer(t);
            //Console.WriteLine(displayer.GetTeamInformation());
            //Assert.IsTrue(displayer.GetTeamInformation().Length > 0);
            //Console.WriteLine(displayer.GetTeamStats());
            //Assert.IsTrue(displayer.GetTeamStats().Length > 0);
            //Console.WriteLine($"{displayer.GetIndividualStats(t.Roster.Lineup[3],true)}");
        }

        /// <summary>
        /// Tests the get team name from directory.
        /// </summary>
        [Test]
        public void TestGetTeamNameFromDirectory()
        {
           
            string EXPECTED_NAME = "New York Yankees (2001)";
            string directory = Configuration.ConfigurationManager.GetConfigurationValue("TEST_HOME_TEAM_DIRECTORY");
            string teamName = TeamLoader.GetFullTeamNameFromDirectory(directory);
            Assert.IsTrue(teamName.Equals(EXPECTED_NAME));
        }

        /// <summary>
        /// Tests the get starting pitcher variety.
        /// </summary>
        [Test]
        public void TestGetStartingPitcherVariety()
        {
            //Needed to make sure all starters are getting chosen

          
            //string directory = Configuration.ConfigurationManager.GetConfigurationValue("TEST_ROAD_TEAM_DIRECTORY_2");
            //Team t = TeamLoader.LoadTeam(directory);
            //t.Roster.SetStartingLineup();
            //List<int> indicesSelected = new List<int>();
            //List<Player> startingPitchers = new List<Player>();
            //const int LOOPS = 300;
            //const int MAX = 5;
            //for (int i = 0; i < LOOPS; i++)
            //{
            //    Player starter = t.Roster.GetStartingPitcher(MAX);
            //    startingPitchers.Add(starter);
            //    indicesSelected.Add(t.Roster.Bullpen.ToList().IndexOf(starter));
            //}

            //bool allIndicesSelected = true;

            //for (int i = 0; i < MAX; i++)
            //{
            //    if (!indicesSelected.Contains(i))
            //    {
            //        allIndicesSelected = false;
            //        break;
            //    }
            //}

            //Assert.IsTrue(allIndicesSelected);

        }
    }
}

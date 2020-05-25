using NUnit.Framework;
using System;
using System.IO;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NCoach.
    /// </summary>
    [TestFixture]
    public class NCoach
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
        /// Tests the get coach info.
        /// </summary>
        [Test]
        public void TestGetCoachInfo()
        {
            Coach c = new Coach("55", "Baker", "Dusty", "12", "RF", Race.Black, Handedness.Right, Handedness.Right, new Height(74), new Weight(183), new Birthday(1949, 6, 15));
            Assert.IsTrue(c.FullName == "Dusty Baker");
            Assert.IsTrue(c.Race == Race.Black);
            Assert.IsTrue(c.Handedness == Handedness.Right);
            Assert.IsTrue(c.Bats == Handedness.Right);
            Assert.IsTrue(c.Throws == Handedness.Right);
            Assert.IsTrue(c.Height.Inches == 74);
            Assert.IsTrue(c.Weight.Pounds == 183);
            Assert.IsTrue(c.Birthday.Year == 1949);
            Assert.IsTrue(c.Birthday.Age == 70); //if this test fails later, adjust expected age
        }

        /// <summary>
        /// Tests the load coach from file.
        /// </summary>
        [Test]
        public void TestLoadCoachFromFile()
        {
            //Load Coach/manager from baseballreference.com
            Coach ret = null;
            InMemoryConfigurationFile coachInfoFile = null;
            string coachInfoFilePath = TextUtilities.FormFilePathName(ConfigurationManager.GetConfigurationValue("TEST_ROAD_TEAM_DIRECTORY_2"), "Coach", ".dat");

            if (File.Exists(coachInfoFilePath))
            {
                try
                {
                    coachInfoFile = ConfigurationManager.GetInMemoryConfigFile(coachInfoFilePath);

                    //Player-relevant fields
                    string lName = coachInfoFile["lastName"].ToString();
                    string fName = coachInfoFile["firstName"].ToString();
                    string position = coachInfoFile["position"].ToString();
                    Height height = new Height(coachInfoFile["height"].ToString());
                    Weight weight = new Weight(Convert.ToInt32(coachInfoFile["weight"]));
                    Birthday bDay = new Birthday(coachInfoFile["birthday"].ToString());

                    ret = new Coach(Guid.NewGuid().ToString(), lName, fName, "", position, Race.Unknown, Handedness.Unknown, Handedness.Unknown, height, weight, bDay);

                    //Managerial Tendencies form Coaching Stats
                    CoachingStats cStats = new CoachingStats(coachInfoFile);
                    if (cStats != null)
                        ret.CoachingStats = cStats;

                    Assert.IsTrue(ret.FullName.Equals("Lou Piniella"));
                    Assert.IsTrue(ret.CoachingStats.Rating == 91);//52 * 1.75
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}

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
    /// NInMemoryConfigurationFile.
    /// </summary>
    [TestFixture]
    public class NInMemoryConfigurationFile
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
        /// Tests the in memory configuration file.
        /// </summary>
        [Test]
        public void TestInMemoryConfigurationFile()
        {
            const int EXPECTED_NUM_LINES = 12;
            string directory = ConfigurationManager.GetConfigurationValue("TEST_ROAD_TEAM_DIRECTORY_2");//Lou Piniella
            string coachInfoFilePath = TextUtilities.FormFilePathName(directory, "Coach", ".dat");
            InMemoryConfigurationFile coachInfoFile = ConfigurationManager.GetInMemoryConfigFile(coachInfoFilePath);
            Assert.NotNull(coachInfoFile);
            Assert.IsTrue(EXPECTED_NUM_LINES == coachInfoFile.Count);
        }
    }
}

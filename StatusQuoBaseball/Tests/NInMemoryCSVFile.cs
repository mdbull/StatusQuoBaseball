using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NInMemoryCSVFile.
    /// </summary>
    [TestFixture]
    public class NInMemoryCSVFile
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
        /// Tests the CSVF ile load.
        /// </summary>
        [Test]
        public void TestCSVFileLoad()
        {
            int EXPECTED_LINES = 31;
            string filePath = ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY");
            InMemoryCSVFile csvFile = InMemoryCSVFile.ReadCSVFile(filePath,true);
            Assert.IsTrue(csvFile.LineCount == EXPECTED_LINES);
            Assert.IsTrue(csvFile.HeaderRow.Length == 9);
            Assert.IsTrue(csvFile.HeaderRow[4] == "Team");
            Assert.IsTrue(csvFile[1][4] == "Los Angeles Angels");
        }
    }
}

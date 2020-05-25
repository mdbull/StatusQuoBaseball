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
    /// NConfigurationManger.
    /// </summary>
    [TestFixture]
    public class NConfigurationManger
    {
        /// <summary>
        /// Tests the get config file information.
        /// </summary>
        [Test]
        public void TestGetConfigFileInformation()
        {
            if (File.Exists(Constants.CONFIG_FILE_PATH))
            {
                var EXPECTED_COUNT = File.ReadAllLines(Constants.CONFIG_FILE_PATH).Length-2; //2 commented lines should not be picked up
                ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
                Assert.IsTrue(ConfigurationManager.GetConfigFileSize(Constants.CONFIG_FILE_PATH) == EXPECTED_COUNT);
            }
        }

        /// <summary>
        /// Tests the incorrect config file information.
        /// </summary>
        [Test]
        public void TestIncorrectConfigFileInformation()
        {
            string filePath = @"./configs.config";

            try
            {
                ConfigurationManager.Init(filePath, Constants.CONFIG_FILE_DELIMITER);

            }
            catch (ConfigurationManagerException ex)
            {
                Assert.IsTrue(ConfigurationManager.Count == 0);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
                Console.WriteLine("Aborting program...");

            }
        }

        /// <summary>
        /// Tests the get multiple config file information.
        /// </summary>
        [Test]
        public void TestGetMultipleConfigFileInformation()
        {
            string[] files = { @"./config.config", @"./games.config" };
            int[] EXPECTED_COUNTS = { File.ReadAllLines(files[0]).Length - 2, File.ReadAllLines(files[1]).Length - 2 };

            ConfigurationManager.Init(files, Constants.CONFIG_FILE_DELIMITER);
            Assert.IsTrue(ConfigurationManager.Count == EXPECTED_COUNTS.Length);
        }
    }
}

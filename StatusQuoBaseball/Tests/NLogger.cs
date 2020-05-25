using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Gameplay;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NLogger.
    /// </summary>
    [TestFixture]
    public class NLogger
    {
        private Logger logger = new Logger("./test.game");

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
        }

        /// <summary>
        /// Tests the write to file.
        /// </summary>
        [Test]
        public void TestWriteToFile()
        {
            string msg1 = "msg1";
            string msg2 = "msg2";
            string msg3 = "msg3";
            logger.LogMessage(msg1);
            logger.LogMessage(msg2);
            logger.LogMessage(msg3);
            int linesWritten = logger.WriteToFile();
            Assert.IsTrue(linesWritten == 15);//12 characters + 3 newline characters
            Assert.IsTrue(File.Exists("./test.game"));
        }
    }
}

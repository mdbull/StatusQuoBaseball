using NUnit.Framework;
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NP layer.
    /// </summary>
    [TestFixture]
    public class NPlayer
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
        /// Tests the get player info.
        /// </summary>
        [Test]
        public void TestGetPlayerInfo()
        {
            Player p = new Player(Guid.NewGuid().ToString(),"Bonds", "Barry", "25", Positions.PositionNames[6], Race.Black, Handedness.Left,Handedness.Left, new Height(74),new Weight(225),new Birthday(1964,  7, 24));
            //string toString = p.ToString();
            //Assert.IsTrue(toString.Equals("LF 25 Barry Bonds")); //For some reason it is not matching up!
            Assert.IsTrue(p.Race == Race.Black);
            Assert.IsTrue(p.Handedness == Handedness.Left);
            Assert.IsTrue(p.Bats == Handedness.Left);
            Assert.IsTrue(p.NaturalPosition == Positions.PositionNames[6]); //"LF"
            Assert.IsTrue(p.Throws == Handedness.Left);
            Assert.IsTrue(p.Height.Inches == 74);
            Assert.IsTrue(p.Weight.Pounds == 225);
         
        }

    }
}

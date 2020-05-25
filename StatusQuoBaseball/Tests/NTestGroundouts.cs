using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NTest groundouts.
    /// </summary>
    [TestFixture]
    public class NTestGroundouts
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
        /// Tests the groundout location.
        /// </summary>
        [Test]
        public void TestGroundoutLocation()
        {
            GroundOut groundout = new GroundOut(NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer);
            Console.WriteLine(groundout);
            Assert.IsTrue(((int)groundout.OutLocation) < 7);
        }
    }
}

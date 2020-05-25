using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NNull player.
    /// </summary>
    [TestFixture]
    public class NNullPlayer
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
        /// Tests the null player.
        /// </summary>
        [Test]
        public void TestNullPlayer()
        {
            Player p = NullPlayer.EmptyPlayer;
            Console.WriteLine(p);
            Player p2 = NullPlayer.EmptyPlayer;
            Assert.IsTrue(Object.ReferenceEquals(p, p2));
        }
    }
}

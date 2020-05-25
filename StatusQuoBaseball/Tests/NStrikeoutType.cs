using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NStrikeoutType.
    /// </summary>
    [TestFixture]
    public class NStrikeoutType
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
        /// Tests the type of the pitcher strikeout.
        /// </summary>
        [Test]
        public void TestPitcherStrikeoutType()
        {
            //Pitchers in control will not get a foul tip strikeout
            Strikeout strikeout = new Strikeout(NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer,NullPlayer.EmptyPlayer);
            Console.WriteLine(strikeout.StrikeoutType);
            Console.WriteLine(strikeout);
        }
    }
}

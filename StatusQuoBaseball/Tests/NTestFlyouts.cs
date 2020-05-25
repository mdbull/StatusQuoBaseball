using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NTest flyouts.
    /// </summary>
    [TestFixture]
    public class NTestFlyouts
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
        /// Tests the pop fly out location.
        /// </summary>
        [Test]
        public void TestPopFlyOutLocation()
        {
            PopFlyOut popup = new PopFlyOut(NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer,NullPlayer.EmptyPlayer);
            Console.WriteLine(popup);
            Assert.IsTrue(popup.OutLocation!=FieldLocation.Unknown);
        }

        /// <summary>
        /// Tests the fly out location.
        /// </summary>
        [Test]
        public void TestFlyOutLocation()
        {
            Flyout flyout = new Flyout(NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer);
            Console.WriteLine(flyout);
            Assert.IsTrue(((int)flyout.OutLocation) > 6);
        }

        /// <summary>
        /// Tests the deep fly out location.
        /// </summary>
        [Test]
        public void TestDeepFlyOutLocation()
        {
            DeepFlyOut deepFlyout = new DeepFlyOut(NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer, NullPlayer.EmptyPlayer);
            Console.WriteLine(deepFlyout);
            Assert.IsTrue(((int)deepFlyout.OutLocation) > 6);
        }
    }
}

using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NHeight.
    /// </summary>
    [TestFixture]
    public class NHeight
    {
        private Height height;
        private Height[] dataSet;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            this.height = new Height(74);
            this.dataSet = new Height[] { new Height(74), new Height(76), new Height(69), new Height(80) }; 
        }

        /// <summary>
        /// Tests the get height in feet.
        /// </summary>
        [Test]
        public void TestGetHeightInFeet()
        {
            Assert.IsTrue(height.ToString().Equals("6-2"));
        }

        /// <summary>
        /// Tests the get height average.
        /// </summary>
        [Test]
        public void TestGetHeightAverage()
        {
            Assert.IsTrue(Height.GetAverageHeight(dataSet).ToString() == "6-2");
            Assert.IsFalse(Height.GetAverageHeight(dataSet).ToString() == "6-4");
        }

        /// <summary>
        /// Tests the empty height.
        /// </summary>
        [Test]
        public void TestEmptyHeight()
        {
            Assert.IsTrue(Height.Default.Inches == 72);
            Assert.IsTrue(Height.Default.ToString() == "6-0");
        }

        /// <summary>
        /// Tests the empty height reference equality.
        /// </summary>
        [Test]
        public void TestEmptyHeightReferenceEquality()
        {
            Assert.IsTrue(Object.ReferenceEquals(Height.Default, Height.Default));
        }

        /// <summary>
        /// Tests the get height in meters.
        /// </summary>
        [Test]
        public void TestGetHeightInMeters()
        {
            Height h = new Height(74);
            h.UseMetricSystem = true;
            //Assert.IsTrue((h.Meters * 10000) == 18796);
            //Assert.IsTrue(h.ToString().Equals("1.8976 m"));
        }

        /// <summary>
        /// Tests the get height from string constructor.
        /// </summary>
        [Test]
        public void TestGetHeightFromStringConstructor()
        {
            Height h = new Height("6' 3\"");
            Assert.IsTrue(h.ToString().Equals("6-3"));

            Height h2 = new Height("6-3");
            Assert.IsTrue(h2.ToString().Equals("6-3"));
        }
    }
}
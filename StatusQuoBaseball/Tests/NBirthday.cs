using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NBirthday.
    /// </summary>
    [TestFixture]
    public class NBirthday
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
        }


        [Test]
        public void TestDeathday()
        {
           
            Deathday d = new Deathday("2019-1-1");
            Assert.IsTrue(d.Year == 2019);
            Assert.IsTrue(d.Month == 1);
            Assert.IsTrue(d.Day == 1);
        }

        /// <summary>
        /// Tests the get age.
        /// </summary>
        [Test]
        public void TestGetAge()
        {
            Birthday b = new Birthday(1964, 7, 24);
            Assert.IsTrue(b.Year == 1964);
            Assert.IsTrue(b.ToString() == "7/24/1964");
            Assert.IsTrue(b.ToLongDateString() == "July 24, 1964");
            Assert.IsTrue(b.Age == 55); //if this test fails later, adjust expected age
        }

        /// <summary>
        /// Tests the get age string constructor.
        /// </summary>
        [Test]
        public void TestGetAgeStringConstructor()
        {
            Birthday b = new Birthday("July 24, 1964");
            Assert.IsTrue(b.Year == 1964);
            Assert.IsTrue(b.ToString() == "7/24/1964");
            Assert.IsTrue(b.ToLongDateString() == "July 24, 1964");
            Assert.IsTrue(b.Age == 55); //if this test fails later, adjust expected age
        }

        /// <summary>
        /// Tests the get age date time constructor.
        /// </summary>
        [Test]
        public void TestGetAgeDateTimeConstructor()
        {
            Birthday b = new Birthday(new DateTime(1964,7,24));
            Assert.IsTrue(b.Year == 1964);
            Assert.IsTrue(b.ToString() == "7/24/1964");
            Assert.IsTrue(b.ToLongDateString() == "July 24, 1964");
            Assert.IsTrue(b.Age == 55); //if this test fails later, adjust expected age
        }

        /// <summary>
        /// Tests the empty birthday get age.
        /// </summary>
        [Test]
        public void TestEmptyBirthdayGetAge()
        {
            Assert.IsTrue(Birthday.Default.Age == 40);
        }
    }
}

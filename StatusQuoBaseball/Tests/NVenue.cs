using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NV enue.
    /// </summary>
    [TestFixture]
    public class NVenue
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            VenueManager.Init(ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY"), true);
        }

        /// <summary>
        /// Tests the generic venue information.
        /// </summary>
        [Test]
        public void TestGenericVenueInformation()
        {
            Assert.IsTrue(Venue.GenericVenue.Location == "Anytown, USA");
            Assert.IsTrue(Venue.GenericVenue.Capacity == 40000);
            Assert.IsTrue(VenueManager.GetVenue("Montreal Expos").Name == "Montreal Expos Stadium");
        }

        /// <summary>
        /// Tests the get venue information.
        /// </summary>
        [Test]
        public void TestGetVenueInformation()
        {

            string ID = "1";
            int CAPACITY = 41956;
            string NAME = "PacBell Park";
            string LOCATION = "San Francisco";

            Venue venue = new Venue(ID, CAPACITY, NAME, LOCATION);
            Console.WriteLine(venue);
            Assert.IsTrue(venue.Id.Equals(ID));
            Assert.IsTrue(venue.Capacity == CAPACITY);
            Assert.IsTrue(venue.Name.Equals(NAME));
            Assert.IsTrue(venue.Location.Equals(LOCATION));
        }

        /// <summary>
        /// Tests the get venue manager.
        /// </summary>
        [Test]
        public void TestGetVenueManager()
        {

            Venue theVenue = VenueManager.GetVenue("Los Angeles Angels");
            Console.WriteLine(theVenue);
            Assert.IsTrue(VenueManager.VenueCount == 30);
            Assert.IsTrue(theVenue.Name.Equals("Angel Stadium"));
            Assert.IsTrue(theVenue.Capacity == 45517);
            Assert.IsTrue(theVenue.Location.Equals("Anaheim, California"));
            Console.WriteLine(theVenue);

        }
    }
}

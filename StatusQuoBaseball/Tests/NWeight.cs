using NUnit.Framework;
using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NWeight.
    /// </summary>
    [TestFixture]
    public class NWeight
    {
        private const int WEIGHT_IN_POUNDS = 200;
        private const double WEIGHT_IN_KILOGRAMS = 90.7184;
        private readonly string WEIGHT_IN_POUNDS_STRING = String.Format("{0} lbs.", WEIGHT_IN_POUNDS);
        private readonly string WEIGHT_IN_KILOGRAMS_STRING = String.Format("{0} kg.", WEIGHT_IN_KILOGRAMS);

        private Weight weight;
        private Weight[] dataSet;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
        }

        /// <summary>
        /// Tests the weight to string.
        /// </summary>
        [Test]
        public void TestWeightToString()
        {
            weight = new Weight(WEIGHT_IN_POUNDS);
            weight.UseMetricSystem = false;
            Assert.IsTrue(weight.ToString().Equals(WEIGHT_IN_POUNDS_STRING));
        }

        /// <summary>
        /// Tests the weight to kilo string.
        /// </summary>
        [Test]
        public void TestWeightToKiloString()
        {
            weight = new Weight(WEIGHT_IN_POUNDS);
            weight.UseMetricSystem = true;
            Assert.IsTrue(weight.ToString().Equals(WEIGHT_IN_KILOGRAMS_STRING));
            Assert.IsTrue(weight.ToString().Equals(WEIGHT_IN_KILOGRAMS_STRING));
        }

        /// <summary>
        /// Tests the get weight average pounds.
        /// </summary>
        [Test]
        public void TestGetWeightAveragePounds()
        {
            weight = new Weight(WEIGHT_IN_POUNDS);
            weight.UseMetricSystem = false;
            Assert.IsTrue(Weight.GetAverageWeight(dataSet).ToString() == String.Format("{0} lbs.",WEIGHT_IN_POUNDS));
            Assert.IsFalse(Weight.GetAverageWeight(dataSet).ToString() == "245 lbs.");
            Assert.IsTrue(Weight.GetAverageWeight(dataSet).Pounds == WEIGHT_IN_POUNDS);
        }

        /// <summary>
        /// Tests the get weight average kilograms.
        /// </summary>
        [Test]
        public void TestGetWeightAverageKilograms()
        {
            dataSet = new Weight[] { new Weight(200), new Weight(210), new Weight(190) };
            Assert.IsTrue(Weight.GetAverageWeight(dataSet, true).ToString() == String.Format("{0} kg.", WEIGHT_IN_KILOGRAMS));
            Assert.IsFalse(Weight.GetAverageWeight(dataSet, true).ToString() == "245 kg.");
            //Assert.IsTrue(Weight.GetAverageWeight(dataSet,true).Kilograms == WEIGHT_IN_KILOGRAMS);
        }

        /// <summary>
        /// Tests the empty weight.
        /// </summary>
        [Test]
        public void TestEmptyWeight()
        {
            Assert.IsTrue(Weight.Default.Pounds == Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("DEFAULT_PROFESSIONAL_WEIGHT")));
            Assert.IsTrue(Weight.Default.ToString() == "185 lbs.");
        }

        /// <summary>
        /// Tests the empty weight reference equality.
        /// </summary>
        [Test]
        public void TestEmptyWeightReferenceEquality()
        {
            Assert.IsTrue(Object.ReferenceEquals(Weight.Default, Weight.Default));
        }
    }
}

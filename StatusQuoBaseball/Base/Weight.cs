using System;
using System.Text.RegularExpressions;
using System.Text;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Weight.
    /// </summary>
    [Serializable]
    public class Weight:Measurement
    {
        /// <summary>
        /// The lbs to kg conversion rate.
        /// </summary>
        public static readonly double KG_CONVERTER = 0.453592;

        /// <summary>
        /// The default weight.
        /// </summary>
        public static readonly Weight Default = new Weight(Configuration.ConfigurationManager.GetConfigurationValue("DEFAULT_PROFESSIONAL_WEIGHT"));

        private int pounds;
     
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Weight"/> class.
        /// </summary>
        private Weight()
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Weight"/> class.
        /// </summary>
        /// <param name="pounds">int</param>
        public Weight(int pounds)
        {
            this.pounds = pounds;
            this.units = this.pounds * KG_CONVERTER;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Weight"/> class.
        /// </summary>
        /// <param name="pounds">string</param>
        public Weight(string pounds)
        {

            if (pounds.Length > 0)
            {
                var result = Regex.Match(pounds, @"\d+").Value;
                this.pounds = Convert.ToInt32(result);
                this.units = this.pounds * KG_CONVERTER;
            }
            else
            {
                this.pounds = 175;
                this.units = this.pounds * KG_CONVERTER;
            }
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Gets the average weight of a data set.
        /// </summary>
        /// <returns>Weight</returns>
        /// <param name="dataSet">Weight[]</param>
        /// <param name="useMetricSystem">bool</param>
        public static Weight GetAverageWeight(Weight[] dataSet, bool useMetricSystem = false)
        {
            int totalPounds = 0;
            Weight ret = null;
            foreach (Weight w in dataSet)
            {
                totalPounds += w.pounds;
            }
            ret = new Weight(totalPounds / dataSet.Length);
            ret.UseMetricSystem = useMetricSystem;
            return ret;
        }

        /// <summary>
        /// Sets weight to string representation.
        /// </summary>
        protected override void BuildToString()
        {
            //build pounds string
            StringBuilder val = new StringBuilder();
            val.Append(this.pounds);
            val.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            val.Append("lbs.");
           this.toString = val.ToString();

            //build kiloString
            val.Clear();
            val.Append(this.units);
            val.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            val.Append("kg.");
            this.metricString = val.ToString();
        }

        /// <summary>
        /// Gets the pounds.
        /// </summary>
        /// <value>int</value>
        public int Pounds { get => pounds; }

        /// <summary>
        /// Gets the kilograms.
        /// </summary>
        /// <value>double</value>
        public double Kilograms { get => units;}


    }
}

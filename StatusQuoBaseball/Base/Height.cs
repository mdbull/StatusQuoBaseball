using System;
using System.Text;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Height.
    /// </summary>
    [Serializable]
    public class Height:Measurement
    {
        /// <summary>
        /// The inches to cm conversion rate.
        /// </summary>
        public static readonly double CM_CONV = 2.54;

        /// <summary>
        /// Default height.
        /// </summary>
        public static readonly Height Default = new Height(Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("DEFAULT_PROFESSIONAL_HEIGHT")));
        private int inches;
       
      
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Height"/> class.
        /// </summary>
        private Height()
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Height"/> class.
        /// </summary>
        /// <param name="inches">Units.</param>
        public Height(int inches)
        {
            this.inches = inches;
            this.units = this.inches * CM_CONV / 100.0; //get height in meters
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Height"/> class.
        /// </summary>
        /// <param name="height">string</param>
        public Height(string height)
        {
            if (height.Length > 0)
            {
                string[] values = height.Split('\'', '-');
                values[1] = values[1].TrimStart(' ');
                if (values[1].Contains("\""))
                {
                    values[1] = values[1].Remove(values[1].Length - 1);
                }
                int _feet = 0;
                int _inches = 0;
                Int32.TryParse(values[0], out _feet);
                Int32.TryParse(values[1], out _inches);
                this.inches = (_feet * 12) + _inches;
                this.units = inches * CM_CONV / 100.0; //get height in meters
               
            }
            else
            {
                this.inches = 72;
                this.units = inches * CM_CONV / 100.0; //get height in meters
            }
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor

        }

        /// <summary>
        /// Gets the average height of a data set.
        /// </summary>
        /// <returns>Height</returns>
        /// <param name="dataSet">Data set</param>
        public static Height GetAverageHeight(Height [] dataSet)
        {
            int totalInches = 0;
            foreach (Height h in dataSet)
            {
                totalInches += h.inches;
            }
            return new Height(totalInches / dataSet.Length);
        }

        /// <summary>
        /// Sets height to string representation.
        /// </summary>
        protected override void BuildToString()
        {
            StringBuilder val = new StringBuilder();
            val.Append(this.inches/12);
            val.Append(Configuration.ConfigurationManager.GetConfigurationValue("DASH"));
            val.Append(this.inches % 12);
            toString = val.ToString();

            val.Clear();
            val.AppendFormat($"{this.units} m");
            metricString = val.ToString();
        }

        /// <summary>
        /// Gets or sets the inches.
        /// </summary>
        /// <value>The inches.</value>
        public int Inches { get => inches;}

        /// <summary>
        /// Gets the meters.
        /// </summary>
        /// <value>The meters.</value>
        public double Meters
        {
            get => this.units;
        }
    }
}

using System;
namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Measurement.
    /// </summary>
    [Serializable]
    public abstract class Measurement:Entity
    {
        /// <summary>
        /// Determines whether the measurement will use the metric system or not.
        /// </summary>
        protected bool useMetricSystem;

        /// <summary>
        /// The metric system string.
        /// </summary>
        protected string metricString = string.Empty;

        /// <summary>
        /// The units.
        /// </summary>
        protected double units;//can be kg or cm

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Measurement"/> class.
        /// </summary>
        protected Measurement()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Measurement"/> use metric system.
        /// </summary>
        /// <value><c>true</c> if use metric system; otherwise, <c>false</c>.</value>
        public bool UseMetricSystem
        {
            get { return this.useMetricSystem; }
            set { this.useMetricSystem = value; }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Weight"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Weight"/>.</returns>
        public override string ToString()
        {
            if (this.useMetricSystem)
                return metricString;
            return toString;
        }
    }
}

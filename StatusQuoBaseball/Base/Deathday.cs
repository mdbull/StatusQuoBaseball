using System;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Deathday.
    /// </summary>
    [Serializable]
    public class Deathday : Birthday
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Deathday"/> class.
        /// </summary>
        /// <param name="deathDay">string</param>
        public Deathday(string deathDay) : base(deathDay)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Deathday"/> class.
        /// </summary>
        /// <param name="deathDay">Deathday</param>
        public Deathday(DateTime deathDay) : base(deathDay)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Deathday"/> class.
        /// </summary>
        /// <param name="y">int</param>
        /// <param name="m">int</param>
        /// <param name="d">int</param>
        public Deathday(int y, int m, int d) : base(y, m, d)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Birthday"/>.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Date of death: {shortDateString}";
        }

        /// <summary>
        /// Tos the long date string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToLongDateString()
        {
            return $"Date of death: {longDateString}";
        }

    }
}

using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Race.
    /// </summary>
    [Serializable]
    public enum Race
    {
        /// <summary>
        /// White
        /// </summary>
        White,

        /// <summary>
        /// Black
        /// </summary>
        Black,

        /// <summary>
        /// Hispanic
        /// </summary>
        Hispanic,

        /// <summary>
        /// Asian
        /// </summary>
        Asian,

        /// <summary>
        /// Other
        /// </summary>
        Other,

        /// <summary>
        /// Unknown race.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Factory to generate race.
    /// </summary>
    public static class RaceFactory
    {
        private static readonly string[] AsianCountries = { "JP", "KR", "CH" };
        private static readonly string[] HispanicCountries = { "MX", "DO", "PR", "CU", "PA", "VE" };

        /// <summary>
        /// Gets the race of a player from text.
        /// </summary>
        /// <returns>Race</returns>
        /// <param name="text">string</param>
        public static Race GetRaceFromText(string text)
        {
            if(ArrayUtilities<string>.ArrayContains(text,AsianCountries))
            {
                return Race.Asian;
            }
            else if(ArrayUtilities<string>.ArrayContains(text, HispanicCountries))
            {
                return Race.Hispanic;
            }
            else
            {
                return Race.Other;
            }
        }

    }
}

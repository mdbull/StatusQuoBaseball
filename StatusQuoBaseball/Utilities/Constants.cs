using System;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Constants.
    /// </summary>
    public static class Constants
    {
       
        /// <summary>
        /// The months.
        /// </summary>
        public static readonly string[] MONTHS = { "January", "February", "March", "April", "May", "June","July","August","September","October","November","December" };

        /// <summary>
        /// The config file path.
        /// </summary>
        public static readonly string CONFIG_FILE_PATH = @"./config.config";

        /// <summary>
        /// The config file delimiter.
        /// </summary>
        public static readonly char CONFIG_FILE_DELIMITER = '=';

        /// <summary>
        /// The config file comment char.
        /// </summary>
        public static readonly char CONFIG_FILE_COMMENT_CHAR = '#';

        /// <summary>
        /// The SQLITE 3 connection string.
        /// </summary>
        public static readonly string SQLITE3_CONNECTION_STRING = @"Data Source=./Data/lahmansbaseballdb.db;Version=3";

       
        /// <summary>
        /// Rounds down.
        /// </summary>
        /// <returns>double</returns>
        /// <param name="number">double</param>
        /// <param name="decimalPlaces">int</param>
        public static double RoundDown(double number, int decimalPlaces)
        {
            return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
        }
        /// <summary>
        /// Scales the range to base 10.
        /// </summary>
        /// <returns>The range.</returns>
        /// <param name="value">Value.</param>
        public static int ScaleRange(double value)
        {
            if (value >= 100)
            {
                value /= 10;
            }

            return (int)value;
        }

        /// <summary>
        /// Gets the value from double.
        /// </summary>
        /// <returns>The value from double.</returns>
        /// <param name="val1">double</param>
        /// <param name="val2">double</param>
        public static int GetValueFromDouble(double val1, double val2)
        {
            double ret = 0;
            ret = (val1 / val2) * 100;

            return (int)ret;
        }

    }
}

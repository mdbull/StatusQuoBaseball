using System;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Utilities
{

    /// <summary>
    /// Class to hold historical FIP values.
    /// </summary>
    public static class SABRMetricsManager
    {
        private static InMemoryCSVFile theCSV;

        /// <summary>
        /// Init the specified filePath and hasHeaderRow.
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="hasHeaderRow">If set to <c>true</c> has header row.</param>
        public static void Init(string filePath, bool hasHeaderRow = true)
        {
            theCSV = InMemoryCSVFile.ReadCSVFile(filePath);

            for (int i = hasHeaderRow ? 1 : 0; i < theCSV.LineCount; i++)
            {
                theCSV = InMemoryCSVFile.ReadCSVFile(filePath);
            }
        }

        /// <summary>
        /// Gets the FIPC onstant by year.
        /// </summary>
        /// <returns>double</returns>
        /// <param name="year">int</param>
        public static double GetFIPConstantByYear(int year)
        {
            int index = DateTime.Now.Year - year;
            int fipColumnIndex = theCSV[index].Length - 1;
            return  Convert.ToDouble(theCSV[index][fipColumnIndex]);
        }

    }
}

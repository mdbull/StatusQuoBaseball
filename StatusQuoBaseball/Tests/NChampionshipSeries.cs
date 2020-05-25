using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Runtime;
using NUnit.Framework;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NArrayUtilities.
    /// </summary>
    [TestFixture]
    public class NChampionshipSeries
    {

        private static readonly int[] emptyYears = { 1891, 1892, 1893, 1894, 1895, 1896, 1897, 1898, 1899, 1900, 1901, 1902, 1904, 1994 };

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(ConfigurationManager.GetConfigurationValue("STORED_PROCEDURES_DIRECTORY"));
        }

        /// <summary>
        /// Tests the array contains.
        /// </summary>
        [Test]
        public void TestYears()
        {
            Db database = new Db(MainClass.conn);
          
            int startYear = 1884;
            int endYear = DateTime.Now.Year - 1;
           
            int iterations = 0;
            int passes = 0;
            List<int> yearsOmitted = new List<int>();
            for(int year=startYear; year <= endYear; year++ )
            {
                if (!emptyYears.Contains(year))
                {
                    try
                    {
                        SQLQueryResult result = DatabaseChampionshipSeriesLoader.GetSeriesInfo(year, database);
                        int results = result.DataTable.Rows.Count;
                        Console.WriteLine($"{year}: Result Rows={results}");
                        if (results > 0)
                            passes++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                    iterations++;
                }
                else
                {
                    yearsOmitted.Add(year);
                }
            }
            Console.WriteLine($"Passed {passes}/{iterations}");
            Console.Write("Years omitted:");
            foreach (int year in yearsOmitted)
            {
                Console.Write($" {year}");
            }
            Console.WriteLine();
            Assert.IsTrue(passes==iterations);
            Assert.IsTrue(yearsOmitted.Count == emptyYears.Length);
        }
    }
}

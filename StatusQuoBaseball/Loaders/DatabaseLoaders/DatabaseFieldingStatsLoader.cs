using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Loaders.DatabaseLoaders
{
    /// <summary>
    /// Database FieldingStats stats loader.
    /// </summary>
    public class DatabaseFieldingStatsLoader : DatabaseGameStatsLoader
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseFieldingStatsLoader"/> class.
        /// NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.
        /// </summary>
        /// <remarks> DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.</remarks>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        /// <param name="dataTable">DataTable</param>
        public DatabaseFieldingStatsLoader(Db database, string sql, DataTable dataTable) : base(database, sql, dataTable)
        {
        }

        /// <summary>
        /// Returns FieldingStats[] arrau as an object.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            return LoadStatsFromDatabase(this.dataTable);
        }

        /// <summary>
        /// Loads FieldingStats[] array from database.
        /// </summary>
        /// <returns>GameStats[]</returns>
        /// <param name="dataTable">DataTable</param>
        protected override GameStats[] LoadStatsFromDatabase(DataTable dataTable)
        {
            //Players can have multiple rows if they play several positions
            List<FieldingStats> fieldingStats = new List<FieldingStats>();

            try
            {
                foreach (DataRow row in this.dataTable.Rows)
                {
                    FieldingStats fStats = null;
                    string name = String.Concat(row["nameFirst"].ToString(), " ", row["nameLast"].ToString());
                    int putOuts = Convert.ToInt32(row["PO"]);
                    int assists = Convert.ToInt32(row["A"]);
                    int errors = Convert.ToInt32(row["E"]);
                    int totalChances = putOuts + assists + errors;

                    int fieldingRating = 0;
                    int groundballError = 0;
                    int flyoutError = 0;

                    if (totalChances >= 10)
                    {
                        putOuts = Convert.ToInt32(row["PO"]);
                        assists = Convert.ToInt32(row["A"]);
                        fieldingRating = Constants.GetValueFromDouble(putOuts + assists, totalChances);
                        groundballError = Constants.GetValueFromDouble(errors, totalChances);
                        if (groundballError == 0)
                            groundballError = 1;
                        flyoutError = Constants.GetValueFromDouble(errors, totalChances);
                        if (flyoutError == 0)
                            flyoutError = 1;

                    }
                    else//Generate stats
                    {
                        fieldingRating = Dice.Roll(90, 100);
                        groundballError = 100 - fieldingRating;
                        flyoutError = 100 - fieldingRating;
                    }
                    fStats = new FieldingStats(fieldingRating, groundballError, flyoutError);
                    fStats.NaturalPosition = row["POS"].ToString();
                    fStats.Name = name;
                    //Determine arm strength for Catchers
                    if (fStats.NaturalPosition == "C")
                    {
                        try
                        {
                            fStats.ArmStrength = (int)Constants.GetValueFromDouble(Convert.ToInt32(row["SB"]), (Convert.ToInt32(row["SB"]) + Convert.ToInt32(row["CS"])));
                            if (fStats.ArmStrength < 0)
                                fStats.ArmStrength = Convert.ToInt32(ConfigurationManager.GetConfigurationValue("DEFAULT_CATCHER_ARM_STRENGTH"));
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            fStats.ArmStrength = Convert.ToInt32(ConfigurationManager.GetConfigurationValue("DEFAULT_CATCHER_ARM_STRENGTH"));
                        }
                    }
                    else if (fStats.NaturalPosition == "P")
                    {
                        fStats.ArmStrength = Convert.ToInt32(ConfigurationManager.GetConfigurationValue("DEFAULT_PITCHER_ARM_STRENGTH")); ;
                    }
                    else
                    {
                        fStats.ArmStrength = Convert.ToInt32(ConfigurationManager.GetConfigurationValue("DEFAULT_FIELDER_ARM_STRENGTH")); ;
                    }
                    fieldingStats.Add(fStats);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                fieldingStats.Add(new FieldingStats(98, 5, 5, 75));
            }
            return fieldingStats.ToArray();
        }
    }
}

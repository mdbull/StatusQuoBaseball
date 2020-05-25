using System;
using System.Data;
using System.Collections.Generic;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Database coaching awards loader.
    /// </summary>
    public class DatabaseCoachingAwardsLoader : DatabasePersonLoader
    {
        /// <summary>
        /// Helper class to load a coach/manager from a database.
        /// </summary>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        public DatabaseCoachingAwardsLoader(Db database, string sql) : base(string.Empty, 0, database, sql)
        {
            SQLQueryResult result = database.ExecuteQuery(this.sql);

            if (result.DataTable.Rows.Count >= 0)//should only be one result
            {
                this.dataRows = result.DataTable.Rows;
            }
        }

        /// <summary>
        /// Load this instance.
        /// </summary>
        /// <remarks>Returns a string array of awards (if any)</remarks>
        /// <returns>object</returns>
        public override object Load()
        {
            List<string> awards = new List<string>();
            for (int i = 0; i < this.dataRows.Count; i++)
            {

                try
                {
                    DataRow theRow = this.dataRows[i];
                    awards.Add($"{theRow["yearID"].ToString()} {theRow["awardID"].ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return awards.ToArray();
        }
    }
}

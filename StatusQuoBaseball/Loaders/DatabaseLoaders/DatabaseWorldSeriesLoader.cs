using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball.Loaders.DatabaseLoaders
{
    /// <summary>
    /// Database world series loader.
    /// </summary>
    public static class DatabaseWorldSeriesLoader
    {
        /// <summary>
        /// Gets two teamkeys of a particular world series, based on the year provided.
        /// </summary>
        /// <returns>Tuple(string,string)</returns>
        /// <param name="year">int.</param>
        /// <param name="database">Db</param>
        public static Tuple<string,string> GetWorldSeriesTeams(int year, Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetWorldSeriesTeams");
            sp.Parameters = new object[] {year};
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            string roadTeamKey = result.DataTable.Rows[0][1].ToString();
            string homeTeamKey = result.DataTable.Rows[0][2].ToString();

            return new Tuple<string, string>(roadTeamKey, homeTeamKey);
        }

    }
}

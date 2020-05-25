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
    public static class DatabaseChampionshipSeriesLoader
    {
        /// <summary>
        /// Gets the series info.
        /// </summary>
        /// <returns>SQLQueryResult</returns>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        public static SQLQueryResult GetSeriesInfo(int year, Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetChampionshipSeriesInfo");
            sp.Parameters = new object[] { year };
            return database.ExecuteQuery(sp.Text);
        }

        /// <summary>
        /// Gets the series teams.
        /// </summary>
        /// <returns>Tuple(string,string)</returns>
        /// <param name="year">int</param>
        /// <param name="round">string</param>
        /// <param name="database">Db</param>
        public static Tuple<string, string> GetSeriesTeams(int year, string round, Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetChampionshipSeriesTeams");
            sp.Parameters = new object[] { year, round };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            string roadTeamKey = result.DataTable.Rows[0][2].ToString();
            string homeTeamKey = result.DataTable.Rows[0][3].ToString();

            return new Tuple<string, string>(roadTeamKey, homeTeamKey);
        }
    }
}

using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Loaders.DatabaseLoaders;

namespace StatusQuoBaseball.Loaders.DatabaseLoaders
{
    /// <summary>
    /// Database team group loader.
    /// </summary>
    public static class DatabaseGroupLoader
    {
        /// <summary>
        /// Loads the team group.
        /// </summary>
        /// <returns>TeamGroup</returns>
        /// <param name="leagueName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        /// <param name="seriesLength">int</param>
        public static TeamGroupTree LoadRoot(string leagueName, int year, Db database, int seriesLength=3)
        {
            TeamGroupTree league = null;
            Dictionary<string, TeamGroup> divisions = new Dictionary<string, TeamGroup>();

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetDivisionInfo");
            sp.Parameters = new object[] { leagueName, year };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            DataTable teamGroupInfo = result.DataTable;
            string leagueID = teamGroupInfo.Rows[0]["lgID"].ToString();
            foreach (DataRow row in teamGroupInfo.Rows)
            {
                string teamID = row["teamID"].ToString();
                string teamName = row["name"].ToString();
                string divID = row["divID"].ToString();
                TeamGroup group = null;
                Team team = null;

                team = DatabaseTeamLoader.LoadTeam(teamName, year, database);
                if (!divisions.ContainsKey(divID))
                {
                    group = new TeamGroup(divID, divID);
                    divisions.Add(divID, group);
                    if (!group.Contains(team))
                        group.Add(team);
                }
                else
                {
                    divisions[divID].Add(team);
                }
                Console.WriteLine($"Added {team} to division '{divID}'");
                System.Threading.Thread.Sleep(150);
             
            }
            league = new TeamGroupTree(leagueID, leagueName,seriesLength);

            foreach (TeamGroup division in divisions.Values)
            {
                league.Add(division);
                Console.WriteLine($"Added division '{division.Name}' to league '{league.Name}'");
                System.Threading.Thread.Sleep(150);
            }

            return league;
        }

       
    }
}

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

namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Team loader.
    /// </summary>
    public static class DatabaseTeamLoader
    {
        /// <summary>
        /// Gets the multiple keys.
        /// </summary>
        /// <returns>The multiple keys.</returns>
        /// <param name="searchTerm">Search term.</param>
        /// <param name="year">Year.</param>
        /// <param name="database">Database.</param>
        public static Dictionary<string,string> GetMultipleKeys(string searchTerm, int year, Db database)
        {
            Dictionary<string, string> retKeys = new Dictionary<string, string>();

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetFranchiseID");
            sp.Parameters = new object[] { searchTerm, year };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            foreach(DataRow row in result.DataTable.Rows)
            {
                retKeys.Add(row[0].ToString(), row[1].ToString());
            }
            return retKeys;
        }

        
        /// <summary>
        /// Loads the team from franchise identifier.
        /// </summary>
        /// <returns>The team from franchise identifier.</returns>
        /// <param name="franchID">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        public static Team LoadTeamFromFranchiseID(string franchID, int year, Db database)
        {
            SQLStoredProcedure sp2 = StoredProcedureManager.Get("GetTeamIDFromFranchID");
            sp2.Parameters = new object[] { franchID, year };
            SQLQueryResult result2 = database.ExecuteQuery(sp2.Text);
            string teamKey = result2.DataTable.Rows[0][0].ToString();

            string [] franchiseName = result2.DataTable.Rows[0][1].ToString().Split(' ');
            ValueTuple<string, string> parts = Team.GetTeamNameParts(franchiseName);
            string teamName = parts.Item1;
            string teamMascot = parts.Item2;

            Team team = new Team(teamName, teamMascot, year);
            Roster roster = null;
            Coach coach = null;

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            try
            {
                roster = LoadRosterFromDatabase(team, teamKey, year, database);
                team.Roster = roster;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            //Load manager/coach
            try
            {
                coach = LoadCoachFromDatabase(teamKey, year, database);
                team.Coach = coach;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return team;
        }


        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="searchTerm">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        public static Team LoadTeamFromTeamID(string searchTerm, int year, Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetFranchiseIDFromTeamID");
            sp.Parameters = new object[] { searchTerm};
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            string franchKey = result.DataTable.Rows[0][0].ToString();

            SQLStoredProcedure sp2 = StoredProcedureManager.Get("GetFranchiseInfo");
            sp2.Parameters = new object[] { franchKey };
            SQLQueryResult result2 = database.ExecuteQuery(sp2.Text);
            string []franchiseName = result2.DataTable.Rows[0][1].ToString().Split(' ');
            ValueTuple<string, string> parts = Team.GetTeamNameParts(franchiseName);
            string teamName = parts.Item1;
            string teamMascot = parts.Item2;

            Team team = new Team(teamName, teamMascot, year);
            Roster roster = null;
            Coach coach = null;

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            try
            {
                roster = LoadRosterFromDatabase(team, searchTerm, year, database);
                team.Roster = roster;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Load manager/coach
            try
            {
                coach = LoadCoachFromDatabase(searchTerm, year, database);
                team.Coach = coach;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return team;
        }

        #region Obsolete Functions
        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="teamName">string</param>
        /// <param name="mascot">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        [Obsolete("Method is deprecated, please use LoadTeamFromTeamID or LoadTeamFromFranchiseID instead.")]
        public static Team LoadTeam(string teamName, string mascot, int year, Db database)
        {
            Team team = new Team(teamName, mascot, year);
            Roster roster = null;
            Coach coach = null;

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetTeamID");
            sp.Parameters = new object[] { String.Concat(teamName, " ", mascot), year };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            string teamKey = result.DataTable.Rows[0][0].ToString();

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            try
            {
                roster = LoadRosterFromDatabase(team, teamKey, year, database);
                team.Roster = roster;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Load manager/coach
            coach = LoadCoachFromDatabase(teamKey, year, database);
            team.Coach = coach;

            return team;
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        [Obsolete("Method is deprecated, please use LoadTeamFromTeamID or LoadTeamFromFranchiseID instead.")]
        public static Team LoadTeam(string teamName, int year, Db database)
        {
            Team team = null;
            Roster roster = null;
            Coach coach = null;

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetTeamID");
            sp.Parameters = new object[] { teamName, year };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            string teamKey = result.DataTable.Rows[0][0].ToString();

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            roster = LoadRosterFromDatabase(team, teamKey, year, database);

            string teamMascot = string.Empty;
            team = new Team(teamName, teamMascot, year);
            team.Roster = roster;

            //Load manager/coach
            coach = LoadCoachFromDatabase(teamKey, year, database);
            team.Coach = coach;

            return team;
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="teamName">string</param>
        /// <param name="mascot">string</param>
        /// <param name="teamKey">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        [Obsolete("Method is deprecated, please use LoadTeamFromTeamID or LoadTeamFromFranchiseID instead.")]
        public static Team LoadTeam(string teamName, string mascot, string teamKey, int year, Db database)
        {
            Team team = new Team(teamName, mascot, year);
            Roster roster = null;
            Coach coach = null;

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            roster = LoadRosterFromDatabase(team, teamKey, year, database);
            team.Roster = roster;

            //Load manager/coach
            coach = LoadCoachFromDatabase(teamKey, year, database);
            team.Coach = coach;

            //TODO: Load uniforms
            // LoadUniforms(ref roster, directory);


            return team;
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="teamKey">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        [Obsolete("Method is deprecated, please use LoadTeamFromTeamID or LoadTeamFromFranchiseID instead.")]
        public static Team LoadTeamByKey(string teamKey, int year, Db database)
        {

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetTeamIDFromFranchiseID");
            sp.Parameters = new object[] { teamKey };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);

            string[] franchiseName = result.DataTable.Rows[0][1].ToString().Split(' ');
            ValueTuple<string, string> parts = Team.GetTeamNameParts(franchiseName);
            string teamName = parts.Item1;
            string teamMascot = parts.Item2;

            Team team = new Team(teamName, teamMascot, year);
            Roster roster = null;
            Coach coach = null;

            //Load roster
            //Batting, Pitching, and Fielding stats are loading with the roster
            roster = LoadRosterFromDatabase(team, teamKey, year, database);
            team.Roster = roster;

            //Load manager/coach
            coach = LoadCoachFromDatabase(teamKey, year, database);
            team.Coach = coach;

            //TODO: Load uniforms
            // LoadUniforms(ref roster, directory);

            return team;
        }
        #endregion


        /// <summary>
        /// Loads the coach from database.
        /// </summary>
        /// <returns>Coach</returns>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        private static Coach LoadCoachFromDatabase(string teamName, int year,Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetCoachInfo");
            sp.Parameters = new object[] { teamName, year };
            return (Coach)new DatabaseCoachLoader(teamName, year, database, sp.Text).Load();
        }

        /// <summary>
        /// Loads the roster from database.
        /// </summary>
        /// <returns>Roster</returns>
        /// <param name="team">Team</param>
        /// <param name="teamKey">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        private static Roster LoadRosterFromDatabase(Team team, string teamKey, int year, Db database)
        {
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetPlayerInfo");
            sp.Parameters = new object[] { teamKey, year };
            return new Roster(team, (Player[])new DatabaseRosterLoader(teamKey, year, database, sp.Text).Load());
        }

    }

}


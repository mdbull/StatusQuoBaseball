using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Loaders
{

    /// <summary>
    /// Coach loader.
    /// </summary>
    public class DatabaseCoachLoader : DatabasePersonLoader
    {
        /// <summary>
        /// Helper class to load a coach/manager from a database.
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        public DatabaseCoachLoader(string teamName, int year, Db database, string sql) : base(teamName, year, database,sql)
        {

        }

        /// <summary>
        /// Load a coach from a database
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            PersonBasicInformation [] coachBasicInfo = (PersonBasicInformation[])new DatabasePersonLoader(this.teamName, this.year, this.database, this.sql).Load();

            SQLStoredProcedure sp = StoredProcedureManager.Get("GetCoachAwards");
            sp.Parameters = new object[] { coachBasicInfo[0].Id };
            string[] awards = (string[])new DatabaseCoachingAwardsLoader(database, sp.Text).Load();
            Coach ret = null;


            ret = new Coach(coachBasicInfo[0],awards);
            DataTable dt = this.database.ExecuteQuery(this.sql).DataTable;
            SQLStoredProcedure spGetTeamCount = StoredProcedureManager.Get("GetTeamCountByYear");
            spGetTeamCount.Parameters = new object[] { this.year };
            DataTable dtTeamCount = this.database.ExecuteQuery(spGetTeamCount).DataTable;
            int teamCount = Convert.ToInt32(dtTeamCount.Rows[0]["count"]);
            int teamRank = Convert.ToInt32(dt.Rows[0]["teamRank"]);
            int teamWins = Convert.ToInt32(dt.Rows[0]["W"]);
            int teamLosses = Convert.ToInt32(dt.Rows[0]["L"]);

            int rating = (int)(Constants.GetValueFromDouble(teamWins, teamWins + teamLosses)*1.5);
            if (rating > 100)
                rating = 100;
            int prestige = awards.Length * 30;
            prestige = prestige > 100 ? 100 : prestige;
            prestige = prestige == 0 ? rating / 2 : prestige;
            int substitutionThreshold = Dice.Roll(10, 30);
            int steal2nd = Dice.Roll(5, 10);
            int steal3rd = Dice.Roll(1, 7);
            int sacrificeBunt = Dice.Roll(1, 10);
            int intentionalWalk = Dice.Roll(5, 10);
            ret.CoachingStats = new CoachingStats(rating,prestige,steal2nd, steal3rd, sacrificeBunt, intentionalWalk, substitutionThreshold,teamWins,teamLosses);

            return ret;
        }
    }
}

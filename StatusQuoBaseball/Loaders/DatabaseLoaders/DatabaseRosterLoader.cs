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
    /// Database roster loader.
    /// </summary>
    public class DatabaseRosterLoader : DatabasePersonLoader
    {
        private Dictionary<string, DataTable> dataTables = new Dictionary<string, DataTable>();

        /// <summary>
        /// Helper class to load a roster from a database.
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        public DatabaseRosterLoader(string teamName, int year, Db database, string sql) : base(teamName, year, database, sql)
        {
            SQLStoredProcedure sql1 = StoredProcedureManager.Get("GetBattingInfo");
            sql1.Parameters = new object[] { teamName,year };
            SQLStoredProcedure sql2 = StoredProcedureManager.Get("GetPitchingInfo");
            sql2.Parameters = new object[] {teamName, year };
            SQLStoredProcedure sql3 = StoredProcedureManager.Get("GetFieldingInfo");
            sql3.Parameters = new object[] { teamName, year };
            this.dataTables = (Dictionary<string, DataTable>)new DatabasePlayerStatisticsLoader(this.teamName, this.year, database, string.Empty, sql1, sql2, sql3 ).Load();
        }



        /// <summary>
        /// Loads a roster of (Player[] objects from a database.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            //Steps to get info from Lahman database.
            //1. Load player basic info
            //2. Load batting info
            //3. Load pitching info
            //4. Load fielding info
            //5. Get Uniform from UniformsLoader
            //6. Find natural position

            List<Player> roster = new List<Player>();

            try
            {
                //Load base attributes (e.g, firstName, lastName, birthday from Db
                PersonBasicInformation[] playerBasicInfo = (PersonBasicInformation[])new DatabasePersonLoader(this.teamName, this.year, this.database, this.sql).Load();

                //Load player abilities
                BattingStats[] battingStats = (BattingStats[])new DatabaseBattingStatsLoader(null, string.Empty, this.dataTables["Batting"]).Load();
                PitchingStats[] pitchingStats = (PitchingStats[])new DatabasePitchingStatsLoader(null, string.Empty, this.dataTables["Pitching"]).Load();
                FieldingStats[] fieldingStats = (FieldingStats[])new DatabaseFieldingStatsLoader(null, string.Empty, this.dataTables["Fielding"]).Load();

                for (int i = 0; i < playerBasicInfo.Length; i++)
                {
                    //Create each player with base attributes
                    Player thePlayer = new Player(playerBasicInfo[i]);

                    foreach (BattingStats bStat in battingStats)
                    {
                        if (thePlayer.FullName.Equals(bStat.Name))
                        {
                            thePlayer.BattingStats = (BattingStats)bStat.Clone();
                            thePlayer.BattingStatistics = new BattingStatisticsContainer(thePlayer);
                            thePlayer.SeasonStatistics = new SeasonStatisticsContainer(thePlayer);
                            thePlayer.Stamina = bStat.Stamina;
                        }
                    }

                    foreach (FieldingStats fStat in fieldingStats)
                    {
                        if (thePlayer.FullName.Equals(fStat.Name))
                        {
                            if (!roster.Contains(thePlayer))
                            {
                                thePlayer.FieldingStats = (FieldingStats)fStat.Clone();
                                thePlayer.FieldingStatistics = new FieldingStatisticsContainer(thePlayer);
                                thePlayer.NaturalPosition = fStat.NaturalPosition;
                                thePlayer.CurrentPosition = thePlayer.NaturalPosition;
                                roster.Add(thePlayer);//add player in here to deal with players who have multiple positions
                            }
                        }
                    }

                    foreach (PitchingStats pStat in pitchingStats)
                    {
                        if (thePlayer.FullName.Equals(pStat.Name))
                        {
                            thePlayer.PitchingStats = (PitchingStats)pStat.Clone();
                            thePlayer.PitchingStatistics = new PitchingStatisticsContainer(thePlayer);
                            thePlayer.PitchingStats.PitchingStatistics.Person = thePlayer;
                            if(thePlayer.NaturalPosition=="P")
                                thePlayer.Stamina = pStat.Stamina;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return roster.ToArray();
        }

        /// <summary>
        /// Gets the data tables.
        /// </summary>
        /// <value>Dictionary</value>
        public Dictionary<string, DataTable> DataTables { get => dataTables; }

    }
}

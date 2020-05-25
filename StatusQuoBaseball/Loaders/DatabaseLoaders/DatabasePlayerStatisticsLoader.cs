using NUnit.Framework;
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
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Loaders
{

    /// <summary>
    /// Helper clas to get player and manager information from files or a database.
    /// </summary>
    public class DatabasePlayerStatisticsLoader : StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader
    {
        /// <summary>
        /// The name of the team.
        /// </summary>
        protected string teamName = string.Empty;

        /// <summary>
        /// The year.
        /// </summary>
        protected int year;

        /// <summary>
        /// The data tables.
        /// </summary>
        protected Dictionary<string, DataTable> dataTables;

        /// <summary>
        /// Loads categories of player statistics (batting, pitching, fielding)
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        /// <param name="storedProceduresToRun">SQLStoredProcedure[]</param>
        public DatabasePlayerStatisticsLoader(string teamName, int year, Db database, string sql, params SQLStoredProcedure [] storedProceduresToRun) : base(database, sql)
        {
            this.teamName = teamName;
            this.year = year;
            this.dataTables = new Dictionary<string, DataTable>();
            if (storedProceduresToRun!=null)
            {
                foreach(SQLStoredProcedure sp in storedProceduresToRun)
                {
                    SQLQueryResult result;
                    string key;
                    try
                    {
                        result = database.ExecuteQuery(sp.Text);
                        //remove GET and INFO from string and use as key, e.g. GetBattingInfo ==> Batting
                        key = sp.Name.Contains("Get") ? sp.Name.Replace("Get", "") : sp.Name;
                        key = key.Contains("Info") ? key.Replace("Info", "") : key;
                        if(!dataTables.ContainsKey(key))
                            dataTables.Add(key, result.DataTable);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        /// <value>string</value>
        public string TeamName { get => teamName; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>int</value>
        public int Year { get => year; }

        /// <summary>
        /// Returns a Dictionary(string,DataTable>)of lists with batting, pitching, and fielding information.
        /// This can be used to initialize a coach or a list of players.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            return dataTables;
        }
    }
}

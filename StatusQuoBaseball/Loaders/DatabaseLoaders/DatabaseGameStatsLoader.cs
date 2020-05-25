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
    /// Database game stats loader.
    /// </summary>
    public abstract class DatabaseGameStatsLoader : DatabaseLoader
    {
        /// <summary>
        /// The game stats.
        /// </summary>
        protected GameStats [] stats;

        /// <summary>
        /// The data table.
        /// </summary>
        protected DataTable dataTable;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader"/> class.
        /// </summary>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        /// <param name="dataTable">DataTable</param>
        protected DatabaseGameStatsLoader(Db database, string sql, DataTable dataTable) : base(database, sql)
        {
            this.dataTable = dataTable;

        }

        /// <summary>
        /// Loads the stats from database.
        /// </summary>
        /// <returns>GameStats</returns>
        /// <param name="dataTable">DataTable</param>
        protected abstract GameStats[] LoadStatsFromDatabase(DataTable dataTable);

    }
}

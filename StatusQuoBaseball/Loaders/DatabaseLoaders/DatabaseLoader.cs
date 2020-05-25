using System;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Loaders.DatabaseLoaders
{
    /// <summary>
    /// Database loader.
    /// </summary>
    public abstract class DatabaseLoader : ObjectLoader
    {
        /// <summary>
        /// The database.
        /// </summary>
        protected Db database;

        /// <summary>
        /// The sql.
        /// </summary>
        protected string sql = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Loaders.DatabaseLoader"/> class.
        /// </summary>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        protected DatabaseLoader(Db database, string sql)
        {
            this.database = database;
            this.sql = sql;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>Db</value>
        public Db Database { get => database; }

        /// <summary>
        /// Gets the sql query text.
        /// </summary>
        /// <value>string</value>
        public string Sql { get => sql; }


    }
}

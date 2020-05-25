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

namespace StatusQuoBaseball.Database
{
    /// <summary>
    /// SQL Statement result.
    /// </summary>
    public abstract class SQLStatementResult
    {
        /// <summary>
        /// The rows affected.
        /// </summary>
        protected int rowsAffected;

        /// <summary>
        /// The sql statement.
        /// </summary>
        protected string sqlStatement = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLStatementResult"/> class.
        /// </summary>
        /// <param name="rowsAffected">int</param>
        /// <param name="sqlStatement">string</param>
        protected SQLStatementResult(int rowsAffected, string sqlStatement)
        {
            this.rowsAffected = rowsAffected;
            this.sqlStatement = sqlStatement;
        }

        /// <summary>
        /// Gets the rows affected.
        /// </summary>
        /// <value>int</value>
        public int RowsAffected { get => rowsAffected; }

        /// <summary>
        /// Gets the sql statement.
        /// </summary>
        /// <value>string</value>
        public string SqlStatement { get => sqlStatement; }

    }


}

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
    /// SQL query result.
    /// </summary>
    public class SQLQueryResult:SQLStatementResult
    {
        private SQLDataTable dataTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLQueryResult"/> class.
        /// </summary>
        /// <param name="sqlStatement">string</param>
        ///<param name="dataTable">SQLDataTable</param>
        public SQLQueryResult(string sqlStatement, SQLDataTable dataTable):base(dataTable.Rows.Count,sqlStatement)
        {
            this.dataTable = dataTable;
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <value>SQLDataTable</value>
        public SQLDataTable DataTable { get => dataTable; }
    }
}

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
    /// SQL non query result.
    /// </summary>
    public class SQLNonQueryResult : SQLStatementResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLNonQueryResult"/> class.
        /// </summary>
        /// <param name="rowsAffected">int</param>
        /// <param name="sqlStatement">string</param>
        public SQLNonQueryResult(int rowsAffected, string sqlStatement) : base(rowsAffected, sqlStatement)
        {
        }
    }
}

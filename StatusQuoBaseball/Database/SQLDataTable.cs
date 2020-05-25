using System;
using System.IO;
using System.Data;
using System.Runtime.Serialization;
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
    /// SQL Data table.
    /// </summary>
    public class SQLDataTable : DataTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataTable"/> class.
        /// </summary>
        public SQLDataTable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataTable"/> class.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        public SQLDataTable(string tableName) : base(tableName)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataTable"/> class.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="tableNamespace">Table namespace.</param>
        public SQLDataTable(string tableName, string tableNamespace) : base(tableName, tableNamespace)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataTable"/> class.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        protected SQLDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// Load the specified reader, loadOption and errorHandler.
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <param name="tableName">string</param>
        public SQLDataTable LoadWithoutConstraints(IDataReader reader,string tableName)
        {
            SQLDataTable temp = new SQLDataTable();
            using (DataSet ds = new DataSet() { EnforceConstraints = false })
            {
                ds.Tables.Add(temp);
                temp.Load(reader,LoadOption.OverwriteChanges);
                ds.Tables.Remove(temp);
                temp.TableName = tableName;
            }
            return temp;
        }
    }
}

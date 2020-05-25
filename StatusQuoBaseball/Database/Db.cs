using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Database
{
    /// <summary>
    /// Database.
    /// </summary>
    public class Db
    {
        private string _connection;
        private SqliteConnection conn;
        private bool isConnected;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.Database"/> class.
        /// </summary>
        /// <param name="connection">string</param>
        public Db(string connection)
        {
            _connection = connection;

            try
            {
                conn = new SqliteConnection(connection);
                conn.Open();
                isConnected = conn.State==ConnectionState.Open;
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executes the sql query and returns the number of rows.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="sql">string</param>
        public SQLQueryResult ExecuteQuery(string sql)
        {
            SqliteCommand command = new SqliteCommand(sql, conn);
            SQLDataTable dataTable = new SQLDataTable();
          
            SqliteDataReader sqliteDataReader = command.ExecuteReader();
            dataTable = new SQLDataTable("Result");
            dataTable = dataTable.LoadWithoutConstraints(sqliteDataReader,"Result");
            return new SQLQueryResult(sql, dataTable);
        }

        /// <summary>
        /// Executes a stored procedure.
        /// </summary>
        /// <returns>SQLQueryResult</returns>
        /// <param name="procedure">SQLStoredProcedure</param>
        public SQLQueryResult ExecuteQuery(SQLStoredProcedure procedure)
        {
            return ExecuteQuery(procedure.Text);
        }

        /// <summary>
        /// Close this instance.
        /// </summary>
        public void Close()
        {
            conn.Close();
            isConnected = isConnected = conn.State == ConnectionState.Closed;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>string</value>
        public string ConnectionString
        {
            get { return _connection; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Database.Database"/> is connected.
        /// </summary>
        /// <value><c>true</c> if is connected; otherwise, <c>false</c>.</value>
        public bool IsConnected { get => isConnected; }
    }
}

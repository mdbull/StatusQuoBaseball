using NUnit.Framework;
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

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NDatabase.
    /// </summary>
    [TestFixture]
    public class NDatabase
    {
        private string conn;

        private Db database; 

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            StoredProcedureManager.Init(@"./Data/StoredProcedures/");
            conn = Constants.SQLITE3_CONNECTION_STRING;
        }

        /// <summary>
        /// Tests the database connection.
        /// </summary>
        [Test]
        public void TestDatabaseConnection()
        {
            database = new Db(conn);
            Assert.IsTrue(database.IsConnected);
        }

        /// <summary>
        /// Tests the select pitchers.
        /// </summary>
        [Test]
        public void TestSelectPitchers()
        {
            string selectPitchers = @"SELECT playerID, nameFirst, nameLast, bats, throws, weight, height, birth_date
                    FROM people
                    WHERE playerID IN (
                       SELECT playerID 
                       FROM pitching
                       WHERE teamID='NYA' AND yearID=2001
                    );";

            int EXPECTED_ROWS = 20;
            database = new Db(conn);
            Assert.IsTrue(database.IsConnected);
            SQLQueryResult result = database.ExecuteQuery(selectPitchers);
            Assert.IsTrue(result.RowsAffected==EXPECTED_ROWS);
        }

        /// <summary>
        /// Tests the select batters.
        /// </summary>
        [Test]
        public void TestSelectBatters()
        {
            string selectBatters = @"SELECT playerID, nameFirst, nameLast, bats, throws, weight, height, birth_date
                    FROM people
                    WHERE playerID IN (
                       SELECT playerID 
                       FROM batting
                       WHERE teamID='NYA' AND yearID=2001
                    );";
            int EXPECTED_ROWS = 47;
            database = new Db(conn);
            Assert.IsTrue(database.IsConnected);
            SQLQueryResult result = database.ExecuteQuery(selectBatters);
            Assert.IsTrue(result.RowsAffected == EXPECTED_ROWS);
        }

        /// <summary>
        /// Tests the stored procedure text two parameters.
        /// </summary>
        [Test]
        public void TestStoredProcedureTextTwoParameters()
        {
            int EXPECTED_ROWS = 20;
            database = new Db(conn);
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetPitcherInfo");
            sp.Parameters = new object[] { "NYA", 2001 };
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            Assert.IsTrue(result.RowsAffected == EXPECTED_ROWS);
           
           
        }

        /// <summary>
        /// Tests the stored procedure multiple queries.
        /// </summary>
        [Test]
        public void TestStoredProcedureMultipleQueries()
        {
            int EXPECTED_ROWS = 47;
            database = new Db(conn);
            SQLStoredProcedure sp = StoredProcedureManager.Get("GetPlayerInfo");
            sp.Parameters = new object[] { "NYA", 2001};//two params but for instances of ? placeholder
            SQLQueryResult result = database.ExecuteQuery(sp.Text);
            Console.WriteLine(sp.Text);
            Assert.IsTrue(result.RowsAffected == EXPECTED_ROWS);
        }

        /// <summary>
        /// Tests the stored procedure parameter exception thrown.
        /// </summary>
        [Test]
        public void TestStoredProcedureParameterExceptionThrown()
        {

            database = new Db(conn);
            bool exceptionThrown = false;
            try
            {
                SQLStoredProcedure sp = StoredProcedureManager.Get("GetPlayerInfo");

                SQLQueryResult result = database.ExecuteQuery(sp.Text);

            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Assert.IsTrue(exceptionThrown);
            }

        }
    }
}

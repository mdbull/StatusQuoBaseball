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
    /// SQL data set.
    /// </summary>
    public class SQLDataSet:DataSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataSet"/> class.
        /// </summary>
        public SQLDataSet()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataSet"/> class.
        /// </summary>
        /// <param name="dataSetName">string</param>
        public SQLDataSet(string dataSetName) : base(dataSetName)
        {
        }
    }
}

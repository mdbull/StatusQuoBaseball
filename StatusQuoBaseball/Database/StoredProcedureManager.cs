using System;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Stored procedure manager.
    /// </summary>
    public static class StoredProcedureManager
    {
        private static Dictionary<string, SQLStoredProcedure> storedProcedures = new Dictionary<string, SQLStoredProcedure>();
       
        /// <summary>
        /// Init the specified directory.
        /// </summary>
        /// <param name="directory">string</param>
        public static void Init(string directory)
        {
            if (Directory.Exists(directory))
            {
                string[] filePaths = Directory.GetFiles(directory);
                foreach (string file in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string key = fileInfo.Name;
                    try
                    {
                        key = key.Substring(0, fileInfo.Name.Length - 4);
                        if (!storedProcedures.ContainsKey(key))
                        {
                            SQLStoredProcedure sp = new SQLStoredProcedure(file, key);
                            storedProcedures.Add(key, sp);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }


        /// <summary>
        /// Get the StoredProcedure.
        /// </summary>
        /// <returns>SQLStoredProcedure</returns>
        /// <param name="name">string</param>
        public static SQLStoredProcedure Get(string name)
        {
            return (SQLStoredProcedure)storedProcedures[name].Clone();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>int</value>
        public static int Count
        {
            get { return storedProcedures.Count; }
        }

    }
}
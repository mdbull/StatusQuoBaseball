using System;
using System.IO;
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
    /// Sqlite stored procedure.
    /// </summary>
    public class SQLStoredProcedure:ICloneable
    {
        string filePath = string.Empty;
        string name = string.Empty;
        string text = string.Empty;
        object[] parameters;

        /// <summary>
        /// Stored procedures end with .sql
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="name">string</param>
        public SQLStoredProcedure(string filePath, string name)
        {
            this.filePath = filePath;
            this.name = name;
            this.text = ReadSQLFromFile(filePath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLStoredProcedure"/> class.
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="parameters">object[]</param>
        public SQLStoredProcedure(string filePath, params object[] parameters)
        {
            this.filePath = filePath;
            this.parameters = parameters;
            this.text = AddParametersToSQLText(this.filePath, this.parameters);
        }

        /// <summary>
        /// Reads the SQLF rom file.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="path">string</param>
        private string ReadSQLFromFile(string path)
        {
            if (path.EndsWith(".sql", StringComparison.CurrentCulture) && File.Exists(path))
            {
                StringBuilder sb = new StringBuilder(new StreamReader(path).ReadToEnd());

                sb = sb.Replace('\n', ' ');
                sb = sb.Replace('\t', ' ');
                sb = sb.Replace("     ", " ");
                return sb.ToString();
            }
            else
            {
                throw new IOException($"File '{path}' was not found.");
            }
        }

        /// <summary>
        /// Adds the parameters to SQLStoredProcedure Text.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="path">string</param>
        /// <param name="queryParameters">object[]</param>
        private string AddParametersToSQLText(string path, params object[] queryParameters)
        {
            StringBuilder sb = new StringBuilder(ReadSQLFromFile(path));
            string exceptionMsg = "Incorrect parameter usage. Please ensure that the sql query take parameters and the parameters provided match.";

            //get indices. This is important because if there are four instances of '?', but only two parameters,
            //the function must reuse the two parameters provided
            int[] indices = TextUtilities.GetIndicesOfChar(sb.ToString(),'?');

            //If there are no instances of the ? placeholder or no params are provided, then notify user of error.
            if (indices.Length == 0 || parameters == null)
                throw new Exception(exceptionMsg);

            //check if the indices can be evenly divided by the params. EX: id, name, id, name / id, name
            if((indices.Length % parameters.Length !=0))
                throw new Exception(exceptionMsg);

            //NOTE: Must Replace ? with object value at specified index on EACH iteration
            //as the stringbuilder changes length with each replacement!

            int j = 0;
          
            for (int i = 0; i < indices.Length; i++)
            {
                string currentParameter = queryParameters[j++].ToString();
                int currentIndex = sb.ToString().IndexOf('?');//get the index of the first ? each time, because its place changes.

                try
                {
                    //For some reason, the replace logic collapsed on a shorter sql string, although both the long and short strings had the same parameters
                    //sb = sb.Replace("?", currentParameter, currentIndex, currentParameter.Length);
                    sb = sb.Insert(currentIndex, queryParameters[i]);
                    sb = sb.Remove(currentIndex + currentParameter.Length, 1);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

                //check to see if parameters need to be reused
                if (j > parameters.Length-1)
                {
                    j = 0;
                }
               
            }
            return sb.ToString();
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>string</value>
        public string Text { get => this.text; }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get => this.filePath; }

        /// <summary>
        /// Gets or sets the parameters of the SQLStoredProcedure.
        /// </summary>
        /// <value>object[]</value>
        public object[] Parameters 
        { 
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
                this.text = AddParametersToSQLText(this.filePath, parameters);
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Database.SqliteStoredProcedure"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Database.SqliteStoredProcedure"/>.</returns>
        public override string ToString()
        {
            return this.text;
        }

        /// <summary>
        /// Returns a clone of the SQLStoredProcedure. Otherwise, procedures in the StoredProcedureManager will have their parameters modified.
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
using NUnit.Framework;
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Loaders
{

    /// <summary>
    /// Helper clas to get player and manager information from files or a database.
    /// </summary>
    public class DatabasePersonLoader:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader
    {
        /// <summary>
        /// The name of the team.
        /// </summary>
        protected string teamName;

        /// <summary>
        /// The year of the team.
        /// </summary>
        protected int year;

        /// <summary>
        /// The data rows.
        /// </summary>
        protected DataRowCollection dataRows;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PersonLoader"/> class.
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="year">int</param>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        public DatabasePersonLoader(string teamName, int year, Db database, string sql) : base(database, sql)
        {
            this.teamName = teamName;
            this.year = year;

           
            SQLQueryResult result = database.ExecuteQuery(this.sql);

            if (result.DataTable.Rows.Count >= 0)//should only be one result
            {
                this.dataRows = result.DataTable.Rows;
            }
        }

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        /// <value>string</value>
        public string TeamName { get => teamName; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>int</value>
        public int Year { get => year; }

        /// <summary>
        /// Returns a PersonBasicInformation array.
        /// This can be used to initialize a coach or a list of players.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            List<PersonBasicInformation> information = new List<PersonBasicInformation>();


            for (int i = 0; i < this.dataRows.Count; i++)
            {

                try
                {
                    DataRow theRow = this.dataRows[i];
                    string id = theRow["playerID"].ToString();
                    string lName = theRow["nameLast"].ToString();
                    string fName = theRow["nameFirst"].ToString();
                    string number = string.Empty;
                    string naturalPosition = string.Empty;
                    Race race = Race.Unknown;
                    //Some people may have null values
                    string handednessString = theRow["throws"]?.ToString() ?? "R";
                    Handedness handedness = ConvertTextToHandedness.ConvertFromText(handednessString);
                    string batsString = theRow["bats"]?.ToString() ?? "R";
                    Handedness bats = ConvertTextToHandedness.ConvertFromText(batsString);
                    Height height = Height.Default;
                    if (theRow["height"].ToString().Length > 0)
                        height = new Height(Convert.ToInt32(theRow["height"].ToString()));
                    Weight weight = Weight.Default;
                    if (theRow["weight"].ToString().Length > 0)
                        weight = new Weight(Convert.ToInt32(theRow["weight"].ToString()));

                    Birthday birthday = Birthday.Default;
                    if (theRow["birth_date"].ToString().Length > 0)
                        birthday = new Birthday(Convert.ToDateTime(theRow["birth_date"].ToString()));

                    Deathday deathDate = null;
                    if (theRow["death_date"]!=null && theRow["death_date"].ToString().Length > 0)
                        deathDate = new Deathday(Convert.ToDateTime(theRow["death_date"].ToString()));
                    PersonBasicInformation info = new PersonBasicInformation(id, lName, fName, number, naturalPosition, race, handedness, bats, height, weight, birthday,deathDate);
                    information.Add(info);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            return information.ToArray();
        }
    }
}

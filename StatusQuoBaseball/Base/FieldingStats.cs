using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Fielding stats.
    /// </summary>
    public class FieldingStats:GameStats
    {
        private int groundballError;
        private int flyoutError;
        private int armStrength;
        private int fieldingRating;
        private string name = string.Empty;
        private string naturalPosition = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.FieldingStats"/> class.
        /// </summary>
        /// <param name="fieldingRating">Fielding rating.</param>
        /// <param name="groundballError">Groundball error.</param>
        /// <param name="flyoutError">Flyout error.</param>
        /// <param name="armStrength">Arm strength.</param>
        public FieldingStats(int fieldingRating, int groundballError, int flyoutError, int armStrength=80)
        {
            this.fieldingRating = fieldingRating;
            this.groundballError = groundballError;
            this.flyoutError = flyoutError;
            this.armStrength = armStrength;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Loads the fielding stats.
        /// </summary>
        /// <returns>The fielding stats.</returns>
        /// <param name="filePath">File path.</param>
        public static FieldingStats[] LoadFieldingStats(string filePath)
        {
            Dictionary<int, Dictionary<string, object>> data = new Dictionary<int, Dictionary<string, object>>();
            //1. read file
            if (File.Exists(filePath))
            {
                int count = 0;
                StreamReader handle = new StreamReader(filePath);
                //read header row first and load keys into dictionary
                string[] headerLine = handle.ReadLine().Split(Convert.ToChar(Int32.Parse(Configuration.ConfigurationManager.GetConfigurationValue("DELIMETER"))));
                while (!handle.EndOfStream)
                {
                    string[] dataLine = handle.ReadLine().Split(Convert.ToChar(Int32.Parse(Configuration.ConfigurationManager.GetConfigurationValue("DELIMETER"))));
                    data.Add(++count, new Dictionary<string, object>());
                    for (int i = 0; i < dataLine.Length; i++)
                    {
                       data[count].Add(headerLine[i], dataLine[i]);

                    }
                }
                return LoadFieldingStats(data);
            }

            return null;
        }

        /// <summary>
        /// Loads the fielding stats.
        /// </summary>
        /// <returns>FieldingStats[]</returns>
        /// <param name="data">Dictionary</param>
        private static FieldingStats[] LoadFieldingStats(Dictionary<int, Dictionary<string, object>> data)
        {
            List<FieldingStats> fieldingStats = new List<FieldingStats>();
            Dictionary<int, Dictionary<string, object>> theData = data;
            Dictionary<int, Dictionary<string, object>>.Enumerator cursor1 = theData.GetEnumerator();
            while (cursor1.MoveNext())
            {
                Dictionary<string, object> playerStats = cursor1.Current.Value;
                Dictionary<string, object>.Enumerator cursor2 = playerStats.GetEnumerator();
                while (cursor2.MoveNext())
                {
                    string name = string.Empty;
                    int chances = 0;
                    try
                    {
                        //Name Age G GS  CG Inn Ch PO  A E   DP Fld% Rtot    Rtot / yr RF / 9    RF / G    PB WP  SB CS  CS % lgCS % PO  Pos Summary
                        //Brian Anderson  29  29  22  1   133.1   43  9   32  2   2   .953            2.77    1.41        2   7   5   42 % 33 % 7   P
                        FieldingStats stats = null;
                        name = (string)playerStats["Name"];
                        int putOuts = 0;
                        int assists = 0;
                        int fieldingRating = 0;
                        int groundballError = 0;
                        int flyoutError = 0;
                        chances = Convert.ToInt32(playerStats["Ch"]);
                        if (chances >= 10)
                        {
                            putOuts = Convert.ToInt32(playerStats["PO"]);
                            assists = Convert.ToInt32(playerStats["A"]);
                            fieldingRating = Constants.GetValueFromDouble(putOuts + assists, chances);
                            groundballError = 100 - fieldingRating;
                            flyoutError = 100 - fieldingRating;
                            //int armStrength = 0; //TODO: Figure out arm strength
                            stats = new FieldingStats(fieldingRating, groundballError, flyoutError);
                            stats.Name = name;
                            fieldingStats.Add(stats);
                            break;
                        }
                        else//Generate stats
                        {
                            fieldingRating = Dice.Roll(90, 100);
                            groundballError = 100 - fieldingRating;
                            flyoutError = 100 - fieldingRating;
                            stats = new FieldingStats(fieldingRating, groundballError, flyoutError);
                            stats.Name = name;
                            fieldingStats.Add(stats);
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return fieldingStats.ToArray();
        }

        /// <summary>
        /// Gets or sets the groundball error.
        /// </summary>
        /// <value>The groundball error.</value>
        public int GroundballError { get => groundballError; set => groundballError = value; }

        /// <summary>
        /// Gets or sets the flyout error.
        /// </summary>
        /// <value>The flyout error.</value>
        public int FlyoutError { get => flyoutError; set => flyoutError = value; }

        /// <summary>
        /// Gets or sets the arm strength.
        /// </summary>
        /// <value>The arm strength.</value>
        public int ArmStrength { get => armStrength; set => armStrength = value; }

        /// <summary>
        /// Gets the fielding rating.
        /// </summary>
        /// <value>The fielding rating.</value>
        public int FieldingRating { get => fieldingRating;}

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the natural position of the fielder.
        /// <remark>This field was needed to retrieve position info from the Lahman database.</remark>
        /// </summary>
        /// <value>string</value>
        public string NaturalPosition { get => naturalPosition; set => naturalPosition = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.FieldingStats"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.FieldingStats"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine($"{this.name}");
            ret.AppendLine($"Fielding Rating {this.fieldingRating}");
            ret.AppendLine($"Arm Strength {this.armStrength}");
            ret.AppendLine($"Groundball Error {this.groundballError}, Flyout Error {this.flyoutError}");
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Ranges to string.
        /// </summary>
        protected override void RangeToString()
        {
            this.range = this.toString;
        }
    }
}

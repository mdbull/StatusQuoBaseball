using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Pitcher types.
    /// </summary>
    [Serializable]
    public enum PitcherTypes
    {
        /// <summary>
        /// Poor pitcher.
        /// </summary>
        Poor,
        /// <summary>
        /// Average Pitcher
        /// </summary>
        Average,
        /// <summary>
        /// Excellent Pitcher
        /// </summary>
        Excellent,
        /// <summary>
        /// Unhittable Pitcher
        /// </summary>
        Unhittable,
        /// <summary>
        /// Unknown Pitcher
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Pitching stats.
    /// </summary>
    public class PitchingStats : GameStats
    {
        private PitchingStatisticsContainer pitchingStatistics;

        private static PitchResults[] Results = { Base.PitchResults.Balk, Base.PitchResults.HBP, Base.PitchResults.BB, Base.PitchResults.K, Base.PitchResults.GO, Base.PitchResults.FO, Base.PitchResults.Single, Base.PitchResults.Double, Base.PitchResults.Triple, Base.PitchResults.HR };

        private int control;

        private int startPct;

        private int powerRating;

        private int currentControl; //this value will fluctuate throughout the game

        private PitchResults[] pitchResults;

        private Dictionary<string, PitchResults> pitchResultsRanges = new Dictionary<string, PitchResults>();

        private string name = string.Empty;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PitchingStats"/> class.
        /// </summary>
        /// <param name="startingControl">int</param>
        /// <param name="pitchResultData">int</param>
        public PitchingStats(int startingControl, params int[] pitchResultData)
        {
            this.control = startingControl;
            this.currentControl = this.control;
            /*Pitch results range when the pitcher maintains control
            [0] = Balk  1
            [1] = HBP   2-3
            [2] = BB    4-20
            [3] = K     21-50
            [4] = GO    51-70
            [5] = FO    71-80
            [6] = 1B    81-90
            [7] = 2B    91-97
            [8] = 3B    98
            [9] = HR    99-100
            */

            LoadPitchResultsRange(pitchResultData);
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            RangeToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Calculates the control rating for a pitcher.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="battersFaced">int</param>
        /// <param name="hits">int</param>
        /// <param name="wins">int</param>
        /// <param name="saves">int</param>
        public static int CalculateControl(int battersFaced, int hits, int wins, int saves)
        {
            int control = Constants.GetValueFromDouble((battersFaced - Convert.ToDouble(hits)), battersFaced);
            control += (int)(Math.Round(wins / 6M));//give a little bit more for pitchers with more wins
            control += (int)(Math.Round(saves / 5M));//give a little more for effective closers
            if (control > 100)
                control = 100;
            return control;
        }

        /// <summary>
        /// Calculates the stamina of the pitcher.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="startPct">double</param>
        /// <param name="wins">int</param>
        /// <param name="completeGames">int</param>
        /// <param name="totalGamesStarted">int</param>
        /// <param name="totalGamesPitched">int</param>
        /// <param name="inningsPitched">double</param>
        public static int CalculateStamina(double startPct,int wins,int completeGames, int totalGamesStarted, int totalGamesPitched, double inningsPitched)
        {
            int stamina = (int)(startPct * 0.10) + (wins * 4) + (completeGames * 3) + (int)(totalGamesStarted*1.25) + ((int)(totalGamesStarted/totalGamesPitched)*20) + (int)(totalGamesPitched/5)+(int)(inningsPitched / 5);
            if (stamina > 100)
                stamina = 99;
            return stamina;
        }
        /// <summary>
        /// Finds the first index of val.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="val">int</param>
        /// <param name="array">int[]</param>
        private int FindFirstIndexOf(int val, params int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Eachs the element is less.
        /// </summary>
        /// <returns><c>true</c>, if element is less was eached, <c>false</c> otherwise.</returns>
        /// <param name="array">int[]</param>
        private bool EachElementIsLess(params int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] >= array[i + 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Loads the pitch results range.
        /// </summary>
        /// <param name="pitchResultData">int[]</param>
        private void LoadPitchResultsRange(int[] pitchResultData)
        {
            int firstIndex100 = FindFirstIndexOf(100, pitchResultData);
            if (firstIndex100 != pitchResultData.Length - 1)
            {
                int indexDiff = pitchResultData.Length - firstIndex100;

                for (int i = firstIndex100 - indexDiff; i < pitchResultData.Length; i++)
                {
                    pitchResultData[i] -= pitchResultData.Length - i;
                    if (EachElementIsLess(pitchResultData))
                        break;
                }
                pitchResultData[pitchResultData.Length - 1] = 100;
            }
            List<PitchResults> ret = new List<PitchResults>();
            int bottomRange = 1;
            int topRange = 0;

            for (int i = 0; i < pitchResultData.Length; i++)
            {
                topRange = pitchResultData[i];
                int diff = (topRange - bottomRange) + 1;

                for (int j = 0; j < diff; j++)
                {
                    ret.Add(PitchingStats.Results[i]);
                }

                try
                {
                    if (diff == 1)
                    {
                        pitchResultsRanges.Add(String.Format("{0}", topRange), PitchingStats.Results[i]);
                    }
                    else
                    {
                        pitchResultsRanges.Add(String.Format("{0}-{1}", bottomRange, topRange), PitchingStats.Results[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                bottomRange = topRange + 1;
            }
            this.pitchResults = ret.ToArray();
        }

        /// <summary>
        /// Gets the power rating of the pitcher. This is based on strikeouts
        /// </summary>
        /// <value>int</value>
        public int PowerRating
        {
            get
            {
                if (this.powerRating == 0)
                {
                    int kCount = 0;
                    foreach (PitchResults res in this.pitchResults)
                    {
                        if (res is Base.PitchResults.K)
                            kCount++;
                    }
                    this.powerRating = (int)(kCount* 3.5);
                    if (this.powerRating > 100)
                        this.powerRating = 100;
                }
                return this.powerRating;
            }
        }
        /// <summary>
        /// Ranges to string.
        /// </summary>
        protected override void RangeToString()
        {
            StringBuilder ret = new StringBuilder();
            Dictionary<string, PitchResults>.Enumerator cursor = this.pitchResultsRanges.GetEnumerator();
            while (cursor.MoveNext())
                ret.AppendLine(cursor.Current.ToString());
            this.range = ret.ToString();
        }


        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>int</value>
        public int Control { get => control; }

        /// <summary>
        /// Gets the pitch results.
        /// </summary>
        /// <value>PitchResults[]</value>
        public PitchResults[] PitchResults { get => pitchResults; }

        /// <summary>
        /// Gets the pitch results ranges.
        /// </summary>
        /// <value>The pitch results ranges.</value>
        public Dictionary<string, PitchResults> PitchResultsRanges { get => pitchResultsRanges; }

        /// <summary>
        /// Gets or sets the name of the pitcher.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the current control.
        /// </summary>
        /// <value>int</value>
        public int CurrentControl { get => currentControl; set => currentControl = value; }

        /// <summary>
        /// Gets or sets the start pct.
        /// </summary>
        /// <value>int</value>
        public int StartPct { get => startPct; set => startPct = value; }

        /// <summary>
        /// Gets or sets the pitching statistics of the player for a given year.
        /// </summary>
        /// <value>PitchingStatisticsContainer</value>
        public PitchingStatisticsContainer PitchingStatistics { get => pitchingStatistics; set => pitchingStatistics = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStats"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStats"/>.</returns>
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
            ret.AppendLine($"Control {this.currentControl}");
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Generates the pitching stats.
        /// </summary>
        /// <returns>The pitching stats.</returns>
        /// <param name="pitcherType">Pitcher type.</param>
        public static PitchingStats GeneratePitchingStats(PitcherTypes pitcherType)
        {
            switch (pitcherType)
            {
                case PitcherTypes.Poor:
                    return new PitchingStats(Dice.Roll(40, 60), 2, 5, 35, 40, 45, 55, 70, 85, 90, 100);
                case PitcherTypes.Average:
                    return new PitchingStats(Dice.Roll(61, 75), 2, 5, 25, 35, 50, 65, 75, 90, 93, 100);
                case PitcherTypes.Excellent:
                    return new PitchingStats(Dice.Roll(85, 95), 1, 3, 20, 45, 65, 80, 90, 96, 98, 100);
                case PitcherTypes.Unhittable:
                    return new PitchingStats(Dice.Roll(96, 100), 1, 2, 10, 45, 55, 85, 95, 98, 99, 100);
                case PitcherTypes.Unknown:
                    return new PitchingStats(Dice.Roll(30, 70), 2, 5, 30, 40, 45, 55, 70, 90, 95, 100);
            }
            return null;
        }

        /// <summary>
        /// Loads the pitching stats.
        /// </summary>
        /// <returns>PitchingStats[]</returns>
        /// <param name="filePath">string</param>
        public static PitchingStats[] LoadPitchingStats(string filePath)
        {

            //Rk Pos Name Age W L   W - L % ERA G GS  GF CG  SHO SV  IP H   R ER  HR BB  IBB SO  HBP BK  WP BF  ERA + FIP WHIP H9  HR9 BB9 SO9 SO/ W
            //1   SP Curt Schilling  34  22  6   .786    2.98    35  35  0   6   1   0   256.2   237 86  85  37  39  0   293 1   0   4   1021    157 3.11    1.075   8.3 1.3 1.4 10.3    7.51
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
                return LoadPitchingStats(data);
            }

            return null;
        }

        /// <summary>
        /// Loads the pitching stats.
        /// </summary>
        /// <returns>PitchingStats[]</returns>
        /// <param name="data">Data</param>
        private static PitchingStats[] LoadPitchingStats(Dictionary<int, Dictionary<string, object>> data)
        {
            List<PitchingStats> pitchingStats = new List<PitchingStats>();
            Dictionary<int, Dictionary<string, object>> theData = data;
            Dictionary<int, Dictionary<string, object>>.Enumerator cursor1 = theData.GetEnumerator();
            while (cursor1.MoveNext())
            {
                Dictionary<string, object> playerStats = cursor1.Current.Value;
                Dictionary<string, object>.Enumerator cursor2 = playerStats.GetEnumerator();
                while (cursor2.MoveNext())
                {
                    try
                    {
                        //Rk Pos Name Age W L   W - L % ERA G GS  GF CG  SHO SV  IP H   R ER  HR BB  IBB SO  HBP BK  WP BF  ERA + FIP WHIP H9  HR9 BB9 SO9 SO/ W
                        //We won't use all the stats, but will have them handy if we ever expand the game

                        int battersFaced = (int)Convert.ToDouble(playerStats["BF"]);
                        int hits = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["H"]), battersFaced);
                        int control = Constants.GetValueFromDouble(battersFaced - Convert.ToDouble(playerStats["H"]), battersFaced);
                        if (control > 100)
                        {
                            control = 99;
                        }
                       
                        //int stamina = Convert.ToInt32(playerStats["GS"])*3;
                        //if (stamina > 100)
                        //stamina = 100;
                        int balks = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["BK"]), battersFaced);
                        if (balks == 0)
                            balks = 1;
                        int hitByPitch = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["HBP"]), battersFaced);
                        if (hitByPitch == 0)
                            hitByPitch = 1;
                        int walks = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["BB"]), battersFaced);
                        if (walks == 0)
                            walks = 1;

                        int strikeouts = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["SO"]), battersFaced);
                        if (strikeouts == 0)
                        {
                            strikeouts = 1;
                        }

                        int otherOuts = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["BF"]) - Convert.ToDouble(playerStats["H"]) - Convert.ToDouble(playerStats["BB"]) - Convert.ToDouble(playerStats["HBP"]) - Convert.ToDouble(playerStats["SO"]), Convert.ToDouble(playerStats["BF"]));
                        int groundOuts = (int)(otherOuts * 0.5);
                        if (groundOuts == 0)
                            groundOuts = 1;
                        int flyouts = (int)(otherOuts * 0.5);
                        if (flyouts == 0)
                            flyouts = 1;

                        int homeRuns = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["HR"]), battersFaced);
                        if (homeRuns == 0)
                            homeRuns = 1;

                        int otherHits = hits - homeRuns;

                        //since singles, doubles and triples are not given, we'll use a generic distribution
                        int singles = (int)(otherHits * 0.6); // singles will be 60% of other hits
                        if (singles == 0)
                            singles = 1;
                        int doubles = (int)(otherHits * 0.3);
                        if (doubles == 0)
                            doubles = 1;
                        int triples = (int)(otherHits * 0.1);
                        if (triples == 0)
                            triples = 1;

                        PitchingStats stats = LoadResultRanges(control, balks, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);
                        string name = (string)playerStats["Name"];
                        if (name.Contains("*") || name.Contains("#") || name.Contains("?"))
                            name = name.Remove(name.Length - 1);
                        stats.Name = name;
                        pitchingStats.Add(stats);
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return pitchingStats.ToArray();
        }

        /// <summary>
        /// Loads the result ranges.
        /// </summary>
        /// <returns>PitchingStats[]</returns>
        /// <param name="control">int</param>
        /// <param name="values">int[]</param>
        public static PitchingStats LoadResultRanges(int control, params int[] values)
        {
            //                  c   st  bk  hbp bb  k   go  fo  1B  2B  3B  HR
            //new PitchingStats(75, 60, 1,  4,  22, 58, 70, 80, 90, 97, 98, 100)
            int balks = values[0];
            int hitByPitch = balks + values[1];
            int walks = hitByPitch + values[2];
            int strikeouts = walks + values[3];
            int groundOuts = strikeouts + values[4];
            int flyouts = groundOuts + values[5];
            int singles = flyouts + values[6];
            int doubles = singles + values[7];
            int triples = doubles + values[8];
            if (triples >= 100)
                triples = 99;
            int homeRuns = 100;
            PitchingStats stats = new PitchingStats(control, balks, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);

            return stats;
        }
    }
}

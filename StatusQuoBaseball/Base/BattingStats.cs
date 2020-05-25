using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Batter types.
    /// </summary>
    [Serializable]
    public enum BatterTypes
    {
        /// <summary>
        /// Represents a poor batter.
        /// </summary>
        Poor,

        /// <summary>
        /// Represents an average batter.
        /// </summary>
        Average,

        /// <summary>
        /// Represents an excellent batter.
        /// </summary>
        Excellent,

        /// <summary>
        /// Represents an unknown batter type.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Batting stats.
    /// </summary>
    public sealed class BattingStats : GameStats
    {
        private BattingStatisticsContainer battingStatistics;
       
        private static BattingResults[] Results = { Base.BattingResults.HBP, Base.BattingResults.BB, Base.BattingResults.K, Base.BattingResults.GO, Base.BattingResults.FO, Base.BattingResults.Single, Base.BattingResults.Double, Base.BattingResults.Triple, Base.BattingResults.HR };

        private int batterRating;

        private int controlModifier;

        private int powerRating;

        private int speed;

        private int gamesPlayed;

        private string name = String.Empty;

        private BattingResults[] battingResults;

        private Dictionary<string, BattingResults> battingResultsRanges = new Dictionary<string, BattingResults>();

        /// <summary>
        /// Check if result is a hit.
        /// </summary>
        /// <returns><c>true</c>, if hit was ised, <c>false</c> otherwise.</returns>
        /// <param name="result">bool</param>
        public static bool IsHit(BattingResults result)
        {
            switch (result)
            {
                case (Base.BattingResults.Single):
                    return true;
                case (Base.BattingResults.Double):
                    return true;
                case (Base.BattingResults.Triple):
                    return true;
                case (Base.BattingResults.HR):
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if result is a hit.
        /// </summary>
        /// <returns><c>true</c>, if hit was ised, <c>false</c> otherwise.</returns>
        /// <param name="result">bool</param>
        public static bool IsHit(PitchResults result)
        {
            switch (result)
            {
                case (Base.PitchResults.Single):
                    return true;
                case (Base.PitchResults.Double):
                    return true;
                case (Base.PitchResults.Triple):
                    return true;
                case (Base.PitchResults.HR):
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Calculates the batter rating of a player
        /// </summary>
        /// <returns>int</returns>
        /// <param name="games">int</param>
        /// <param name="battingAverage">double</param>
        public static int CalculateBatterRating(int games, double battingAverage)
        {
            double f = Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RATING_FACTOR"));
            int rating = (int)((battingAverage * 100.0) * f);
            if (games < 100)//make sure real-life starters also start in the game if simulation mode is complete
            {
                double playingTimeAdjustment = (double)games / 162.0;
                rating = (int)(rating * playingTimeAdjustment);
            }
            if (rating > 100)
                rating = 100;
            return rating;
        }

        /// <summary>
        /// Calculates the control rating.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="games">int</param>
        /// <param name="batterRating">int</param>
        public static int CalculateControlModifier(int games, int batterRating)
        {
            int br= (int)(batterRating/ Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_CONTROL_MODIFIER_FACTOR")));
            double playingTimeAdjustment = (double)games / 162.0;//don't want guys who played 5 games and batted .500 starting!!!
            return (int)(br * playingTimeAdjustment);
        }

        /// <summary>
        /// Calculates the speed of a player.
        /// </summary>
        /// <returns>The speed.</returns>
        /// <param name="stolenBases">Stolen bases.</param>
        /// <param name="stealAttempts">Steal attempts.</param>
        public static int CalculateSpeed(int stolenBases, int stealAttempts)
        {
            int speed = 0;
            double speedModifier = 0.0;
            if (stealAttempts >=5)//make sure this player is the real deal
            {
                //speed = stolenBases;
                //int speedModifier = (Constants.GetValueFromDouble(stolenBases, stealAttempts) / 30);
                speed = Constants.GetValueFromDouble(stolenBases, stealAttempts);
                speedModifier = (double)stolenBases / 50.0;
                if (speedModifier < 1)
                    speedModifier = 1;
                speed = (int)(speed * speedModifier);
            }
            else
            {
                speed = Dice.Roll(25, 50);
            }

            if (speed < 25)
                speed = 25;
            if (speed > 100)
                speed = 100;
            return speed;
        }

        /// <summary>
        /// Calculates the stamina.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="gamesPlayed">int</param>
        public static int CalculateStamina(int gamesPlayed)
        {
            return Convert.ToInt32(gamesPlayed / Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_STAMINA_FACTOR")));

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.BattingStats"/> class.
        /// </summary>
        /// <param name="controlModifier">int</param>
        /// <param name="playerSpeed">int</param>
        /// <param name="battingResultData">int</param>
        public BattingStats(int controlModifier, int playerSpeed = 80, params int[] battingResultData)
        {
            this.controlModifier = controlModifier;
            this.speed = playerSpeed;
            /*Batting results range when the battinger maintains control

            [0] = HBP   1
            [1] = BB    2-20
            [2] = K     21-30
            [3] = GO    31-50
            [4] = FO    51-70
            [5] = 1B    71-80
            [6] = 2B    81-90
            [7] = 3B    91
            [8] = HR    92-100
            */

            LoadBattingResultsRange(battingResultData);
            CalculatePowerRating(battingResultData);
            BuildToString();
            RangeToString();
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
        /// Loads the batting results range.
        /// </summary>
        /// <param name="battingResultData">BattingResults[]</param>
        private void LoadBattingResultsRange(int[] battingResultData)
        {
            int firstIndex100 = FindFirstIndexOf(100, battingResultData);
            if (firstIndex100 != battingResultData.Length - 1)
            {
                int indexDiff = battingResultData.Length - firstIndex100;

                for (int i = firstIndex100 - indexDiff; i < battingResultData.Length; i++)
                {
                    battingResultData[i] -= battingResultData.Length - i;
                    if (EachElementIsLess(battingResultData))
                        break;
                }
                battingResultData[battingResultData.Length - 1] = 100;
            }
            List<BattingResults> ret = new List<BattingResults>();
            int bottomRange = 1;
            int topRange = 0;

            for (int i = 0; i < battingResultData.Length; i++)
            {

                try
                {
                    topRange = battingResultData[i];
                    int diff = (topRange - bottomRange) + 1;

                    for (int j = 0; j < diff; j++)
                    {
                        ret.Add(BattingStats.Results[i]);
                    }

                    if (diff == 1)
                    {
                        this.battingResultsRanges.Add(String.Format($"{topRange}"), BattingStats.Results[i]);
                    }
                    else
                    {
                        this.battingResultsRanges.Add(String.Format($"{bottomRange}-{topRange}"), BattingStats.Results[i]);
                    }

                    bottomRange = topRange + 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            this.battingResults = ret.ToArray();
        }

        /// <summary>
        /// Calculates the power rating.
        /// </summary>
        /// <param name="battingResultData">int[]</param>
        private void CalculatePowerRating(int[] battingResultData)
        {
            this.powerRating = (int)(((battingResultData[8] - battingResultData[7]) * 3)*3);
            if (this.powerRating > 100)
                this.powerRating = 100;
        }

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>int</value>
        public int ControlModifier { get => controlModifier; set => controlModifier = value; }

        /// <summary>
        /// Gets the batting results.
        /// </summary>
        /// <value>The batting results.</value>
        public BattingResults[] BattingResults { get => battingResults; }

        /// <summary>
        /// Gets the batting results ranges.
        /// </summary>
        /// <value>The batting results ranges.</value>
        public Dictionary<string, BattingResults> BattingResultsRanges { get => battingResultsRanges; }

        /// <summary>
        /// Gets or sets the power rating.
        /// </summary>
        /// <value>The power rating.</value>
        public int PowerRating { get => powerRating; set => powerRating = value; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public int Speed { get => speed; set => speed = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the batter rating.
        /// </summary>
        /// <value>The batter rating.</value>
        public int BatterRating 
        { 
            get => batterRating;
            set 
            { 
                batterRating = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets or sets the games played.
        /// </summary>
        /// <value>int</value>
        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }

        /// <summary>
        /// Gets or sets the batting statistics for the year the player played in.
        /// </summary>
        /// <value>BattingStatisticsContainer</value>
        public BattingStatisticsContainer BattingStatistics { get => battingStatistics; set => battingStatistics = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.BattingStats"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.BattingStats"/>.</returns>
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
            ret.AppendLine($"Batter Rating: {this.batterRating}");
            ret.AppendLine($"Control Modifier: {this.controlModifier}");
            ret.AppendLine($"Speed: {this.speed}");
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Ranges to string.
        /// </summary>
        protected override void RangeToString()
        {
            StringBuilder ret = new StringBuilder();
            Dictionary<string, BattingResults>.Enumerator cursor = this.battingResultsRanges.GetEnumerator();
            while (cursor.MoveNext())
                ret.AppendLine(cursor.Current.ToString());
            this.range = ret.ToString();
        }

        /// <summary>
        /// Generates the batting stats.
        /// </summary>
        /// <returns>BattingStats</returns>
        /// <param name="batterType">BatterTypes</param>
        public static BattingStats GenerateBattingStats(BatterTypes batterType)
        {
            switch (batterType)
            {
                case BatterTypes.Poor:
                    return new BattingStats(0, Dice.Roll(30, 60), 3, 20, 40, 65, 85, 95, 96, 97, 100);
                case BatterTypes.Average:
                    return new BattingStats(Dice.Roll(0, 4), Dice.Roll(40, 60), 3, 20, 40, 65, 85, 95, 96, 97, 100);
                case BatterTypes.Excellent:
                    return new BattingStats(Dice.Roll(5, 10), Dice.Roll(50, 90), 1, 20, 30, 40, 60, 80, 90, 93, 100);
                case BatterTypes.Unknown:
                    return new BattingStats(Dice.Roll(0, 5), Dice.Roll(20, 30), 1, 20, 30, 65, 85, 95, 96, 97, 100);
            }
            return null;
        }

        /// <summary>
        /// Loads the batting stats.
        /// </summary>
        /// <returns>BattingStats[]</returns>
        /// <param name="filePath">string</param>
        public static BattingStats[] LoadBattingStats(string filePath)
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
                return LoadBattingStats(data);
            }

            return null;
        }

        /// <summary>
        /// Loads the batting stats.
        /// </summary>
        /// <returns>BattingStats[]</returns>
        /// <param name="data">Dictionary</param>
        private static BattingStats[] LoadBattingStats(Dictionary<int, Dictionary<string, object>> data)
        {
            List<BattingStats> battingStats = new List<BattingStats>();
            Dictionary<int, Dictionary<string, object>> theData = data;
            Dictionary<int, Dictionary<string, object>>.Enumerator cursor1 = theData.GetEnumerator();
            while (cursor1.MoveNext())
            {
                Dictionary<string, object> playerStats = cursor1.Current.Value;
                Dictionary<string, object>.Enumerator cursor2 = playerStats.GetEnumerator();
                while (cursor2.MoveNext())
                {
                    string name = (string)playerStats["Name"];
                    if (name.Contains("*") || name.Contains("#") || name.Contains("?"))
                        name = name.Remove(name.Length - 1);
                    BattingStats stats = null;
                    int games = 0;
                    try
                    {
                        //Rk    Pos Name    Age G   PA  AB  R   H   2B  3B  HR  RBI SB  CS  BB  SO  BA  OBP SLG OPS OPS+    TB  GDP HBP SH  SF  IBB
                        //1   C Damian Miller   31  123 425 380 45  103 19  0   13  47  0   1   35  80  .271    .337    .424    .761    89  161 9   4   4   2   9
                        int atBats = (int)Convert.ToDouble(playerStats["AB"]);
                        int stolenBases = Convert.ToInt32(playerStats["SB"]);
                        int stealAttempts = Convert.ToInt32(playerStats["CS"]) + Convert.ToInt32(playerStats["SB"]);
                        if (atBats >= 50)//check to see if batter has meaningful stats
                        {
                            games = Convert.ToInt32(playerStats["G"]);
                            int hits = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["H"]), atBats);
                            int controlModifier = hits / 5;//figure this out, but will be based on batting average
                            int speed = Constants.GetValueFromDouble(stolenBases, stealAttempts);
                            if (speed <= 20)
                                speed = 20;
                            //int stamina = Convert.ToInt32((double)games/ Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_STAMINA_FACTOR")));
                            int batterRating = (int)(hits * 2.5);

                            int hitByPitch = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["HBP"]), atBats);
                            if (hitByPitch == 0)
                                hitByPitch = 1;

                            int walks = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["BB"]), atBats);
                            if (walks == 0)
                                walks = 1;

                            int strikeouts = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["SO"]), atBats);
                            if (strikeouts == 0)
                            {
                                strikeouts = 1;
                            }

                            int otherOuts = Constants.GetValueFromDouble(atBats - Convert.ToDouble(playerStats["H"]) - Convert.ToDouble(playerStats["BB"]) - Convert.ToDouble(playerStats["HBP"]) - Convert.ToDouble(playerStats["SO"]), atBats);

                            int groundOuts = (int)(otherOuts * 0.5);
                            if (groundOuts == 0)
                                groundOuts = 1;

                            int flyouts = (int)(otherOuts * 0.5);
                            if (flyouts == 0)
                                flyouts = 1;

                            int homeRuns = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["HR"]), atBats);
                            if (homeRuns == 0)
                                homeRuns = 1;

                            int doubles = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["2B"]), atBats);
                            if (doubles == 0)
                                doubles = 1;

                            int triples = Constants.GetValueFromDouble(Convert.ToDouble(playerStats["3B"]), atBats);
                            if (triples == 0)
                                triples = 1;

                            int singles = hits - homeRuns - doubles - triples;

                            stats = LoadResultRanges(controlModifier, speed, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);
                            stats.Name = name;
                            stats.BatterRating = batterRating;
                            stats.GamesPlayed = games;
                            battingStats.Add(stats);
                            break;
                        }
                        else//autogenerate batter because not enough stats are available 
                        {
                            object ba = playerStats["BA"];
                            double battingAverage = 0.0;
                            if (ba.ToString() != String.Empty)
                                battingAverage = Convert.ToDouble(ba);
                            if (battingAverage >= 0.300)
                            {
                                stats = BattingStats.GenerateBattingStats(BatterTypes.Excellent);
                            }
                            else if (battingAverage >= 0.200 && battingAverage < 0.300)
                            {
                                stats = BattingStats.GenerateBattingStats(BatterTypes.Average);
                            }
                            else
                            {
                                stats = BattingStats.GenerateBattingStats(BatterTypes.Poor);
                            }
                            stats.Name = name;
                            stats.BatterRating = Convert.ToInt32(battingAverage * 2.5);
                            stats.GamesPlayed = games;
                            battingStats.Add(stats);
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return battingStats.ToArray();
        }

        /// <summary>
        /// Loads the result ranges.
        /// </summary>
        /// <returns>The result ranges.</returns>
        /// <param name="control">int</param>
        /// <param name="speed">int</param>
        /// <param name="values">int[]</param>
        public static BattingStats LoadResultRanges(int control, int speed = 80, params int[] values)
        {
            //                  cm   sp  hbp bb  k   go  fo  1B  2B  3B  HR
            //new BattingStats(75, 60, 4,  22, 58, 70, 80, 90, 97, 98, 100)

            int hitByPitch = values[0];
            int walks = hitByPitch + values[1];
            int strikeouts = walks + values[2];
            int groundOuts = strikeouts + values[3];
            int flyouts = groundOuts + values[4];
            int singles = flyouts + values[5];
            int doubles = singles + values[6];
            int triples = doubles + values[7];
            if (triples >= 100)
                triples = 99;
            int homeRuns = 100;
            BattingStats stats = new BattingStats(control, speed, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);

            return stats;
        }

    }
}

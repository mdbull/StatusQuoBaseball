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

namespace StatusQuoBaseball.Loaders.DatabaseLoaders
{
    /// <summary>
    /// Database batting stats loader.
    /// </summary>
    public class DatabaseBattingStatsLoader : DatabaseGameStatsLoader
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseBattingStatsLoader"/> class.
        /// NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.
        /// </summary>
        /// <remarks> DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.</remarks>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        /// <param name="dataTable">DataTable</param>
        public DatabaseBattingStatsLoader(Db database, string sql, DataTable dataTable) : base(database, sql, dataTable)
        {
            //LoadStatsFromDatabase is called in the abstract class.
        }

        /// <summary>
        /// Returns an array BattingStats as an object.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            return LoadStatsFromDatabase(this.dataTable);
        }

        /// <summary>
        /// Loads batting stats from database.
        /// </summary>
        /// <returns>GameStats[]</returns>
        /// <param name="dataTable">DataTable</param>
        protected override GameStats[] LoadStatsFromDatabase(DataTable dataTable)
        {
            List<BattingStats> battingStats = new List<BattingStats>();
            BattingStatisticsContainer theStats;
            BattingStats bStats = null;
            string name=string.Empty;
            int originalHits=0;
            int atBats=0;
            int games=0;
            double battingAverage = 0.0;
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["playerID"].ToString();
                    name = String.Concat(row["nameFirst"].ToString(), " ", row["nameLast"].ToString());
                    games = Convert.ToInt32(row["G"]);
                    atBats = Convert.ToInt32(row["AB"]);
                    originalHits =  Convert.ToInt32(row["H"]);
                    int orginalHitByPitch = Convert.ToInt32(row["HBP"]);
                    int originalWalks = Convert.ToInt32(row["BB"]);
                    int originalStrikeouts = Convert.ToInt32(row["SO"]);
                    int originalOtherOuts = atBats - (originalHits + originalWalks + orginalHitByPitch + originalStrikeouts);
                    int originalTotalOuts = originalStrikeouts + originalOtherOuts;
                    int originalHomeRuns = Convert.ToInt32(row["HR"]);
                    int originalDoubles = Convert.ToInt32(row["2B"]);
                    int originalTriples = Convert.ToInt32(row["3B"]);
                    int originalSingles = originalHits - (originalHomeRuns + originalDoubles + originalTriples);

                    theStats = new BattingStatisticsContainer(null);
                    theStats.AtBats = atBats;
                    theStats.Singles = originalSingles;
                    theStats.Doubles = originalDoubles;
                    theStats.Triples = originalTriples;
                    theStats.Homeruns = originalHomeRuns;
                    theStats.RBI = Convert.ToInt32(row["RBI"]);
                    theStats.Walks = originalWalks;
                    theStats.HitByPitches = orginalHitByPitch;

                    if (atBats > 0)
                        battingAverage = (double)originalHits / (double)atBats;

                    if (atBats >= 50)//check to see if batter has meaningful bStats
                    {
                        int stolenBases = 0;
                        int caughtStealing = 0;
                        //Get percentage values
                        int hits = Constants.GetValueFromDouble(originalHits, atBats);
                        int speed = 0;

                        try
                        {
                            stolenBases = Convert.ToInt32(row["SB"]);//Lahman doesn't have stolen base attempts, but has caught stealing
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            stolenBases = 0;
                        }
                        theStats.StolenBases = stolenBases;

                        try
                        {
                            caughtStealing = Convert.ToInt32(row["CS"]);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            caughtStealing = 0;
                        }
                        int stealAttempts = stolenBases + caughtStealing;

                        speed = BattingStats.CalculateSpeed(stolenBases, stealAttempts);

                        int stamina = BattingStats.CalculateStamina(games);
                        int batterRating = BattingStats.CalculateBatterRating(games,battingAverage);
                        int controlModifier = BattingStats.CalculateControlModifier(games,batterRating);

                        int hitByPitch = Constants.GetValueFromDouble(orginalHitByPitch, atBats);
                        if (hitByPitch == 0)
                            hitByPitch = 1;
                        //PROFESSIONAL_BATTER_RESULTS_FACTOR
                        int walks = Constants.GetValueFromDouble(originalWalks, atBats);
                        walks /= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (walks == 0)
                            walks = 1;

                        double totalOutPct = (double)originalTotalOuts / (double)atBats;

                        int strikeouts = Constants.GetValueFromDouble(originalStrikeouts, originalTotalOuts);
                        strikeouts = (int)(strikeouts * totalOutPct);
                        strikeouts /= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (strikeouts == 0)
                        {
                            strikeouts = 1;
                        }

                        int otherOuts = Constants.GetValueFromDouble(originalOtherOuts, originalTotalOuts);
                        otherOuts = (int)(otherOuts * totalOutPct);
                        otherOuts /= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        int groundOuts = (int)(otherOuts * 0.5);
                        if (groundOuts == 0)
                            groundOuts = 1;

                        int flyouts = (int)(otherOuts * 0.5);
                        if (flyouts == 0)
                            flyouts = 1;

                        double homeRunPct = (double)originalHomeRuns / (double)originalHits;
                        int homeRuns = (int)(hits * homeRunPct);
                        homeRuns *= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (homeRuns == 0)
                            homeRuns = 1;

                        double doublePct = (double)originalDoubles / (double)originalHits;
                        int doubles = (int)(hits * doublePct);
                        doubles *= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (doubles == 0)
                            doubles = 1;

                        double triplePct = (double)originalTriples / (double)originalHits;
                        int triples = (int)(hits * triplePct);
                        triples *= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (triples == 0)
                            triples = 1;

                        double singlePct = (double)originalSingles / (double)originalHits;
                        int singles = (int)(hits * singlePct);
                        singles *= Convert.ToInt32(Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_BATTER_RESULTS_FACTOR")));
                        if (singles == 0)
                            singles = 1;

                        bStats = BattingStats.LoadResultRanges(controlModifier, speed, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);
                        bStats.Name = name;
                        bStats.BatterRating = batterRating;
                        bStats.GamesPlayed = games;
                        bStats.Stamina = stamina;

                    }
                    else//autogenerate batter because not enough bStats are available 
                    {
                        if (battingAverage >= 0.300 && games >= 20)
                        {
                            bStats = BattingStats.GenerateBattingStats(BatterTypes.Excellent);
                        }
                        else if (battingAverage >= 0.200 && battingAverage < 0.300)
                        {
                            bStats = BattingStats.GenerateBattingStats(BatterTypes.Average);
                        }
                        else
                        {
                            bStats = BattingStats.GenerateBattingStats(BatterTypes.Poor);
                        }
                        bStats.Name = name;
                        bStats.BatterRating = BattingStats.CalculateBatterRating(games,battingAverage);
                        bStats.GamesPlayed = games;
                        bStats.Stamina = Dice.Roll(30, 60);
                    }
                    bStats.BattingStatistics = theStats;
                    battingStats.Add(bStats);
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                bStats = BattingStats.GenerateBattingStats(BatterTypes.Average);
                bStats.Name = name;
                bStats.BatterRating = BattingStats.CalculateBatterRating(games,battingAverage);
                bStats.GamesPlayed = games;
                bStats.Stamina = Dice.Roll(50, 70);
                battingStats.Add(bStats);
            }
          
            return battingStats.ToArray();
        }

    }
}
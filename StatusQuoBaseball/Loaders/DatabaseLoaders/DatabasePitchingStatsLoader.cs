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
    public class DatabasePitchingStatsLoader : DatabaseGameStatsLoader
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabasePitchingStatsLoader"/> class.
        /// NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.
        /// </summary>
        /// <remarks> DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.</remarks>
        /// <param name="database">Db</param>
        /// <param name="sql">string</param>
        /// <param name="dataTable">DataTable</param>
        public DatabasePitchingStatsLoader(Db database, string sql, DataTable dataTable) : base(database, sql, dataTable)
        {
        }

        /// <summary>
        /// Returns PitchingStats[] array as an object.
        /// </summary>
        /// <returns>object</returns>
        public override object Load()
        {
            return LoadStatsFromDatabase(this.dataTable);
        }

        /// <summary>
        /// Loads PitchingStats[] array from database.
        /// </summary>
        /// <returns>GameStats[]</returns>
        /// <param name="dataTable">DataTable</param>
        protected override GameStats[] LoadStatsFromDatabase(DataTable dataTable)
        {
            List<PitchingStats> pitchingStats = new List<PitchingStats>();

            foreach (DataRow row in dataTable.Rows)
            {
                string name = string.Empty;
                string id = string.Empty;
                PitchingStats pStats = null;
                PitchingStatisticsContainer theStats = null;
                int stamina = 0;
                double startPct = 0;
                int originalHits = Convert.ToInt32(row["H"]);
                try
                {
                    theStats = new PitchingStatisticsContainer(null);

                    name = String.Concat(row["nameFirst"].ToString(), " ", row["nameLast"].ToString());
                    int battersFaced = (int)Convert.ToDouble(row["BFP"]);
                    theStats.BattersFaced = battersFaced;

                    double inningsPitched = (Convert.ToDouble(row["IPouts"]) / 3);
                    theStats.TotalOuts = (int)Convert.ToDouble(row["IPouts"]);

                    int completeGames = (int)Convert.ToDouble(row["CG"]);
                    theStats.CompleteGames = completeGames;

                    theStats.Saves = Convert.ToInt32(row["SV"]);
                    theStats.RunsAllowed = Convert.ToInt32(row["R"]);

                    int hits = Constants.GetValueFromDouble(originalHits, battersFaced);

                    int totalGamesPitched = Convert.ToInt32(row["G"]);
                    theStats.PitchingTotalGamesAppeared = totalGamesPitched;

                    int gamesStarted = Convert.ToInt32(row["GS"]);
                    theStats.PitchingGamesStarted = gamesStarted;

                    int wins = Convert.ToInt32(row["W"]);
                    theStats.Wins = wins;

                    int losses = Convert.ToInt32(row["L"]);
                    theStats.Losses = losses;

                    int totalDecisions = wins + losses;
                    startPct = Constants.GetValueFromDouble(gamesStarted, totalGamesPitched);
                    double winLossPct = Constants.GetValueFromDouble(wins, totalDecisions);

                    int control = PitchingStats.CalculateControl(battersFaced, originalHits, wins, theStats.Saves);

                    stamina = PitchingStats.CalculateStamina(startPct, wins, completeGames, gamesStarted, totalGamesPitched, inningsPitched);
                   
                    int balks = Constants.GetValueFromDouble(Convert.ToDouble(row["BK"]), battersFaced);
                    if (balks == 0)
                        balks = 1;
                    theStats.Balks = Convert.ToInt32(row["BK"]);

                    int hitByPitch = Constants.GetValueFromDouble(Convert.ToDouble(row["HBP"]), battersFaced);
                    if (hitByPitch == 0)
                        hitByPitch = 1;
                    theStats.HitByPitches = Convert.ToInt32(row["HBP"]);

                    int walks = Constants.GetValueFromDouble(Convert.ToDouble(row["BB"]), battersFaced);
                    if (walks == 0)
                        walks = 1;
                    theStats.Walks = Convert.ToInt32(row["BB"]);

                    int strikeouts = Constants.GetValueFromDouble(Convert.ToDouble(row["SO"]), battersFaced);
                    if (strikeouts == 0)
                    {
                        strikeouts = 1;
                    }
                    theStats.Strikeouts = Convert.ToInt32(row["SO"]);

                    int otherOuts = Constants.GetValueFromDouble(Convert.ToDouble(row["BFP"]) - Convert.ToDouble(row["H"]) - Convert.ToDouble(row["BB"]) - Convert.ToDouble(row["HBP"]) - Convert.ToDouble(row["SO"]), Convert.ToDouble(row["BFP"]));
                    int groundOuts = (int)(otherOuts * 0.5);
                    if (groundOuts == 0)
                        groundOuts = 1;
                    int flyouts = (int)(otherOuts * 0.5);
                    if (flyouts == 0)
                        flyouts = 1;

                    int homeRuns = Constants.GetValueFromDouble(Convert.ToDouble(row["HR"]), battersFaced);
                    if (homeRuns == 0)
                        homeRuns = 1;
                    theStats.Homeruns = Convert.ToInt32(row["HR"]);

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

                    //Reverse engineer ERA to get earned runs
                    double ERA = Convert.ToDouble(row["ERA"]);
                    theStats.EarnedRunsAllowed = (int)(((inningsPitched) / 9) * ERA);

                    pStats = PitchingStats.LoadResultRanges(control, balks, hitByPitch, walks, strikeouts, groundOuts, flyouts, singles, doubles, triples, homeRuns);
                    id = row["playerID"].ToString();
                    pStats.Name = name;
                    pStats.Stamina = stamina;
                    pStats.StartPct = (int)startPct;
                    pStats.PitchingStatistics = theStats;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    pStats = PitchingStats.GeneratePitchingStats(PitcherTypes.Average);
                    pStats.Name = name;
                    pStats.Stamina = Dice.Roll(25,50);
                    pStats.StartPct = 0;
                    pStats.PitchingStatistics = theStats;
                   
                }
                pitchingStats.Add(pStats);
            }
            return pitchingStats.ToArray();
        }
    }
}

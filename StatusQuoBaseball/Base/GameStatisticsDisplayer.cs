using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Game statistics displayer.
    /// </summary>
    public class GameStatisticsDisplayer
    {
        private Scoreboard scoreboard;

        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <value>Scoreboard</value>
        public Scoreboard Scoreboard { get => this.scoreboard; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.GameStatisticsDisplayer"/> class.
        /// </summary>
        public GameStatisticsDisplayer(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        /// <summary>
        /// Gets the box score (score by innings) in text.
        /// </summary>
        /// <returns>The box score.</returns>
        public string GetBoxScore()
        {
            int longestTeamName = TextUtilities.GetLengthOfLongestString(this.scoreboard.RoadTeam.ToString(), this.scoreboard.HomeTeam.ToString());
            char SPACE = ' ';
            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestTeamName + 2));
            InningScore[] inningScores = scoreboard.InningScores;
            Team roadTeam = scoreboard.RoadTeam;
            Team homeTeam = scoreboard.HomeTeam;

            for (int i = 0; i < inningScores.Length; i++)
            {
                ret.AppendFormat($"{TextUtilities.FillString((i + 1).ToString(), SPACE, 3)}");
            }
            ret.AppendFormat($"{TextUtilities.FillString("R", SPACE, 3)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, 3)}");
            ret.AppendFormat($"{TextUtilities.FillString("E", SPACE, 3)}");

            ret.AppendFormat($"\n{TextUtilities.FillString(this.scoreboard.RoadTeam.ToString(), SPACE, (uint)longestTeamName + 2)}");
            for (int i = 0; i < inningScores.Length; i++)
            {
                string topScore = TextUtilities.FillString(this.scoreboard.InningScores[i].TopScore.ToString(), SPACE, 3);
                ret.AppendFormat($"{topScore}");
            }
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.RoadTeamScore.ToString(), SPACE, 3)}");
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.RoadTeamHits.ToString(), SPACE, 3)}");
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.RoadTeamErrors.ToString(), SPACE, 3)}");

            ret.AppendFormat($"\n{TextUtilities.FillString(this.scoreboard.HomeTeam.ToString(), ' ', (uint)longestTeamName + 2)}");
            for (int i = 0; i < this.scoreboard.InningScores.Length; i++)
            {
                string bottomScore = string.Empty;
                int originalBottomScore = scoreboard.InningScores[i].BottomScore;
                if (originalBottomScore >= 0)
                {
                    bottomScore = TextUtilities.FillString(originalBottomScore.ToString(), SPACE, 3);

                   
                }
                else
                {
                    bottomScore = TextUtilities.FillString("X", SPACE, 3);
                    scoreboard.InningScores[i].BottomScore = 0;
                }
                ret.AppendFormat($"{bottomScore}");
            }
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.HomeTeamScore.ToString(), SPACE, 3)}");
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.HomeTeamHits.ToString(), SPACE, 3)}");
            ret.Append($"{TextUtilities.FillString(this.Scoreboard.HomeTeamErrors.ToString(), SPACE, 3)}");


            return ret.ToString();
        }

        /// <summary>
        /// Gets the full box score.
        /// </summary>
        /// <returns>string</returns>
        public string GetFullBoxScore()
        {
            return $"{GetBoxScore()}\n{GetGameStatistics()}";
        }

        /// <summary>
        /// Gets the game statistics.
        /// </summary>
        /// <returns>The game statistics.</returns>
        private string GetGameStatistics()
        {
            StringBuilder ret = new StringBuilder();

            try
            {
                ret.Append("\n\nSTATISTICS\n");
                ret.Append(String.Format($"{this.scoreboard.RoadTeam.ToString()}\n"));
                ret.Append(String.Format($"Pitching\n"));
                ret.Append(GetPitchingStatisticsBoxScore(this.scoreboard.RoadTeam));
                ret.Append("\n\n");
                ret.Append(String.Format("Batting\n"));
                ret.Append(GetBattingStatisticsBoxScore(this.scoreboard.RoadTeam));
                ret.Append("\n\n");
                ret.Append(String.Format("Fielding\n"));
                ret.Append(GetFieldingStatisticsBoxScore(this.scoreboard.RoadTeam));
                ret.Append("\n\n");
                ret.Append(String.Format($"{this.scoreboard.HomeTeam.ToString()}\n"));
                ret.Append(String.Format($"Pitching\n"));
                ret.Append(GetPitchingStatisticsBoxScore(this.scoreboard.HomeTeam));
                ret.Append("\n\n");
                ret.Append(String.Format("Batting\n"));
                ret.Append(GetBattingStatisticsBoxScore(this.scoreboard.HomeTeam));
                ret.Append("\n\n");
                ret.Append(String.Format("Fielding\n"));
                ret.Append(GetFieldingStatisticsBoxScore(this.scoreboard.HomeTeam));
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the batting statistics box score.
        /// </summary>
        /// <returns>The batting statistics box score.</returns>
        /// <param name="team">Team.</param>
        private string GetBattingStatisticsBoxScore(Team team)
        {
            int longestNameLength = Person.GetLongestPersonName(team.Roster.Players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("PA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("2B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("3B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("RBI", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("R", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SF", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AVG", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("OBP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SLG", SPACE, FILL_LENGTH)}");

            foreach (Player p in team.Roster.Lineup)
            {
                if (p.MadeAppearance)
                {
                    BattingStatisticsContainer battingStatistics = p.BattingStatistics;
                    try
                    {
                        ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.PlateAppearances.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Walks.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.AtBats.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Hits.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Doubles.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Triples.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.RBI.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.Runs.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.SacrificeFlyouts.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.StealAttempts.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.StolenBases.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.BattingAverage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.OnBasePercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(battingStatistics.SluggingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the pitching statistics box score.
        /// </summary>
        /// <returns>The pitching statistics box score.</returns>
        /// <param name="team">Team.</param>
        private string GetPitchingStatisticsBoxScore(Team team)
        {
            int longestNameLength = Person.GetLongestPersonName(team.Roster.PitchingOrder.ToArray());

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();

            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("IP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("2B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("3B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("R", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ERA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HBP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("K", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SF", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BK", SPACE, FILL_LENGTH)}");

            //TODO: Resolve PitchingOrder/PitchingOrder2
            Player[] pitchingOrder = team.Roster.PitchingOrder.ToArray();
            team.Roster.PitchingOrder2.Clear();
            foreach (Player p in pitchingOrder)
            {
                try
                {
                    PitchingStatisticsContainer pitchingStatistics = team.Roster.PitchingOrder.Dequeue().PitchingStatistics;

                    try
                    {
                        ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.InningsPitched.ToString("0.0"), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Hits.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Doubles.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Triples.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.RunsAllowed.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        double ERA = pitchingStatistics.EarnedRunAverage;
                        if(ERA is double.PositiveInfinity)
                            ret.AppendFormat($"{TextUtilities.FillString("∞", SPACE, FILL_LENGTH)}");
                        else
                            ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.EarnedRunAverage.ToString("0.00"), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Walks.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.HitByPitches.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Strikeouts.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.SacrificeFlyouts.ToString(), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    ret.AppendFormat($"{TextUtilities.FillString(pitchingStatistics.Balks.ToString(), SPACE, FILL_LENGTH)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the fielding statistics box score.
        /// </summary>
        /// <returns>The fielding statistics box score.</returns>
        /// <param name="team">Team.</param>
        private string GetFieldingStatisticsBoxScore(Team team)
        {
            int longestNameLength = Person.GetLongestPersonName(team.Roster.Players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder(); ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("TC", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("A", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PO", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("E", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PCT", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("CS%", SPACE, FILL_LENGTH)}");

            foreach (Player p in team.Roster.Lineup)
            {
                if (p.MadeAppearance)
                {
                    FieldingStatisticsContainer fieldingStatistics = p.FieldingStatistics;
                    try
                    {
                        ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.TotalChances.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.Assists.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.Putouts.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.Errors.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.FieldingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.StealAttemptsAgainst.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.StolenBases.ToString(), SPACE, FILL_LENGTH)}");
                        ret.AppendFormat($"{TextUtilities.FillString(fieldingStatistics.CaughtStealingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return ret.ToString();
        }




    }
}

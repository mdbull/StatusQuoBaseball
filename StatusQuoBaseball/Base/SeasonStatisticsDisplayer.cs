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
    /// Season statistics displayer.
    /// </summary>
    public class SeasonStatisticsDisplayer
    {
        private Team team;

        /// <summary>
        /// Gets the team.
        /// </summary>
        /// <value>The team.</value>
        public Team Team { get => team;}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.SeasonStatisticsDisplayer"/> class.
        /// </summary>
        /// <param name="team">Team</param>
        public SeasonStatisticsDisplayer(Team team)
        {
            this.team = team;
        }

        /// <summary>
        /// Gets the team information.
        /// </summary>
        /// <returns>string</returns>
        public string GetTeamInformation()
        {
            StringBuilder ret = new StringBuilder();

            ret.Append("\n\nSTATISTICS\n");
            ret.Append(String.Format($"{this.team.ToString()}\n"));
            ret.Append(String.Format($"Pitching\n"));
            ret.Append(GetSeasonPitchingStatistics());
            ret.Append("\n\n");
            ret.Append(String.Format("Batting\n"));
            ret.Append(GetSeasonBattingStatistics());
            ret.Append("\n\n");
            ret.Append(String.Format("Fielding\n"));
            ret.Append(GetSeasonFieldingStatistics());
            return ret.ToString();
        }

        /// <summary>
        /// Gets the season batting statistics.
        /// </summary>
        /// <returns>string</returns>
        public string GetSeasonBattingStatistics()
        {
            int longestNameLength = Person.GetLongestPersonName(team.Roster.Players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("GA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("GS", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("2B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("3B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("RBI", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("R", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HBP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SF", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SO", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AVG", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("OBP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SLG", SPACE, FILL_LENGTH)}");

            var players = team.Roster.Players.OrderByDescending(p=>p.BattingStatistics.AtBats).ThenByDescending(p=>p.BattingStatistics.BattingAverage).ToList();

            foreach (Player p in players)
            {
                if (p.SeasonStatistics.TotalGamesPlayed > 0)
                {
                    BattingStatisticsContainer seasonBattingStatistics = p.SeasonStatistics.SeasonBattingStatistics;
                    ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    ret.AppendFormat($"{TextUtilities.FillString(p.SeasonStatistics.TotalGamesPlayed.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(p.SeasonStatistics.TotalGamesStarted.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.PlateAppearances.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.AtBats.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Hits.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Doubles.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Triples.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.RBI.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Runs.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Walks.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.HitByPitches.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.SacrificeFlyouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.Strikeouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.StealAttempts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.StolenBases.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.BattingAverage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.OnBasePercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonBattingStatistics.SluggingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the season pitching statistics.
        /// </summary>
        /// <returns>string</returns>
        public string GetSeasonPitchingStatistics()
        {
            int longestNameLength = Person.GetLongestPersonName(team.Roster.Players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();

            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("GA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("GS", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("CG", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("W", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("L", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PCT", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SV", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("IP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HBP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("K", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("R", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BK", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ERA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SHO", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("NH", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PG", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("2B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("3B", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SF", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("OBA", SPACE, FILL_LENGTH)}");
            //ret.AppendFormat($"{TextUtilities.FillString("SLG", SPACE, FILL_LENGTH)}");

            var players = team.Roster.Players.Where(p => p.CurrentPosition=="P").OrderByDescending(p=>p.SeasonStatistics.SeasonPitchingStatistics.Wins).ToList();


            foreach (Player p in players)
            {
                if (p.SeasonStatistics.SeasonPitchingStatistics.PitchingTotalGamesAppeared > 0 && p.CurrentPosition == "P")
                {
                    PitchingStatisticsContainer seasonPitchingStatistics = p.SeasonStatistics.SeasonPitchingStatistics;
                    ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.PitchingTotalGamesAppeared.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.PitchingGamesStarted.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.CompleteGames.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Wins.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Losses.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.WinLossPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Saves.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.InningsPitched.ToString("0.0"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Walks.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.HitByPitches.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Strikeouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.RunsAllowed.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Balks.ToString(), SPACE, FILL_LENGTH)}");
                    double ERA = seasonPitchingStatistics.EarnedRunAverage;
                    if(ERA is double.PositiveInfinity)
                        ret.AppendFormat($"{TextUtilities.FillString("∞", SPACE, FILL_LENGTH)}");
                    else
                        ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.EarnedRunAverage.ToString("0.00"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Shutouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.NoHitters.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.PerfectGames.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Hits.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Doubles.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Triples.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.SacrificeFlyouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.OpposingBattingAverage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.OnBasePercentageAllowed.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    //ret.AppendFormat($"{TextUtilities.FillString(seasonPitchingStatistics.OpposingSluggingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the season fielding statistics.
        /// </summary>
        /// <returns>string</returns>
        public string GetSeasonFieldingStatistics()
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


            var players = team.Roster.Players.Where(p => p.FieldingStats!=null).OrderByDescending(p => p.FieldingStatistics.TotalChances).ThenByDescending(p => p.FieldingStatistics.FieldingPercentage).ToList();
            foreach (Player p in players)
            {
                if (p.SeasonStatistics.TotalGamesPlayed > 0)
                {
                    FieldingStatisticsContainer seasonFieldingStatistics = p.SeasonStatistics.SeasonFieldingStatistics;
                    ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.TotalChances.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.Assists.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.Putouts.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.Errors.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.FieldingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.StealAttemptsAgainst.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.StolenBases.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(seasonFieldingStatistics.CaughtStealingPercentage.ToString("0.000"), SPACE, FILL_LENGTH)}");
                }
            }
            return ret.ToString();
        }

    }
}

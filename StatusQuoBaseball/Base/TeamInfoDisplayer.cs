using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Team info displayer.
    /// </summary>
    public class TeamInfoDisplayer:ILoggable
    {

        private Team team;
        private string teamInformation;

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>Team</value>
        public Team Team { get => team; set => team = value; }

        /// <summary>
        /// Gets the team information.
        /// </summary>
        /// <value>string</value>
        public string TeamInformation { get => teamInformation; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamDisplayer"/> class.
        /// </summary>
        /// <param name="theTeam">The team.</param>
        public TeamInfoDisplayer(Team theTeam)
        {
            this.team = theTeam;
        }

        /// <summary>
        /// Gets the team information (Team Name, Mascot, and Coach)
        /// </summary>
        /// <returns>string</returns>
        public string GetTeamInformation()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"{this.team.ToString()}");
            ret.Append($"\n{ConfigurationManager.GetConfigurationValue("GENERAL_LINE_SEPARATOR")}\n");
            ret.Append($"{this.team.Coach.ToString()}");
            ret.Append($"\n\nTeam Batting Ratings");
            ret.Append($"\nBR: {team.Roster.RosterBatterRating}");
            ret.Append($" PR: {team.Roster.RosterPowerRating}");
            ret.Append($" SP: {team.Roster.RosterSpeedRating}");
            ret.Append($"\n\nTeam Pitching Ratings");
            ret.Append($"\nCT: {team.Roster.RosterControl}");
            ret.Append($" PR: {team.Roster.RosterPowerPitching}");
            ret.Append($"\n\n✝=Deceased (Aged)✝");
            teamInformation= ret.Append(GetTeamStats()).ToString();
            return teamInformation;
        }

        /// <summary>
        /// Gets the team stats.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="showRanges">If set to <c>true</c> show ranges.</param>
        public string GetTeamStats(bool showRanges=false)
        {
            StringBuilder ret = new StringBuilder();
            //ret.Append($"\nTeam Statistics for {this.team.ToString()}");
            ret.Append("\n\nPitching\n");
            ret.Append(GetPitchingStatistics(showRanges,this.team.Roster.Players));
            ret.Append("\n\nBatting\n");
            ret.Append(GetBattingStatistics(showRanges,this.team.Roster.Players));
            ret.Append("\n\nFielding\n");
            ret.Append(GetFieldingStatistics(this.team.Roster.Players));
            return ret.ToString();
        }

        /// <summary>
        /// Gets the individual stats.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="player">Player</param>
        /// <param name="showRanges">bool</param>
        public string GetIndividualStats(Player player, bool showRanges=false)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"\nStatistics for {player.ToString()}");
            ret.Append($"\n{ConfigurationManager.GetConfigurationValue("GENERAL_LINE_SEPARATOR")}");
            if (player.PitchingStats != null)//not every player has pitching stats
            {
                ret.Append("\n");
                ret.Append($"Pitching\n");
                ret.Append(GetPitchingStatistics(showRanges, player));
            }
            ret.Append("\n");
            ret.Append("Batting\n");
            ret.Append(GetBattingStatistics(showRanges, player));
            ret.Append("\n");
            ret.Append("Fielding\n");
            ret.Append(GetFieldingStatistics(player));
            return ret.ToString();
        }

        /// <summary>
        /// Gets the batting statistics.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="players">Players[]</param>
        /// <param name="showRanges">If set to <c>true</c> show ranges.</param>
        public string GetBattingStatistics(bool showRanges, params Player [] players )
        {
            int longestNameLength = Person.GetLongestPersonName(players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder(GetBattingStatisticsHeader(players));

            var sorted = from p in players
                         where p.BattingStats != null
                         orderby p.BattingStats.BatterRating descending
                         select p;

            Player[] sortedList = sorted.ToArray();
            foreach (Player p in sortedList)
            {
                BattingStats battingStats;
                try
                {
                    battingStats = p.BattingStats;
                    ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    ret.AppendFormat($"{TextUtilities.FillString(p.Age(p.Team.Year).ToString(), SPACE, FILL_LENGTH)}");
                    if(!p.IsDeceased)
                        ret.AppendFormat($"{TextUtilities.FillString(p.Age(DateTime.Now.Year).ToString(), SPACE, FILL_LENGTH)}");
                    else
                        ret.AppendFormat($"{TextUtilities.FillString($"{p.Age(0).ToString()}✝", SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.ControlModifier.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BatterRating.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.Speed.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(p.Stamina.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.PowerRating.ToString(), SPACE, FILL_LENGTH)}");
                    if (battingStats.BattingStatistics == null)
                        battingStats.BattingStatistics = BattingStatisticsContainer.EmptyBattingStatisticsContainer;

                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.AtBats.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.Hits.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.RBI.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.StolenBases.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(battingStats.BattingStatistics.BattingAverage.ToString("0.000"), SPACE, FILL_LENGTH)}");

                    if (showRanges)
                        ret.AppendFormat($"\n{battingStats.Range}");
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
        /// Gets the batting statistics header.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="personnel">Person[]</param>
        private string GetBattingStatisticsHeader(params Person [] personnel)
        {
            int longestNameLength = Person.GetLongestPersonName(personnel);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("AGE", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("NOW", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("CM", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ST", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("H", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("RBI", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("AVG", SPACE, FILL_LENGTH)}");

            return ret.ToString();
        }

        /// <summary>
        /// Gets the pitching statistics.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="showRanges">If set to <c>true</c> show ranges.</param>
        /// <param name="players">Players[]</param>
        public string GetPitchingStatistics(bool showRanges, params Player[] players)
        {
            int longestNameLength = Person.GetLongestPersonName(players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            if(players.Length == 1 && players[0].PitchingStats == null)
            {
                return String.Empty;
            }

            StringBuilder ret = new StringBuilder(GetPitchingStatisticsHeader(players));

            var sorted = players.Where(player => player.PitchingStats != null)
                         .OrderByDescending(player => player.PitchingStats.Stamina)
                         .ThenByDescending(player => player.PitchingStats.Control);

            Player[] sortedList = sorted.ToArray();
            foreach (Player p in sortedList)
            {
                PitchingStats pitchingStats = p.PitchingStats;
                if (pitchingStats.PitchingStatistics == null)
                    pitchingStats.PitchingStatistics = PitchingStatisticsContainer.EmptyPitchingStatisticsContainer;
                ret.AppendFormat($"{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.Age(p.Team.Year).ToString(), SPACE, FILL_LENGTH)}");
                if (!p.IsDeceased)
                    ret.AppendFormat($"{TextUtilities.FillString(p.Age(DateTime.Now.Year).ToString(), SPACE, FILL_LENGTH)}");
                else
                    ret.AppendFormat($"{TextUtilities.FillString($"{p.Age(0).ToString()}✝", SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(pitchingStats.Control.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.Stamina.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(pitchingStats.PowerRating.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.PitchingTotalGamesAppeared.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.PitchingGamesStarted.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.CompleteGames.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Wins.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Losses.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Saves.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.InningsPitched.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Homeruns.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Walks.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.Strikeouts.ToString(), SPACE, FILL_LENGTH)}");
                if(p.PitchingStats.PitchingStatistics.EarnedRunAverage is double.PositiveInfinity)
                    ret.AppendFormat($"{TextUtilities.FillString("∞", SPACE, FILL_LENGTH)}");
                else
                    ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.EarnedRunAverage.ToString("0.00"), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(p.PitchingStats.PitchingStatistics.FieldingIndependentPitching.ToString("0.00"), SPACE, FILL_LENGTH)}\n");
             
                if (showRanges)
                    ret.Append(p.PitchingStats.Range);
            }
            return ret.ToString();
        }

        /// <summary>
        /// Gets the pitching statistics header.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="personnel">People[]</param>
        private string GetPitchingStatisticsHeader(params Person [] personnel)
        {
            int longestNameLength = Person.GetLongestPersonName(personnel);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();

            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("AGE", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("NOW", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("CT", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ST", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("PR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("G", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("GS", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("CG", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("W", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("L", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SV", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("IP", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("HR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("SO", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ERA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("FIP", SPACE, FILL_LENGTH)}\n");
            return ret.ToString();

        }

        /// <summary>
        /// Gets the fielding statistics.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="players">Players[]</param>
        public string GetFieldingStatistics(params Player [] players)
        {
            int longestNameLength = Person.GetLongestPersonName(players);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder(GetFieldingStatisticsHeader(players));

            var sorted = from p in players
                         where p.FieldingStats != null
                         orderby p.FieldingStats.FieldingRating descending
                         select p;

            Player[] sortedList = sorted.ToArray();
            foreach (Player p in sortedList)
            {
                try
                {
                    FieldingStats fieldingStats = p.FieldingStats;
                    ret.AppendFormat($"\n{TextUtilities.FillString(p.ToString(), SPACE, (uint)longestNameLength + 2)}");
                    ret.AppendFormat($"{TextUtilities.FillString(p.Age(p.Team.Year).ToString(), SPACE, FILL_LENGTH)}");
                    if (!p.IsDeceased)
                        ret.AppendFormat($"{TextUtilities.FillString(p.Age(DateTime.Now.Year).ToString(), SPACE, FILL_LENGTH)}");
                    else
                        ret.AppendFormat($"{TextUtilities.FillString($"{p.Age(0).ToString()}✝", SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(fieldingStats.FieldingRating.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(fieldingStats.FlyoutError.ToString(), SPACE, FILL_LENGTH)}");
                    ret.AppendFormat($"{TextUtilities.FillString(fieldingStats.ArmStrength.ToString(), SPACE, FILL_LENGTH)}");
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
        /// Gets the fielding statistics header.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="personnel">Person[]</param>
        private string GetFieldingStatisticsHeader(params Person[] personnel)
        {
            int longestNameLength = Person.GetLongestPersonName(personnel);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder(); ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("AGE", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("NOW", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("FR", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("E", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ARM", SPACE, FILL_LENGTH)}");
            return ret.ToString();
        }

        /// <summary>
        /// Log this instance.
        /// </summary>
        public void Log()
        {
            Logger logger = new Logger($"./Information/{this.Team.ToString()}.info");
            logger.LogMessage(this.GetTeamInformation());
            logger.WriteToFile();
            logger.OpenFileInEditor();
        }
    }
}

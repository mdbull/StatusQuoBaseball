using System;
using System.Linq;
using System.Text;
using System.Threading;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Standings.
    /// </summary>
    public class Standings : Entity
    {
        private Team[] teams;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Standings"/> class.
        /// </summary>
        /// <param name="teams">Team[]</param>
        public Standings(params Team[] teams)
        {
            this.teams = teams;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Gets the teams.
        /// </summary>
        /// <value>Team[]</value>
        public Team[] Teams { get => teams; }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            var strings = from team in teams
                          select team.ToString();
            string[] teamNames = strings.ToArray();
            int longestNameLength = TextUtilities.GetLengthOfLongestString(teamNames);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString("W", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("L", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("Pct", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("GB", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("RS", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("RA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("BA", SPACE, FILL_LENGTH)}");
            ret.AppendFormat($"{TextUtilities.FillString("ERA", SPACE, FILL_LENGTH)}");

            var tempList = from team in teams
                           orderby team.SeasonStatisticsContainer.WinLossPercentage descending
                           select team;
            Team[] sortedList = tempList.ToArray();

            int winDelta, lossDelta, topTeamWins, topTeamLosses, currentTeamWins, currentTeamLosses;
            winDelta = lossDelta = topTeamWins = topTeamLosses = currentTeamWins = currentTeamLosses = 0;
            topTeamWins = sortedList[0].SeasonStatisticsContainer.Wins;
            topTeamLosses = sortedList[0].SeasonStatisticsContainer.Losses;

            double gamesBack = 0;

            foreach (Team team in sortedList)
            {
                currentTeamWins = team.SeasonStatisticsContainer.Wins;
                currentTeamLosses = team.SeasonStatisticsContainer.Losses;
                winDelta = topTeamWins - currentTeamWins;
                lossDelta = currentTeamLosses-topTeamLosses;
                gamesBack = (winDelta + lossDelta) / 2.0;


                BattingStatisticsContainer seasonBattingStatistics = team.SeasonStatisticsContainer.SeasonBattingStatistics;
                ret.AppendFormat($"\n{TextUtilities.FillString(team.ToString(), SPACE, (uint)longestNameLength + 2)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.Wins.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.Losses.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.WinLossPercentage.ToString("#.000"), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(gamesBack.ToString("0.0"), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.SeasonBattingStatistics.Runs.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.SeasonPitchingStatistics.RunsAllowed.ToString(), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.SeasonBattingStatistics.BattingAverage.ToString("#.000"), SPACE, FILL_LENGTH)}");
                ret.AppendFormat($"{TextUtilities.FillString(team.SeasonStatisticsContainer.SeasonPitchingStatistics.EarnedRunAverage.ToString("0.00"), SPACE, FILL_LENGTH)}");
            }
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Standings"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Standings"/>.</returns>
        public override string ToString()
        {
            return toString;
        }

        /// <summary>
        /// Gets the standings from a RoundRobin or season.
        /// </summary>
        /// <returns>Standings</returns>
        /// <param name="teams">Teams[]</param>
        public static Standings GetStandings(params Team [] teams)
        {
            return new Standings(teams);
        }
    }
}

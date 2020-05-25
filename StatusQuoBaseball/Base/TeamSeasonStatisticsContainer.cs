using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Team season statistics container.
    /// </summary>
    public class TeamSeasonStatisticsContainer:SeasonStatisticsContainer
    {
       
        private Team team;
        private int wins;
        private int losses;



        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/> class.
        /// </summary>
        /// <param name="player">Player.</param>
        private TeamSeasonStatisticsContainer(Player player) : base(player)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer"/> class.
        /// </summary>
        /// <param name="team">Team</param>
        public TeamSeasonStatisticsContainer(Team team):base(null)
        {
            this.team = team;
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>object</returns>
        public override object Clone()
        {
            return this.MemberwiseClone();
        }


        /// <summary>
        /// Logs the stat.
        /// </summary>
        /// <param name="result">GamePlayResult</param>
        /// <param name="toIncrement">int</param>
        public override void LogStat(GamePlayResult result, int toIncrement = 0)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Logs the game stats for the team
        /// </summary>
        public void LogTeamGameStats(int gameInningsPitched, bool wonGame=false)
        {
            foreach (Player p in this.team.Roster.Players)
            {
                if (p.BattingStatistics != null)
                {
                    AggregateBattingStatistics(p.BattingStatistics);
                }
                if (p.PitchingStatistics != null)
                {
                    AggregatePitchingStatistics(p.PitchingStatistics, gameInningsPitched);
                }
                if (p.FieldingStatistics != null)
                {
                    AggregateFieldingStatistics(p.FieldingStatistics);
                }

            }
            this.wins += wonGame ? 1 : 0;
            this.losses += wonGame ? 0 : 1;
        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public override void ClearStats()
        {
            this.seasonBattingStatistics.ClearStats();
            this.seasonPitchingStatistics.ClearStats();
            this.seasonFieldingStatistics.ClearStats();
        }

       
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret=new StringBuilder();
            ret.Append($"{this.team} W: {this.wins} L: {this.losses} Runs Scored: {this.SeasonBattingStatistics.Runs} Runs Allowed: {this.SeasonPitchingStatistics.RunsAllowed}");
            return ret.ToString();
        }

        /// <summary>
        /// Aggregates the batting statistics.
        /// </summary>
        /// <param name="gameBattingStatistics">Game batting statistics.</param>
        protected override void AggregateBattingStatistics(BattingStatisticsContainer gameBattingStatistics)
        {
            base.AggregateBattingStatistics(gameBattingStatistics);
        }

        /// <summary>
        /// Aggregates the pitching statistics.
        /// </summary>
        /// <param name="gamePitchingStatistics">Game pitching statistics.</param>
        /// <param name="gameInningsPitched">Game innings pitched.</param>
        protected override void AggregatePitchingStatistics(PitchingStatisticsContainer gamePitchingStatistics, int gameInningsPitched)
        {
            base.AggregatePitchingStatistics(gamePitchingStatistics, gameInningsPitched);
        }

        /// <summary>
        /// Aggregates the fielding statistics.
        /// </summary>
        /// <param name="gameFieldingStatistics">Game fielding statistics.</param>
        protected override void AggregateFieldingStatistics(FieldingStatisticsContainer gameFieldingStatistics)
        {
            base.AggregateFieldingStatistics(gameFieldingStatistics);
        }

        /// <summary>
        /// Gets the wins.
        /// </summary>
        /// <value>int</value>
        public int Wins { get => wins; }

        /// <summary>
        /// Gets the losses.
        /// </summary>
        /// <value>int</value>
        public int Losses { get => losses; }

        /// <summary>
        /// Gets the win-loss percentage.
        /// </summary>
        /// <value>double</value>
        public double WinLossPercentage
        {
            get
            {
                return wins / (double)(wins + losses);
            }
        }

        /// <summary>
        /// Gets the batting average.
        /// </summary>
        /// <value>double</value>
        public double BattingAverage
        {
            get
            {
                if (SeasonBattingStatistics.AtBats == 0)//avoid NaN
                    return 0.0;
                return SeasonBattingStatistics.Hits / (double)SeasonBattingStatistics.AtBats;
            }
        }
    }
}

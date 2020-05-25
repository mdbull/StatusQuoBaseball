using System;
using System.Collections.Generic;
using StatusQuoBaseball.Gameplay;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Season statistics container.
    /// </summary>
    public class SeasonStatisticsContainer : StatisticsContainer
    {
        /// <summary>
        /// The season batting stats.
        /// </summary>
        protected List<BattingStatisticsContainer> gameBattingStats = new List<BattingStatisticsContainer>();

        /// <summary>
        /// The game pitching stats.
        /// </summary>
        protected List<PitchingStatisticsContainer> gamePitchingStats = new List<PitchingStatisticsContainer>();

        /// <summary>
        /// The game fielding stats.
        /// </summary>
        protected List<FieldingStatisticsContainer> gameFieldingStats = new List<FieldingStatisticsContainer>();

        /// <summary>
        /// The season batting statistics.
        /// </summary>
        protected BattingStatisticsContainer seasonBattingStatistics = BattingStatisticsContainer.EmptyBattingStatisticsContainer;

        /// <summary>
        /// The season pitching statistics.
        /// </summary>
        protected PitchingStatisticsContainer seasonPitchingStatistics = PitchingStatisticsContainer.EmptyPitchingStatisticsContainer;

        /// <summary>
        /// The season fielding statistics.
        /// </summary>
        protected FieldingStatisticsContainer seasonFieldingStatistics = FieldingStatisticsContainer.EmptyFieldingStatisticsContainer;

        /// <summary>
        /// The total games played.
        /// </summary>
        protected int totalGamesPlayed;

        /// <summary>
        /// The total games started.
        /// </summary>
        protected int totalGamesStarted;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.SeasonStatisticsContainer"/> class.
        /// </summary>
        /// <param name="person">Person.</param>
        public SeasonStatisticsContainer(Person person) : base(person)
        {
            this.seasonBattingStatistics = new BattingStatisticsContainer((Player)this.person);
            this.seasonPitchingStatistics = new PitchingStatisticsContainer((Player)this.person);
            this.seasonFieldingStatistics = new FieldingStatisticsContainer((Player)this.person);
        }

        /// <summary>
        /// Will throw System.NotImplementedException. Use LogGameStats instead.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="toIncrement">To increment.</param>
        public override void LogStat(GamePlayResult result, int toIncrement)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public override void ClearStats()
        {
            this.gameBattingStats.Clear();
            this.gamePitchingStats.Clear();
            this.gameFieldingStats.Clear();
            this.seasonBattingStatistics.ClearStats();
            this.seasonPitchingStatistics.ClearStats();
            this.seasonFieldingStatistics.ClearStats();
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
        /// Logs the game stats.
        /// </summary>
        /// <param name="gameStatisticsToLog">StatisticsContainer</param>
        /// <param name="gameInningsPitched">int</param>
        public void LogGameStats(StatisticsContainer gameStatisticsToLog, int gameInningsPitched=0)
        {
            if (gameStatisticsToLog is BattingStatisticsContainer)
            {
                this.gameBattingStats.Add((BattingStatisticsContainer)gameStatisticsToLog);
                AggregateBattingStatistics((BattingStatisticsContainer)gameStatisticsToLog);
            }
            else if (gameStatisticsToLog is PitchingStatisticsContainer)
            {
                this.gamePitchingStats.Add((PitchingStatisticsContainer)gameStatisticsToLog);
                AggregatePitchingStatistics((PitchingStatisticsContainer)gameStatisticsToLog, gameInningsPitched);
            }
            else
            {
                this.gameFieldingStats.Add((FieldingStatisticsContainer)gameStatisticsToLog);
                AggregateFieldingStatistics((FieldingStatisticsContainer)gameStatisticsToLog);
            }
        }

        /// <summary>
        /// Aggregates the batting statistics.
        /// </summary>
        /// <param name="gameBattingStatistics">BattingStatisticsContainer</param>
        protected virtual void AggregateBattingStatistics(BattingStatisticsContainer gameBattingStatistics)
        {
            this.seasonBattingStatistics.PlateAppearances += gameBattingStatistics.PlateAppearances;
            this.seasonBattingStatistics.AtBats += gameBattingStatistics.AtBats;
            this.seasonBattingStatistics.Walks += gameBattingStatistics.Walks;
            this.seasonBattingStatistics.HitByPitches += gameBattingStatistics.HitByPitches;
            this.seasonBattingStatistics.GroundOuts += gameBattingStatistics.GroundOuts;
            this.seasonBattingStatistics.FlyOuts += gameBattingStatistics.FlyOuts;
            this.seasonBattingStatistics.Strikeouts += gameBattingStatistics.Strikeouts;
            this.seasonBattingStatistics.Singles += gameBattingStatistics.Singles;
            this.seasonBattingStatistics.Doubles += gameBattingStatistics.Doubles;
            this.seasonBattingStatistics.Triples += gameBattingStatistics.Triples;
            this.seasonBattingStatistics.Homeruns += gameBattingStatistics.Homeruns;
            this.seasonBattingStatistics.SacrificeFlyouts += gameBattingStatistics.SacrificeFlyouts;
            this.seasonBattingStatistics.StolenBases += gameBattingStatistics.StolenBases;
            this.seasonBattingStatistics.StealAttempts += gameBattingStatistics.StealAttempts;
            this.seasonBattingStatistics.Runs += gameBattingStatistics.Runs;
            this.seasonBattingStatistics.RBI += gameBattingStatistics.RBI;

        }

        /// <summary>
        /// Aggregates the pitching statistics.
        /// </summary>
        /// <param name="gamePitchingStatistics">PitchingStatisticsContainer</param>
        /// <param name="gameInningsPitched">int</param>
        protected virtual void AggregatePitchingStatistics(PitchingStatisticsContainer gamePitchingStatistics, int gameInningsPitched)
        {
            this.seasonPitchingStatistics.AtBats += gamePitchingStatistics.AtBats;
            this.seasonPitchingStatistics.BattersFaced += gamePitchingStatistics.BattersFaced;
            this.seasonPitchingStatistics.Balks += gamePitchingStatistics.Balks;
            this.seasonPitchingStatistics.HitByPitches += gamePitchingStatistics.HitByPitches;
            this.seasonPitchingStatistics.Walks += gamePitchingStatistics.Walks;
            this.seasonPitchingStatistics.Strikeouts += gamePitchingStatistics.Strikeouts;
            this.seasonPitchingStatistics.GroundOuts += gamePitchingStatistics.GroundOuts;
            this.seasonPitchingStatistics.FlyOuts += gamePitchingStatistics.FlyOuts;
            this.seasonPitchingStatistics.SacrificeFlyouts += gamePitchingStatistics.SacrificeFlyouts;
            this.seasonPitchingStatistics.Singles += gamePitchingStatistics.Singles;
            this.seasonPitchingStatistics.Doubles += gamePitchingStatistics.Doubles;
            this.seasonPitchingStatistics.Triples += gamePitchingStatistics.Triples;
            this.seasonPitchingStatistics.Homeruns += gamePitchingStatistics.Homeruns;
            this.seasonPitchingStatistics.RunsAllowed += gamePitchingStatistics.RunsAllowed;
            this.seasonPitchingStatistics.TotalOuts += gamePitchingStatistics.TotalOuts;
            this.seasonPitchingStatistics.Wins += gamePitchingStatistics.Wins;
            this.seasonPitchingStatistics.Losses += gamePitchingStatistics.Losses;
            this.seasonPitchingStatistics.Saves += gamePitchingStatistics.Saves;

            bool completeGamePitched = (int)gamePitchingStatistics.InningsPitched == gameInningsPitched;
            bool shutoutPitched = completeGamePitched && (gamePitchingStatistics.RunsAllowed == 0);
            bool perfectGame = (gamePitchingStatistics.BattersFaced == ((int)gameInningsPitched * 3)) && (gamePitchingStatistics.TotalOuts == ((int)gameInningsPitched * 3));

            if (completeGamePitched)
            {
                this.seasonPitchingStatistics.CompleteGames++;
                if (gamePitchingStatistics.Hits == 0)//no hitter!
                    this.seasonPitchingStatistics.NoHitters++;
            }

            if (perfectGame)//perfect game!!!
            { 
                this.seasonPitchingStatistics.PerfectGames++;
                this.seasonPitchingStatistics.NoHitters++;
            }

            if (shutoutPitched)
                this.seasonPitchingStatistics.Shutouts++;
        }

        /// <summary>
        /// Aggregates the fielding statistics.
        /// </summary>
        /// <param name="gameFieldingStatistics">FieldingStatisticsContainer</param>
        protected virtual void AggregateFieldingStatistics(FieldingStatisticsContainer gameFieldingStatistics)
        {
            this.seasonFieldingStatistics.Assists += gameFieldingStatistics.Assists;
            this.seasonFieldingStatistics.Putouts += gameFieldingStatistics.Putouts;
            this.seasonFieldingStatistics.Errors += gameFieldingStatistics.Errors;
            this.seasonFieldingStatistics.StolenBases += gameFieldingStatistics.StolenBases;
            this.seasonFieldingStatistics.StealAttemptsAgainst += gameFieldingStatistics.StealAttemptsAgainst;
        }

        /// <summary>
        /// Gets the individual game batting statistics of the player.
        /// </summary>
        /// <value>BattingStatisticsContainer[]</value>
        public BattingStatisticsContainer[] GameBattingStatistics
        {
            get
            {
                return this.gameBattingStats.ToArray();
            }
        }

        /// <summary>
        /// Gets the individual game pitching statistics of the player.
        /// </summary>
        /// <value>PitchingStatisticsContainer[]</value>
        public PitchingStatisticsContainer[] GamePitchingStatistics
        {
            get
            {
                return this.gamePitchingStats.ToArray();
            }
        }

        /// <summary>
        /// Gets the individual game fielding statistics of the player.
        /// </summary>
        /// <value>FieldingStatisticsContainer</value>
        public FieldingStatisticsContainer[] GameFieldingStatistics
        {
            get
            {
                return this.gameFieldingStats.ToArray();
            }
        }

        /// <summary>
        /// Gets the season batting statistics.
        /// </summary>
        /// <value>BattingStatisticsContainer</value>
        public BattingStatisticsContainer SeasonBattingStatistics { get => seasonBattingStatistics; }

        /// <summary>
        /// Gets the season pitching statistics.
        /// </summary>
        /// <value>PitchingStatisticsContainer</value>
        public PitchingStatisticsContainer SeasonPitchingStatistics { get => seasonPitchingStatistics; }

        /// <summary>
        /// Gets the season fielding statistics.
        /// </summary>
        /// <value>FieldingStatisticsContainer</value>
        public FieldingStatisticsContainer SeasonFieldingStatistics { get => seasonFieldingStatistics; }

        /// <summary>
        /// Gets or sets the total games played.
        /// </summary>
        /// <value>int</value>
        public int TotalGamesPlayed { get => totalGamesPlayed; set => totalGamesPlayed = value; }

        /// <summary>
        /// Gets or sets the total games started.
        /// </summary>
        /// <value>int</value>
        public int TotalGamesStarted { get => totalGamesStarted; set => totalGamesStarted = value; }
    }
}

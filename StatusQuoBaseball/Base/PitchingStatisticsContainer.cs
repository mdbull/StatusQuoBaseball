using System;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Sabermetrics pitching statistics container.
    /// </summary>
    public class SabermetricsPitchingStatisticsContainer : StatisticsContainer
    {
        private PitchingStatisticsContainer pStats;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer"/> class.
        /// </summary>
        /// <param name="person">Person.</param>
        public SabermetricsPitchingStatisticsContainer(Person person) : base(person)
        {
            this.pStats = ((Player)person).PitchingStats.PitchingStatistics;
        }

        /// <summary>
        /// This is not implemented
        /// </summary>
        public override void ClearStats()
        {
            throw new NotImplementedException();
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
        /// This is not implemented.
        /// </summary>
        /// <param name="result">GamePlayResult</param>
        /// <param name="toIncrement">int</param>
        public override void LogStat(GamePlayResult result, int toIncrement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the fielding independent pitching.
        /// </summary>
        /// <value>double</value>
        public double FieldingIndependentPitching
        {
            get
            {
                if (Math.Abs(this.pStats.InningsPitched - double.Epsilon) < double.Epsilon)
                    return 0;
                if (this.pStats.InningsPitched > 0)
                {
                    return ((13 * pStats.Homeruns + 3 * (this.pStats.HitByPitches + this.pStats.Walks) - 2 * this.pStats.Strikeouts) / this.pStats.InningsPitched) + SABRMetricsManager.GetFIPConstantByYear(((Player)this.person).Year);
                }
                return 0;
            }
        }

    }
    /// <summary>
    /// Batting stats container.
    /// </summary>
    public class PitchingStatisticsContainer : StatisticsContainer
    {
        /// <summary>
        /// The empty pitching statistics container.
        /// </summary>
        public static readonly PitchingStatisticsContainer EmptyPitchingStatisticsContainer = new PitchingStatisticsContainer(null);


        private int battersFaced;
        private int totalOuts; //used to get innings pitched
        private int atBats;
        private int balks;
        private int hitByPitches;
        private int walks;
        private int strikeouts;
        private int singles;
        private int doubles;
        private int triples;
        private int homeruns;
        private int runsAllowed;
        private int earnedRunsAllowed;
        private int groundOuts;
        private int flyOuts;
        private int sacrificeFlyouts;
        private int wins;
        private int losses;
        private int completeGames;
        private int pitchingGamesStarted;
        private int pitchingTotalGamesAppeared;
        private int pitchingTotalDecisions;
        private int saves;
        private int noHitters;
        private int perfectGames;
        private int shutouts;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/> class.
        /// </summary>
        /// <param name="player">Player.</param>
        public PitchingStatisticsContainer(Player player) : base(player)
        {

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
        /// <param name="result">Result.</param>
        /// <param name="toIncrement">Runs allowed.</param>
        public override void LogStat(GamePlayResult result, int toIncrement = 0)
        {

            if (toIncrement == 1)//temp way to distinguish run scored from other event
            {
                this.runsAllowed++;
            }
            else
            {
                this.atBats++;
                this.battersFaced++;
                if (result is Out)
                {
                    Out theOut = (Out)result;
                    if (!theOut.IsError)
                    {
                        if (result is Strikeout)
                        {
                            this.strikeouts++;

                        }
                        else if (result is GroundOut)
                        {
                            this.groundOuts++;

                        }
                        else if (result is Flyout)
                        {
                            this.flyOuts++;

                        }
                        else if (result is PopFlyOut)
                        {
                            this.flyOuts++;

                        }
                        else if (result is DeepFlyOut)
                        {
                            this.flyOuts++;

                        }
                        //This is taken care of in BattingStatisticsContainer.LogStat
                        //Because it is only a sacrifice fly if a run is driven in.
                        //else if (result is SacrificeFly)
                        //{
                        //    this.sacrificeFlyouts++;

                        //}

                        this.totalOuts++;
                    }
                }
                else
                {
                    if (result is Balk)
                    {
                        this.balks++;
                        this.atBats--;
                        this.battersFaced--;
                    }
                    else if (result is HitByPitch)
                    {
                        this.hitByPitches++;
                        this.atBats--;
                    }
                    else if (result is Walk)
                    {
                        this.walks++;
                        this.atBats--;
                    }
                    else if (result is StatusQuoBaseball.Gameplay.Single)
                    {
                        this.singles++;
                    }
                    else if (result is StatusQuoBaseball.Gameplay.Double)
                    {
                        this.doubles++;
                    }
                    else if (result is Triple)
                    {
                        this.triples++;
                    }
                    else if (result is HomeRun)
                    {
                        this.homeruns++;
                    }
                    else if (result is StealAttempt)
                    {
                        this.totalOuts++;
                        this.atBats--;
                    }
                }
            }

        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public override void ClearStats()
        {
             totalOuts = 0;
             atBats = 0;
             balks = 0;
             hitByPitches = 0;
             walks = 0;
             strikeouts = 0;
             singles = 0;
             doubles = 0;
             triples = 0;
             homeruns = 0;
             runsAllowed = 0;
             groundOuts = 0;
             flyOuts = 0;
             sacrificeFlyouts = 0;
             wins = 0;
             losses = 0;
             pitchingGamesStarted = 0;
             pitchingTotalGamesAppeared = 0;
             pitchingTotalDecisions = 0;
        }

        /// <summary>
        /// Gets or sets at bats.
        /// </summary>
        /// <value>int</value>
        public int AtBats { get => atBats; set => atBats = value; }

        /// <summary>
        /// Gets or sets the hit by pitches.
        /// </summary>
        /// <value>int</value>
        public int HitByPitches { get => hitByPitches; set => hitByPitches = value; }

        /// <summary>
        /// Gets or sets the walks.
        /// </summary>
        /// <value>int</value>
        public int Walks { get => walks; set => walks = value; }

        /// <summary>
        /// Gets or sets the hits.
        /// </summary>
        /// <value>int</value>
        public int Hits { get => (this.singles + this.doubles + this.triples + this.homeruns); }

        /// <summary>
        /// Gets or sets the singles.
        /// </summary>
        /// <value>int</value>
        public int Singles { get => singles; set => singles = value; }

        /// <summary>
        /// Gets or sets the doubles.
        /// </summary>
        /// <value>int</value>
        public int Doubles { get => doubles; set => doubles = value; }

        /// <summary>
        /// Gets or sets the triples.
        /// </summary>
        /// <value>int</value>
        public int Triples { get => triples; set => triples = value; }

        /// <summary>
        /// Gets or sets the homeruns.
        /// </summary>
        /// <value>int</value>
        public int Homeruns { get => homeruns; set => homeruns = value; }


        /// <summary>
        /// Gets or sets the ground outs.
        /// </summary>
        /// <value>int</value>
        public int GroundOuts { get => groundOuts; set => groundOuts = value; }

        /// <summary>
        /// Gets or sets the fly outs.
        /// </summary>
        /// <value>int</value>
        public int FlyOuts { get => flyOuts; set => flyOuts = value; }

        /// <summary>
        /// Gets or sets the total outs.
        /// </summary>
        /// <value>int</value>
        public int TotalOuts { get => totalOuts; set => totalOuts = value; }

        /// <summary>
        /// Gets the opposing batting average.
        /// </summary>
        /// <value>double</value>
        public double OpposingBattingAverage
        {
            get
            {
                if(atBats > 0)
                    return (double)Hits / (double)atBats;
                return 0;
            }
        }

        /// <summary>
        /// Gets the on base percentage allowed.
        /// </summary>
        /// <value>double</value>
        public double OnBasePercentageAllowed
        {
            get
            {   
                if(battersFaced > 0)
                    return (double)(Hits + walks + hitByPitches) / (double)(atBats+ walks + hitByPitches + sacrificeFlyouts);
                return 0.0;
            }
        }

        /// <summary>
        /// Gets the opposing slugging percentage.
        /// </summary>
        /// <value>double</value>
        public double OpposingSluggingPercentage
        {
            get
            {
                if(atBats > 0)
                    return (double)(singles + (doubles * 2) + (triples * 3) + (homeruns * 4)) / (double)atBats;
                return 0;
            }
        }

        /// <summary>
        /// Sets the earned run average.
        /// </summary>
        /// <value>double</value>
        public double EarnedRunAverage
        {
            get
            {
                if (earnedRunsAllowed == 0)
                    earnedRunsAllowed = runsAllowed;
                if (this.InningsPitched > 0)
                {
                    return this.earnedRunsAllowed * Convert.ToDouble(Configuration.ConfigurationManager.GetConfigurationValue("CURRENT_NUM_INNINGS_REGULATION")) / this.InningsPitched;
                }
                if (this.totalOuts == 0 && this.earnedRunsAllowed > 0)
                    return double.PositiveInfinity;
                return 0;
            }
        }

        /// <summary>
        /// Gets the fielding independent pitching.
        /// </summary>
        /// <value>double</value>
        public double FieldingIndependentPitching
        {
            get
            {
                if (Math.Abs(InningsPitched - double.Epsilon) < double.Epsilon)
                    return 0;
                if (this.InningsPitched > 0)
                {
                    return ((13 * homeruns + 3 * (hitByPitches + walks) - 2 * strikeouts) / this.InningsPitched) + SABRMetricsManager.GetFIPConstantByYear(((Player)this.person).Year);
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the strikeouts.
        /// </summary>
        /// <value>int</value>
        public int Strikeouts { get => strikeouts; set => strikeouts = value; }

        /// <summary>
        /// Gets or sets the sacrifice flyouts.
        /// </summary>
        /// <value>int</value>
        public int SacrificeFlyouts { get => sacrificeFlyouts; set => sacrificeFlyouts = value; }

        /// <summary>
        /// Gets the runs allowed.
        /// </summary>
        /// <value>int</value>
        public int RunsAllowed { get => runsAllowed; set => runsAllowed = value; }

        /// <summary>
        /// Gets the balks.
        /// </summary>
        /// <value>int</value>
        public int Balks { get => balks; set => balks = value; }

        /// <summary>
        /// Gets the innings pitched.
        /// </summary>
        /// <value>double</value>
        public double InningsPitched
        {
            get 
            {
                if (totalOuts % 3 == 0)
                    return totalOuts / 3;
                return Constants.RoundDown(totalOuts / 3.0,1);
            }
        }

        /// <summary>
        /// Gets or sets the wins.
        /// </summary>
        /// <value>int</value>
        public int Wins { get => wins; set => wins = value; }

        /// <summary>
        /// Gets or sets the losses.
        /// </summary>
        /// <value>int</value>
        public int Losses { get => losses; set => losses = value; }

        /// <summary>
        /// Gets the win-loss percentage.
        /// </summary>
        /// <value>double</value>
        public double WinLossPercentage
        {
            get 
            {   if(pitchingTotalDecisions > 0 && wins>0)
                    return (wins / pitchingTotalDecisions);
                return 0.0;
            }
        }

        /// <summary>
        /// Gets or sets the games started.
        /// </summary>
        /// <value>int</value>
        public int PitchingGamesStarted { get => pitchingGamesStarted; set => pitchingGamesStarted = value; }

        /// <summary>
        /// Gets or sets the total games appeared.
        /// </summary>
        /// <value>int</value>
        public int PitchingTotalGamesAppeared { get => pitchingTotalGamesAppeared; set => pitchingTotalGamesAppeared = value; }

        /// <summary>
        /// Gets or sets the saves.
        /// </summary>
        /// <value>int</value>
        public int Saves { get => saves; set => saves = value; }

        /// <summary>
        /// Gets or sets the pitching total decisions.
        /// </summary>
        /// <value>int</value>
        public int PitchingTotalDecisions { get => pitchingTotalDecisions; set => pitchingTotalDecisions = value; }

        /// <summary>
        /// Gets or sets the complete games.
        /// </summary>
        /// <value>int</value>
        public int CompleteGames { get => completeGames; set => completeGames = value; }

        /// <summary>
        /// Gets or sets the no hitters.
        /// </summary>
        /// <value>int</value>
        public int NoHitters { get => noHitters; set => noHitters = value; }

        /// <summary>
        /// Gets or sets the perfect games.
        /// </summary>
        /// <value>int</value>
        public int PerfectGames { get => perfectGames; set => perfectGames = value; }

        /// <summary>
        /// Gets or sets the batters faced.
        /// </summary>
        /// <value>int</value>
        public int BattersFaced { get => battersFaced; set => battersFaced = value; }

        /// <summary>
        /// Gets or sets the shutouts.
        /// </summary>
        /// <value>int</value>
        public int Shutouts { get => shutouts; set => shutouts = value; }

        /// <summary>
        /// Gets or sets the earned runs allowed.
        /// </summary>
        /// <value>The earned runs allowed.</value>
        public int EarnedRunsAllowed 
        {
            get
            {
                if (earnedRunsAllowed == 0)
                    return runsAllowed;//Temp case as I haven't distinguished between earned and unearned runs allowed
                return earnedRunsAllowed;
            }
            set
            { 
                earnedRunsAllowed = value; 
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.PitchingStatisticsContainer"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"ERA={this.EarnedRunAverage:0.00}, IP={this.InningsPitched:0.0}, H={this.Hits}, RunsAllowed={this.runsAllowed}, BB={this.walks}, K={this.strikeouts}");
            return ret.ToString();
        }


    }
}


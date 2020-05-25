using System;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Batting stats container.
    /// </summary>
    public class BattingStatisticsContainer : StatisticsContainer
    {
        /// <summary>
        /// The empty batting statistics container.
        /// </summary>
        public static readonly BattingStatisticsContainer EmptyBattingStatisticsContainer = new BattingStatisticsContainer(null);

        private int plateAppearances;
        private int atBats;
        private int hitByPitches;
        private int walks;
        private int strikeouts;
        private int singles;
        private int doubles;
        private int triples;
        private int homeruns;
        private int runsBattedIn;
        private int runs;
        private int stolenBases;
        private int stealAttempts;
        private int groundOuts;
        private int flyOuts;
        private int sacrificeFlyouts;
      
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.BattingStatisticsContainer"/> class.
        /// </summary>
        public BattingStatisticsContainer():base(null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.BattingStatsContainer"/> class.
        /// </summary>
        /// <param name="player">Player.</param>
        public BattingStatisticsContainer(Player player) : base(player)
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
        /// <param name="result">GamePlayResult</param>
        /// <param name="toIncrement">If set to <c>1</c> is run.</param>
        public override void LogStat(GamePlayResult result, int toIncrement = 0)
        {
            if (toIncrement == 1)
            {
                this.runs++;
            }
            else if (toIncrement == 2)//rbi
            {
                this.runsBattedIn++;
                if (result is SacrificeFly)
                {
                    this.sacrificeFlyouts++;
                    result.Pitcher.PitchingStatistics.SacrificeFlyouts++;
                }
            }
            else
            {
                this.plateAppearances++;
                this.atBats++;
                if (result is HitByPitch)
                {
                    this.hitByPitches++;
                    this.atBats--;
                }
                else if (result is Walk)
                {
                    this.walks++;
                    this.atBats--;
                }
                else if (result is Strikeout)
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
                    this.stealAttempts++;
                    this.plateAppearances--;
                    this.atBats--;
                    if (((StealAttempt)result).WasSuccessful)
                        this.stolenBases++;
                }
            }

        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public override void ClearStats()
        {
             plateAppearances = 0;
             atBats = 0;
             hitByPitches = 0;
             walks = 0;
             strikeouts = 0;
             singles = 0;
             doubles = 0;
             triples = 0;
             homeruns = 0;
             runsBattedIn = 0;
             runs = 0;
             stealAttempts = 0;
             stolenBases = 0;
             groundOuts = 0;
             flyOuts = 0;
             sacrificeFlyouts = 0;
        }


        /// <summary>
        /// Gets or sets the plate appearances.
        /// </summary>
        /// <value>int</value>
        public int PlateAppearances { get => plateAppearances; set => plateAppearances = value; }

        /// <summary>
        /// Gets or sets at bats.
        /// </summary>
        /// <value>int</value>
        public int AtBats { get => atBats; set => atBats=value; }

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
        /// Gets or sets the runs.
        /// </summary>
        /// <value>int</value>
        public int Runs { get => runs; set => runs = value; }

        /// <summary>
        /// Gets or sets the stolen bases.
        /// </summary>
        /// <value>int</value>
        public int StolenBases { get => stolenBases; set => stolenBases = value; }

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
        /// Gets or sets the runs batted in.
        /// </summary>
        /// <value>int</value>
        public int RBI { get => runsBattedIn; set => runsBattedIn = value; }

        /// <summary>
        /// Gets the batting average.
        /// </summary>
        /// <value>double</value>
        public double BattingAverage
        {
            get
            {
                if (atBats == 0)//avoid NaN
                    return 0.0;
                if (Hits == 0 && atBats > 0)
                    return 0.0;
                return (double)Hits / (double)atBats;
            }
        }

        /// <summary>
        /// Gets the on base percentage.
        /// </summary>
        /// <value>double</value>
        public double OnBasePercentage
        {
            get
            {
                if (atBats == 0)
                    return 0.0;
                int timesOnBase = Hits + walks + hitByPitches;
                if (timesOnBase == 0)
                    return 0.0;
                return (double)timesOnBase / (double)(atBats + walks + hitByPitches + sacrificeFlyouts);
            }
        }

        /// <summary>
        /// Gets the slugging percentage.
        /// </summary>
        /// <value>double</value>
        public double SluggingPercentage
        {
            get
            {
                if (atBats == 0)
                    return 0.0;
                return (double)(singles + (doubles * 2) + (triples * 3) + (homeruns * 4)) / (double)atBats;
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
        /// Gets or sets the steal attempts.
        /// </summary>
        /// <value>int</value>
        public int StealAttempts { get => stealAttempts; set => stealAttempts = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.BattingStatsContainer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.BattingStatsContainer"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"PA={this.plateAppearances}, AB={this.atBats}, H={this.Hits}, HR={this.homeruns}, RBI={this.runsBattedIn}, R={this.runs}, AVG={this.BattingAverage:0.000}, OBP={this.OnBasePercentage:0.000}, SLG={this.SluggingPercentage:0.000}");

            return ret.ToString();
        }
    }
}

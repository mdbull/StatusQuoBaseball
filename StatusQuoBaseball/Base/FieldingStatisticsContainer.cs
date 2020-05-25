using System;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Fielding statistics container.
    /// </summary>
    public class FieldingStatisticsContainer:StatisticsContainer
    {
        /// <summary>
        /// The empty fielding statistics container.
        /// </summary>
        public static readonly FieldingStatisticsContainer EmptyFieldingStatisticsContainer = new FieldingStatisticsContainer(null);

        private int errors;
        private int assists;
        private int putouts;
        private int stealAttemptsAgainst;
        private int stolenBases;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.FieldingStatisticsContainer"/> class.
        /// </summary>
        /// <param name="player">Player</param>
        public FieldingStatisticsContainer(Player player):base(player)
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
        /// <param name="toIncrement">int</param>
        public override void LogStat(GamePlayResult result, int toIncrement=0)
        {
            if(result is Error)
            {
                this.errors++;
            }
            else if(result is Out)
            {
                this.putouts++;
            }
            else if(result is StealAttempt)
            {
                this.stealAttemptsAgainst++;
                if (((StealAttempt)result).WasSuccessful)
                    this.stolenBases++;
            }

        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public override void ClearStats()
        {
            this.assists = this.putouts = this.errors = this.stolenBases = this.stealAttemptsAgainst = 0;
        }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>int</value>
        public int Errors { get => errors; set => errors=value; }

        /// <summary>
        /// Gets the total chances.
        /// </summary>
        /// <value>int</value>
        public int TotalChances { get => this.assists+this.putouts+this.errors;  }

        /// <summary>
        /// Gets or sets the assists.
        /// </summary>
        /// <value>int</value>
        public int Assists { get => assists; set => assists = value; }

        /// <summary>
        /// Gets the putouts.
        /// </summary>
        /// <value>int</value>
        public int Putouts { get =>putouts; set => putouts=value; }

        /// <summary>
        /// Gets the fielding percentage.
        /// </summary>
        /// <value>double</value>
        public double FieldingPercentage
        {
            get 
            {
                if (TotalChances == 0)
                    return 0;
                return (this.assists + this.putouts) / this.TotalChances;
            } 
        }

        /// <summary>
        /// Gets the caught stealing percentage.
        /// </summary>
        /// <value>double</value>
        public double CaughtStealingPercentage
        {
            get
            {
                if (stealAttemptsAgainst == 0)
                    return 0;
                return 1 - ((this.stolenBases) / this.stealAttemptsAgainst);
            }
        }

        /// <summary>
        /// Gets or sets the steal attempts against.
        /// </summary>
        /// <value>int</value>
        public int StealAttemptsAgainst { get => stealAttemptsAgainst; set => stealAttemptsAgainst = value; }

        /// <summary>
        /// Gets or sets the stolen bases.
        /// </summary>
        /// <value>int</value>
        public int StolenBases { get => stolenBases; set => stolenBases = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.FieldingStatisticsContainer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.FieldingStatisticsContainer"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"TotalChances={this.TotalChances}, A={this.assists}, PO={this.putouts}, E={this.errors}, PCT={this.FieldingPercentage:0.000}");

            return ret.ToString();
        }
    }
}

using System;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Coaching stats.
    /// </summary>
    public class CoachingStats
    {
        private int rating;
        private int prestige;
        private int minimumStealSpeed=50;
        private int steal2ndBase;
        private int steal3rdBase;
        private int sacrificeBunt;
        private int intentionalWalk;
        private int substituteThreshold = 10;
        private int wins;
        private int losses;
        private double winLossPct;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.CoachingStats"/> class.
        /// </summary>
        /// <param name="managerialTendencies">Managerial tendencies.</param>
        public CoachingStats(InMemoryConfigurationFile managerialTendencies)
        {
            this.rating = Convert.ToInt32(Convert.ToDouble(managerialTendencies["winPct"]) * 100);
            this.rating = Convert.ToInt32(rating * Convert.ToDouble(ConfigurationManager.GetConfigurationValue("PROFESSIONAL_COACH_RATING_MODIFIER")));
            if (this.rating > 100)
                this.rating = 100;
            this.prestige = Convert.ToInt32(Convert.ToDouble(managerialTendencies["accolades"]) * Convert.ToDouble(ConfigurationManager.GetConfigurationValue("PROFESSIONAL_COACH_PRESTIGE_MODIFIER")));
            if (this.prestige > 100)
                this.prestige = 100;
            this.steal2ndBase = Convert.ToInt32(Convert.ToDouble(managerialTendencies["steal2nd"]));
            this.steal2ndBase = this.steal2ndBase < 1 ? this.steal2ndBase = 1 : this.steal2ndBase = 0;
            this.steal3rdBase = Convert.ToInt32(Convert.ToDouble(managerialTendencies["steal3rd"]));
            this.steal3rdBase = this.steal3rdBase < 1 ? this.steal3rdBase = 1 : this.steal3rdBase = 0;
            this.sacrificeBunt = Convert.ToInt32(Convert.ToDouble(managerialTendencies["sacBunt"]));
            this.sacrificeBunt = this.sacrificeBunt < 1 ? this.sacrificeBunt = 1 : this.sacrificeBunt = 0;
            this.intentionalWalk = Convert.ToInt32(Convert.ToDouble(managerialTendencies["IBB"]));
            this.intentionalWalk = this.intentionalWalk < 1 ? this.intentionalWalk = 1 : this.intentionalWalk = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.CoachingStats"/> class.
        /// </summary>
        /// <param name="rating">int</param>
        /// <param name="prestige">int</param>
        /// <param name="steal2ndBase">int</param>
        /// <param name="steal3rdBase">int</param>
        /// <param name="sacrificeBunt">int</param>
        /// <param name="intentionalWalk">int</param>
        /// <param name="substituteThreshold">double</param>
        /// <param name="wins">int</param>
        /// <param name="losses">int</param>
        public CoachingStats(int rating, int prestige, int steal2ndBase, int steal3rdBase, int sacrificeBunt, int intentionalWalk, int substituteThreshold, int wins=0, int losses=0)
        {
            this.rating = rating;
            this.prestige = prestige;
            this.steal2ndBase = steal2ndBase;
            this.steal3rdBase = steal3rdBase;
            this.sacrificeBunt = sacrificeBunt;
            this.intentionalWalk = intentionalWalk;
            this.substituteThreshold = substituteThreshold;
            this.wins = wins;
            this.losses = losses;
            this.winLossPct = (double)wins / (double)(wins+losses);
        }

        /// <summary>
        /// Gets or sets the rating of the coach.
        /// </summary>
        /// <value>int</value>
        public int Rating { get => rating; }

        /// <summary>
        /// Gets or sets the prestige of the coach.
        /// </summary>
        /// <value>int</value>
        public int Prestige { get => prestige;}

        /// <summary>
        /// Gets or sets the manager's tendency to steal 2nd base.
        /// </summary>
        /// <value>int</value>
        public int Steal2ndBase { get => steal2ndBase; set => steal2ndBase = value; }

        /// <summary>
        /// Gets or sets the manager's tendency to steal 3rd base.
        /// </summary>
        /// <value>int</value>
        public int Steal3rdBase { get => steal3rdBase; set => steal3rdBase = value; }

        /// <summary>
        /// Gets or sets the manager's tendency to call a sacrifice bunt.
        /// </summary>
        /// <value>int</value>
        public int SacrificeBunt { get => sacrificeBunt; set => sacrificeBunt = value; }

        /// <summary>
        /// Gets or sets the manager's tendency to call an IBB.
        /// </summary>
        /// <value>int</value>
        public int IntentionalWalk { get => intentionalWalk; set => intentionalWalk = value; }

        /// <summary>
        /// Gets or sets the threshold at which a coach will replace a player. E.g., player stamina at 25% of original.
        /// </summary>
        /// <value>double</value>
        public int SubstituteThreshold { get => substituteThreshold; set => substituteThreshold = value; }

        /// <summary>
        /// Gets the wins.
        /// </summary>
        /// <value>int</value>
        public int Wins { get => wins; }

        /// <summary>
        /// Gets the losses.
        /// </summary>
        /// <value>int</value>
        public int Losses { get => losses;  }

        /// <summary>
        /// Gets the window loss percentage.
        /// </summary>
        /// <value>double</value>
        public double WinLossPercentage { get => winLossPct; }

        /// <summary>
        /// Gets or sets the minimum steal speed at which a coach will consider a steal
        /// </summary>
        /// <value>int</value>
        public int MinimumStealSpeed { get => minimumStealSpeed; set => minimumStealSpeed = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.CoachingStats"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.CoachingStats"/>.</returns>
        public override string ToString()
        {
            string ret = $"Rating: {this.rating}, Prestige: {this.prestige}";
            if (wins > 0 && losses > 0)
                ret += $"\nW-L: {this.wins}-{this.losses}\nW-L Pct:{this.winLossPct.ToString("0.000")}";
            return ret;
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Triple.
    /// </summary>
    public class Triple:Hit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Triple"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public Triple(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect 3B
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina-=5;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-=15;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Triple"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Triple"/>.</returns>
        public override string ToString()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return String.Format("{0} gives up a triple to {1}!!!", controllingPlayer, nonControllingPlayer);
            }
            return String.Format("{0} rips a triple off {1}!!!", controllingPlayer, nonControllingPlayer);
        }
    }
}

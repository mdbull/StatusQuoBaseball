using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Single.
    /// </summary>
    public class Single:Hit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Single"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public Single(Player controllingPlayer, Player nonControllingPlayer, Player batter=null):base(controllingPlayer,nonControllingPlayer, batter)
        {

        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect 1B
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina--;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-=5;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Single"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Single"/>.</returns>
        public override string ToString()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return String.Format("{0} gives up a single to {1}!", controllingPlayer, nonControllingPlayer);
            }
            return String.Format("{0} lines a single off {1}!", controllingPlayer, nonControllingPlayer);
        }
    }
}

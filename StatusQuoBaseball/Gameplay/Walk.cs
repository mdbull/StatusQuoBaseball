using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Walk.
    /// </summary>
    public class Walk:OtherResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Walk"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public Walk(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }


        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect BB
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina--;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-=3;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Walk"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Walk"/>.</returns>
        public override string ToString()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return String.Format("{0} walks {1}.", controllingPlayer, nonControllingPlayer);
            }
            return String.Format("{0} is walked by {1}!", controllingPlayer, nonControllingPlayer);
        }
    }
}

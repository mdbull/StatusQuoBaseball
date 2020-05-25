using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Hit by pitch.
    /// </summary>
    public class HitByPitch:OtherResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.HitByPitch"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public HitByPitch(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect H
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina -= 10;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-=5;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.HitByPitch"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.HitByPitch"/>.</returns>
        public override string ToString()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return String.Format("{0} hits {1} with a pitch!", controllingPlayer, nonControllingPlayer);
            }
            return String.Format("{0} is hit by {1}!", controllingPlayer, nonControllingPlayer);
        }
    }
}

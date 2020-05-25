using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Home run.
    /// </summary>
    public class HomeRun:Hit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.HomeRun"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public HomeRun(Player controllingPlayer, Player nonControllingPlayer,Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect H
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina -= 5;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina -= 20;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.HomeRun"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.HomeRun"/>.</returns>
        public override string ToString()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return String.Format("{0} gives up a homerun to {1}!!!!", controllingPlayer, nonControllingPlayer);
            }
            return String.Format("{0} rips a homerun off {1}!!!!", controllingPlayer, nonControllingPlayer);
        }
    }
}

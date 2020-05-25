using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Balk.
    /// </summary>
    public class Balk:OtherResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Balk"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public Balk(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-=2;
        }

    }
}

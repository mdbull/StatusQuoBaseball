using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Hit.
    /// </summary>
    public abstract class Hit:GamePlayResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Hit"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Controlling player.</param>
        /// <param name="nonControllingPlayer">Non controlling player.</param>
        /// <param name="batter">Player</param>
        protected Hit(Player controllingPlayer,Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
        }
    }
}

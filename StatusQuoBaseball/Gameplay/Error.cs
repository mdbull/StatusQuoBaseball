using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Error.
    /// </summary>
    public class Error:OtherResult
    {
        private Player fielder = NullPlayer.EmptyPlayer;
        private Out outType;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Error"/> class.
        /// </summary>
        public Error(Player fielder, Out outType, Player controllingPlayer, Player nonControllingPlayer, Player batter=null):base(controllingPlayer, nonControllingPlayer,batter)
        {
            this.fielder = fielder;
            this.outType = outType;
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            this.fielder.FieldingStatistics.LogStat(this);
            this.fielder.CurrentStamina -= 3;

        }

        /// <summary>
        /// Gets the fielder.
        /// </summary>
        /// <value>The fielder.</value>
        public Player Fielder { get => fielder; }

        /// <summary>
        /// Gets the type of the out.
        /// </summary>
        /// <value>The type of the out.</value>
        public Out OutType { get => outType; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Error"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Error"/>.</returns>
        public override string ToString()
        {
            return String.Format($"{this.fielder} commits an error!");
        }
    }
}

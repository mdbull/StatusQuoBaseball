using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Deep fly out.
    /// </summary>
    public class DeepFlyOut:Flyout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.DeepFlyOut"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Controlling player.</param>
        /// <param name="nonControllingPlayer">Non controlling player.</param>
        /// <param name="batter">Player</param>
        public DeepFlyOut(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            outLocation = GetFieldLocation();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            CheckForError();
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            this.batter.BattingStatistics.LogStat(this);
            this.batter.CurrentStamina -= 2;
            this.Pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina-= 3;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.DeepFlyOut"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.DeepFlyOut"/>.</returns>
        public override string ToString()
        {
            return String.Format($"{batter} flies out to deep {outLocation}.");
        }
    }
}

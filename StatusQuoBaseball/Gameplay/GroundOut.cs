using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Ground out.
    /// </summary>
    public class GroundOut:Out
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.GroundOut"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Controlling player.</param>
        /// <param name="nonControllingPlayer">Non controlling player.</param>
        /// <param name="batter">Player</param>
        public GroundOut(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
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
            this.batter.CurrentStamina -= 1;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina -= 1;
        }

        /// <summary>
        /// Gets the field location.
        /// </summary>
        /// <returns>FieldLocation</returns>
        protected override FieldLocation GetFieldLocation()
        {
            return (FieldLocation)Out.InfieldOutLocations[Dice.Roll(1, Out.InfieldOutLocations.Length)-1];
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.GroundOut"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.GroundOut"/>.</returns>
        public override string ToString()
        {
            return String.Format($"{this.batter} grounds out to {this.outLocation}.");

        }
    }
}

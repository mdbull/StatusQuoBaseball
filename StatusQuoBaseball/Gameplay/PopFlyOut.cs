﻿using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Pop fly out.
    /// </summary>
    public class PopFlyOut : Flyout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.PopFlyOut"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public PopFlyOut(Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
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
            this.batter.CurrentStamina--;
            this.pitcher.PitchingStatistics.LogStat(this);
            this.pitcher.CurrentStamina--;
        }

        /// <summary>
        /// Gets the field location of the pop fly out.
        /// </summary>
        /// <returns>FieldLocation</returns>
        protected override FieldLocation GetFieldLocation()
        {
            return (FieldLocation)Out.InfieldOutLocations[Dice.Roll(1, Out.InfieldOutLocations.Length) - 1];
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.PopFlyOut"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.PopFlyOut"/>.</returns>
        public override string ToString()
        {
            return String.Format("{0} pops out to {1}.", batter,this.outLocation);
        }
    }
}

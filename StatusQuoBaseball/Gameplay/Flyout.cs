using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Flyout.
    /// </summary>
    public class Flyout:Out
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Flyout"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public Flyout(Player controllingPlayer,Player nonControllingPlayer,Player batter=null) : base(controllingPlayer, nonControllingPlayer,batter)
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            outLocation = GetFieldLocation();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            CheckForError();
        }

        /// <summary>
        /// Gets the field location.
        /// </summary>
        /// <returns>FieldLocation</returns>
        protected override FieldLocation GetFieldLocation()
        {
            return (FieldLocation)Dice.Roll(7, 9);
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
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Flyout"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Flyout"/>.</returns>
        public override string ToString()
        {
           return String.Format("{0} flies out to {1}.", batter,outLocation);
           
        }
    }
}

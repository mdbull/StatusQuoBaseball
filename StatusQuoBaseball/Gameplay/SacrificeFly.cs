using System;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Sacrifice fly.
    /// </summary>
    public class SacrificeFly:Flyout
    {
        private Inning inning;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.SacrificeFly"/> class.
        /// </summary>
        /// <param name="inning">Inning</param>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        public SacrificeFly(Inning inning, Player controllingPlayer, Player nonControllingPlayer, Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
            this.inning = inning;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            outLocation = GetFieldLocation();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            CheckForError();
        }

        /// <summary>
        /// Execute this instance.
        /// <remarks>Outs and stats are already logged in the DeepFlyOut class.</remarks>
        /// <remarks>Sacrifice fly only handles the base runner movement.</remarks>
        /// </summary>
        public override void Execute()
        {
            //sacrifice flies do not count as at bats

            this.batter.BattingStatistics.AtBats--;
            this.pitcher.PitchingStatistics.AtBats--;
            Game theGame = this.inning.Game;
           
            //Only difference is the batter is NOT placed because he is out. The other runners will move
            //TODO: Add logic for outfielders throwing out runners (need to calculate arm strength first!)

            try
            {
                theGame.Bases.PlaceBatter(this.inning.TeamAtBat, null, this.inning.CurrentAtBat.Pitcher, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Gets the field location of the pop fly out.
        /// </summary>
        /// <returns>FieldLocation</returns>
        protected override FieldLocation GetFieldLocation()
        {
            return (FieldLocation)Dice.Roll(7, 9);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.DeepFlyOut"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.DeepFlyOut"/>.</returns>
        public override string ToString()
        {
            return String.Format($"{batter} has a sacrifice fly to deep {outLocation}!");
        }
    }
}

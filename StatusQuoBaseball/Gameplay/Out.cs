using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Out.
    /// </summary>
    public abstract class Out : GamePlayResult
    {
        /// <summary>
        /// The infield out locations.
        /// </summary>
        public static readonly int[] InfieldOutLocations = { 1, 1, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6 };

        /// <summary>
        /// The out location.
        /// </summary>
        protected FieldLocation outLocation = FieldLocation.Unknown;

        private Player fielder;
        private bool isError;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Out"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        protected Out(Player controllingPlayer, Player nonControllingPlayer,Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
           
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute() { }


        /// <summary>
        /// Checks for error.
        /// </summary>
        protected virtual void CheckForError()
        {
            //find fielder
            string positionOfFielder = Positions.PositionNames[(int)this.outLocation - 1];
            this.fielder = GetFielder(positionOfFielder, pitcher);

            int errorThreshold = 0;

            if (fielder.FieldingStats != null)
            {
                if (this is Flyout)
                {
                    errorThreshold = fielder.FieldingStats.FlyoutError;
                }
                else if (this is GroundOut)
                {
                    errorThreshold = fielder.FieldingStats.GroundballError;
                }

                this.isError |= Dice.Roll2d10() <= errorThreshold;
            }
        }

        /// <summary>
        /// Gets the fielder.
        /// </summary>
        /// <returns>Player</returns>
        /// <param name="positionOfFielder">string</param>
        /// <param name="pitcher">Player</param>
        protected virtual Player GetFielder(string positionOfFielder, Player pitcher)
        {
            if (pitcher.Team != null)
            {
                foreach (Player p in pitcher.Team.Roster.Lineup)
                {
                    if (p.CurrentPosition == positionOfFielder)
                        return p;
                }
            }
            return NullPlayer.EmptyPlayer;
        }

        /// <summary>
        /// Gets the field location.
        /// </summary>
        /// <returns>The field location.</returns>
        protected virtual FieldLocation GetFieldLocation()
        {
            return FieldLocation.Unknown;
        }

        /// <summary>
        /// Gets the out location.
        /// </summary>
        /// <value>The out location.</value>
        public FieldLocation OutLocation
        {
            get { return outLocation; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Out"/> is error.
        /// </summary>
        /// <value><c>true</c> if is error; otherwise, <c>false</c>.</value>
        public bool IsError { get => isError; }

        /// <summary>
        /// Gets the fielder.
        /// </summary>
        /// <value>The fielder.</value>
        public Player Fielder { get => fielder;}
    }
}

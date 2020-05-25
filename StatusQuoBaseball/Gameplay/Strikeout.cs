using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Strikeout.
    /// </summary>
    public class Strikeout:Out
    {

        private StrikeoutType strikeoutType = StrikeoutType.Unknown;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Strikeout"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Controlling player.</param>
        /// <param name="nonControllingPlayer">Non controlling player.</param>
        /// <param name="batter">Player</param>
        public Strikeout(Player controllingPlayer, Player nonControllingPlayer,Player batter=null) : base(controllingPlayer, nonControllingPlayer, batter)
        {
            this.strikeoutType = GetStrikeoutType();
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            //Update statistics for batter and pitcher to reflect K
            this.batter.BattingStatistics.LogStat(this, 0);
            this.batter.CurrentStamina-=10;
            this.pitcher.PitchingStatistics.LogStat(this,0);
            this.pitcher.CurrentStamina-=2;
        }

        /// <summary>
        /// Gets the type of the strikeout.
        /// </summary>
        /// <returns>StrikeoutType</returns>
        private StrikeoutType GetStrikeoutType()
        {
            if (controllingPlayer.CurrentPosition == "P")
            {
                return (StrikeoutType)Dice.Roll(1, 2);
            }
            return (StrikeoutType)Dice.Roll(1, 3);
        }

        /// <summary>
        /// Gets the type of the strikeout.
        /// </summary>
        /// <value>StrikeoutType</value>
        public StrikeoutType StrikeoutType { get => strikeoutType; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Strikeout"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Strikeout"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            if (controllingPlayer.CurrentPosition == "P")
            {
                if (this.strikeoutType == StrikeoutType.Swinging)
                {
                    ret.AppendFormat($"{this.pitcher} strikes out {this.batter}!");
                }
                else if (this.strikeoutType == StrikeoutType.Looking)
                {
                    ret.AppendFormat($"{this.pitcher} catches {this.batter} looking. Strike 3!");
                }
            }
            else
            {
                switch (strikeoutType)
                {
                    case StrikeoutType.Swinging:
                        ret.AppendFormat($"{batter} goes down swinging!");
                        break;
                    case StrikeoutType.Looking:
                        ret.AppendFormat($"{batter} is caught looking. Strike 3!");
                        break;
                    case StrikeoutType.FoulTip:
                        ret.AppendFormat("Foul tip. Strike 3!");
                        break;
                }
            }
            return ret.ToString();
        }
    }
}

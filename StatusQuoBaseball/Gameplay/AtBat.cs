using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{

    /// <summary>
    /// At bat.
    /// </summary>
    [Serializable]
    public class AtBat:IExecutable
    {
        /// <summary>
        /// Occurs when game play result handled.
        /// </summary>
        public event GamePlayResultEventHandler gamePlayResultHandled = null;

        private Inning inning;
        private Player batter;
        private Player pitcher;
        private GamePlayResult result;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.AtBat"/> class.
        /// </summary>
        /// <param name="batter">Batter</param>
        /// <param name="pitcher">Pitcher</param>
        /// <param name="inning">Inning</param>
        public AtBat(Player batter, Player pitcher, Inning inning)
        {
            this.batter = batter;
            this.batter.IsBatting = true;
            this.pitcher = pitcher;
            this.inning = inning;
          
            ApplyPlayerAdjustments();
        }

        /// <summary>
        /// Execute the at bat.
        /// </summary>
        public void Execute()
        {
            int roll = Dice.Roll2d10();
            GamePlayResult res = null;
            try
            {
                if (roll <= this.pitcher.PitchingStats.CurrentControl)
                {
                    PitchResults theResult = this.pitcher.PitchingStats.PitchResults[roll - 1];
                    res = GamePlayResultFactory.GetResult(this, theResult);
                }
                else
                {
                    BattingResults theResult = this.batter.BattingStats.BattingResults[roll - 1];
                    res = GamePlayResultFactory.GetResult(this, theResult);
                }
                this.inning.Game.Announcer.AnnounceToConsole(String.Format($"And {res.ControllingPlayer} is in control of the at bat."));
                this.pitcher.PitchingStatistics.BattersFaced++;
                this.result = res;
                this.batter.IsBatting = false;
                OnGamePlayResult(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// On the game play result.
        /// </summary>
        /// <param name="res">GamePlayResult</param>
        private void OnGamePlayResult(GamePlayResult res)
        {
            if (gamePlayResultHandled != null)
                gamePlayResultHandled(new GamePlayResultEventArgs(res));
        }

        /// <summary>
        /// Applies the player adjustments.
        /// </summary>
        private void ApplyPlayerAdjustments()
        {
            this.pitcher.PitchingStats.CurrentControl = pitcher.PitchingStats.Control - batter.BattingStats.ControlModifier - (batter.BattingStats.PowerRating/20) - inning.InningNumber;
            //1. Check or lefty vs lefty or righty vs righty
            if (batter.Bats == pitcher.Throws)//give pitcher a slight advantage
                this.pitcher.PitchingStats.CurrentControl += 5;
            if (pitcher.PitchingStats.PowerRating >= 90)
                this.pitcher.PitchingStats.CurrentControl += pitcher.PitchingStats.PowerRating - 90;//this will give a pitcher like Randy Johnson a monstrous advantage against lefty batters
        }

        /// <summary>
        /// Gets the batter.
        /// </summary>
        /// <value>Player</value>
        public Player Batter { get => batter; }

        /// <summary>
        /// Gets the pitcher.
        /// </summary>
        /// <value>Player</value>
        public Player Pitcher { get => pitcher; }

        /// <summary>
        /// Gets the inning.
        /// </summary>
        /// <value>Inning</value>
        public Inning Inning { get => inning; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>GamePlayResult</value>
        public GamePlayResult Result { get => result; }
    }
}

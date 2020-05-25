using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Game play result event handler.
    /// </summary>
    public delegate void GamePlayResultEventHandler(GamePlayResultEventArgs e);

    /// <summary>
    /// Game play result event arguments.
    /// </summary>
    public class GamePlayResultEventArgs : EventArgs
    {
        private GamePlayResult result;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.GamePlayResultEventArgs"/> class.
        /// </summary>
        /// <param name="result">GamePlayResult</param>
        public GamePlayResultEventArgs(GamePlayResult result)
        {
            this.result = result;
        }

        /// <summary>
        /// Gets the game play result.
        /// </summary>
        /// <value>GamePlayResult</value>
        public GamePlayResult GamePlayResult { get => result; }
    }

    /// <summary>
    /// Game play result.
    /// </summary>
    [Serializable]
    public abstract class GamePlayResult : IExecutable
    {
        /// <summary>
        /// The controlling player.
        /// </summary>
        protected Player controllingPlayer;
        /// <summary>
        /// The non controlling player.
        /// </summary>
        protected Player nonControllingPlayer;
        /// <summary>
        /// The pitcher.
        /// </summary>
        protected Player pitcher;
        /// <summary>
        /// The batter.
        /// </summary>
        protected Player batter;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.GamePlayResult"/> class.
        /// </summary>
        /// <param name="controllingPlayer">Player</param>
        /// <param name="nonControllingPlayer">Player</param>
        /// <param name="batter">Player</param>
        protected GamePlayResult(Player controllingPlayer, Player nonControllingPlayer, Player batter = null)
        {
            this.batter = batter;//This hack was needed just in case two pitchers came up to bat. The previous code meant it was impossible to distinguish, so the pitchers were getting flipped
            this.controllingPlayer = controllingPlayer;
            this.nonControllingPlayer = nonControllingPlayer;
            DetermineBatter();//check if batter is the controlling player
        }

        /// <summary>
        /// Determines the batter.
        /// </summary>
        private void DetermineBatter()
        {
            if (controllingPlayer.CurrentPosition != "P")
            {
                this.batter = controllingPlayer;
                this.pitcher = nonControllingPlayer;
            }
            else if (controllingPlayer.CurrentPosition == "P" && nonControllingPlayer.CurrentPosition == "P")
            {
                //what happens when both are pitchers? Who is the batter?
                //this.batter = nonControllingPlayer;
                if (this.batter == controllingPlayer)
                {
                    this.pitcher = nonControllingPlayer;
                }
                else
                {
                    this.pitcher = controllingPlayer;
                }
            }
            else
            {
                this.batter = nonControllingPlayer;
                this.pitcher = controllingPlayer;
            }
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Gets the controlling player.
        /// </summary>
        /// <value>Player</value>
        public Player ControllingPlayer { get => controllingPlayer; }

        /// <summary>
        /// Gets the non controlling player.
        /// </summary>
        /// <value>Player</value>
        public Player NonControllingPlayer { get => nonControllingPlayer; }

        /// <summary>
        /// Gets the pitcher.
        /// </summary>
        /// <value>Player</value>
        public Player Pitcher { get => pitcher; }

        /// <summary>
        /// Gets the batter.
        /// </summary>
        /// <value>Player</value>
        public Player Batter { get => batter; }
    }

    /// <summary>
    /// Game play result factory.
    /// </summary>
    public static class GamePlayResultFactory
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns>GamePlayResult</returns>
        /// <param name="currentAtBat">AtBat</param>
        /// <param name="result">GamePlayResult</param>
        public static GamePlayResult GetResult(AtBat currentAtBat, BattingResults result)
        {
            switch (result)
            {
                case BattingResults.HBP:
                    return new HitByPitch(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.BB:
                    return new Walk(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.K:
                    return new Strikeout(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.GO:
                    return new GroundOut(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.FO:
                    int roll = Dice.Roll2d10();
                    if (roll <= (int)((double)currentAtBat.Batter.BattingStats.PowerRating*1.5))
                    {
                        return new DeepFlyOut(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter); //Check for deep fly out
                    }
                    return new Flyout(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.Single:
                    return new Single(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.Double:
                    return new Double(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.Triple:
                    return new Triple(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                case BattingResults.HR:
                    return new HomeRun(currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
            }
            return null;
        }


        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns>GamePlayResult</returns>
        /// <param name="currentAtBat">AtBat</param>
        /// <param name="result">GamePlayResult</param>
        public static GamePlayResult GetResult(AtBat currentAtBat, PitchResults result)
        {
            switch (result)
            {
                case PitchResults.Balk:
                    return new Balk(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.HBP:
                    return new HitByPitch(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.BB:
                    return new Walk(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.K:
                    return new Strikeout(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.GO:
                    return new GroundOut(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.FO:
                    int roll = Dice.Roll2d10();
                    if (roll <= currentAtBat.Pitcher.PitchingStats.Control)
                        return new PopFlyOut(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);//currentAtBat.Pitcher in control will induce infield popout
                    return new Flyout(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.Single:
                    return new Single(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.Double:
                    return new Double(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.Triple:
                    return new Triple(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
                case PitchResults.HR:
                    return new HomeRun(currentAtBat.Pitcher, currentAtBat.Batter, currentAtBat.Batter);
            }
            return null;
        }

    }
}

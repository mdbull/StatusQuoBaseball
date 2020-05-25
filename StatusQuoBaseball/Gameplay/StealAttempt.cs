using System;
using System.Text;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Inning action event handler.
    /// </summary>
    public delegate void StealAttemptEventHandler(StealAttemptEventArgs e);

    /// <summary>
    /// Steal attempt event arguments.
    /// </summary>
    public class StealAttemptEventArgs : EventArgs
    {
        private readonly StealAttempt attempt;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.StealAttemptEventArgs"/> class.
        /// </summary>
        /// <param name="attempt">StealAttempt</param>
        public StealAttemptEventArgs(StealAttempt attempt)
        {
            this.attempt = attempt;
        }

        /// <summary>
        /// Gets the attempt.
        /// </summary>
        /// <value>StealAttempt</value>
        public StealAttempt Attempt => attempt;
    }

    /// <summary>
    /// Steal attempt.
    /// </summary>
    public class StealAttempt:GamePlayResult
    {
        /// <summary>
        /// Occurs when steal attempt handled.
        /// </summary>
        public event StealAttemptEventHandler StealAttemptHandled;

        private Player baserunner;
        private Player catcher = NullPlayer.EmptyPlayer;
        private bool wasSuccessful;
        private Base initialBase;
        private Base destinationBase;
        private readonly bool autoSuccessful;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.StealAttempt"/> class.
        /// </summary>
        /// <param name="pitcher">Player</param>
        /// <param name="baserunner">Player</param>
        /// <param name="catcher">Player</param>
        /// <param name="initialBase">Base</param>
        /// <param name="destinationBase">Base</param>
        /// <param name="autoSuccessful">bool</param>
        public StealAttempt(Player pitcher, Player baserunner, Player catcher, Base initialBase, Base destinationBase, bool autoSuccessful=false):base(pitcher, baserunner)
        {
            this.baserunner = baserunner;
            this.catcher = catcher;
            this.initialBase = initialBase;
            this.destinationBase = destinationBase;
            this.autoSuccessful = autoSuccessful;
        }

        /// <summary>
        /// Execute the stolen base attempt.
        /// </summary>
        public override void Execute()
        {
            try
            {
                if (!this.autoSuccessful)
                    AttemptStolenBase();

                if (this.autoSuccessful || this.wasSuccessful)
                {
                    this.destinationBase.PlaceRunnerOnBase(this.baserunner);
                    this.initialBase.ClearBase();
                }
                else//runner is out
                {
                    this.initialBase.ClearBase();
                    this.pitcher.PitchingStatistics.LogStat(this);
                }
                this.baserunner.BattingStatistics.LogStat(this);
                this.catcher.FieldingStatistics.LogStat(this);
                this.catcher.CurrentStamina -= 5;
                this.batter.CurrentStamina -= 5;
                this.pitcher.CurrentStamina--;

                OnStealAttempt(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Attempts the stolen base.
        /// </summary>
        private void AttemptStolenBase()
        {
            //Based on pitcher control
            try
            {
                int tempControl = this.pitcher.PitchingStats.Control - this.baserunner.BattingStats.Speed;

                if (tempControl < 0)
                    tempControl = 5;
                int roll = Dice.Roll2d10();

                if (roll <= tempControl)
                {
                    //catcher has best chance to throw out runner
                    //no speed modifier
                    roll = Dice.Roll2d10();
                    if (roll > this.catcher.FieldingStats.ArmStrength)
                    {
                        //runner successfully steals base
                        this.wasSuccessful = true;
                    }
                }
                else
                {
                    //Runner is in control
                    roll = Dice.Roll2d10();
                    if (roll <= this.baserunner.BattingStats.Speed)
                    {
                        //runner successfully steals base
                        this.wasSuccessful = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// On the steal attempt.
        /// </summary>
        /// <param name="stealAttempt">StealAttempt</param>
        private void OnStealAttempt(StealAttempt stealAttempt)
        {
            if (this.StealAttemptHandled != null)
                this.StealAttemptHandled(new StealAttemptEventArgs(this));
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.StealAttempt"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.StealAttempt"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append($"And the runner goes! {this.baserunner} attempts to steal {this.destinationBase}.");
            string result = this.wasSuccessful ? "safe" : $" thrown out by {this.catcher}";
            ret.Append($" He is {result}!!!");
            return ret.ToString();
        }

        /// <summary>
        /// Gets the catcher.
        /// </summary>
        /// <value>Player</value>
        public Player Catcher { get => catcher;}

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.StealAttempt"/> was successful.
        /// </summary>
        /// <value><c>true</c> if was successful; otherwise, <c>false</c>.</value>
        public bool WasSuccessful { get => wasSuccessful;}

        /// <summary>
        /// Gets or sets the initial base.
        /// </summary>
        /// <value>Base</value>
        public Base InitialBase { get => initialBase; }

        /// <summary>
        /// Gets or sets the destination base.
        /// </summary>
        /// <value>Base</value>
        public Base DestinationBase { get => destinationBase; }

        /// <summary>
        /// Gets the baserunner.
        /// </summary>
        /// <value>Player</value>
        public Player Baserunner { get => baserunner; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.StealAttempt"/> auto successful.
        /// </summary>
        /// <value><c>true</c> if auto successful; otherwise, <c>false</c>.</value>
        public bool AutoSuccessful => autoSuccessful;
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Inning action event handler.
    /// </summary>
    public delegate void InningActionEventHandler(InningActionEventArgs e);

    /// <summary>
    /// Inning action event arguments.
    /// </summary>
    public class InningActionEventArgs : EventArgs
    {
        private Inning inning;
        private bool toggleInning;
        private bool isInningOver;
        private GamePlayResult result;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.InningActionEventArgs"/> class.
        /// </summary>
        /// <param name="inning">Inning</param>
        /// <param name="toggleInning">If set to <c>true</c> toggle inning.</param>
        /// <param name="isInningOver">bool</param>
        /// <param name="result">GamePlayResult</param>
        public InningActionEventArgs(Inning inning, bool toggleInning, bool isInningOver, GamePlayResult result)
        {
            this.inning = inning;
            this.toggleInning = toggleInning;
            this.isInningOver = isInningOver;
            this.result = result;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:StatusQuoBaseball.Gameplay.InningActionEventArgs"/> toggle inning.
        /// </summary>
        /// <value><c>true</c> if toggle inning; otherwise, <c>false</c>.</value>
        public bool ToggleInning { get => toggleInning; set => toggleInning = value; }

        /// <summary>
        /// Gets the game play result.
        /// </summary>
        /// <value>The game play result.</value>
        public GamePlayResult GamePlayResult { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.InningActionEventArgs"/> is
        /// inning over.
        /// </summary>
        /// <value><c>true</c> if is inning over; otherwise, <c>false</c>.</value>
        public bool IsInningOver { get => isInningOver; }

        /// <summary>
        /// Gets the inning.
        /// </summary>
        /// <value>The inning.</value>
        public Inning Inning { get => inning; }
    }

    /// <summary>
    /// Inning.
    /// </summary>
    [Serializable]
    public class Inning: IExecutable
    {

#pragma warning disable 67
        /// <summary>
        /// Occurs when game play result handled.
        /// </summary>
        public event GamePlayResultEventHandler GamePlayResultHandled { add { } remove { } }
#pragma warning restore 67


        /// <summary>
        /// Occurs when inning action handled.
        /// </summary>
        public event InningActionEventHandler InningActionHandled;


        private Game game;
        private int inningNumber;
        private AtBat currentAtBat;
        private Team teamAtBat;
        private Team fieldingTeam;
        private int currentOut;
        private bool isTopOfInning = true;
        private List<AtBat> atBats = new List<AtBat>();
        private bool isInningOver;
        private bool bottomOfInningNotPlayed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Inning"/> class.
        /// </summary>
        /// <param name="inningNumber">int</param>
        /// <param name="game">Game</param>
        public Inning(int inningNumber, Game game)
        {
            this.inningNumber = inningNumber;
            this.game = game;
        }

        private GamePlayResult lastResult = null;
        /// <summary>
        /// Execute this instance.
        /// </summary>
        public void Execute()
        {
            int lastBatterIndex = 0;
            while ((!this.game.GameOver) && (!isInningOver))
            {
                if (isTopOfInning)//road team is batting
                {
                    if (lastResult==null || !(lastResult is Balk))
                    {
                        lastBatterIndex = 0;
                        if (this.game.LastRoadTeamBatter > 8)
                            this.game.LastRoadTeamBatter = 0;
                        lastBatterIndex = this.game.LastRoadTeamBatter;
                        this.game.LastRoadTeamBatter++;
                    }
                }
                else
                {

                    if (lastResult==null || !(lastResult is Balk))
                    {
                        lastBatterIndex = 0;
                        if (this.game.LastHomeTeamBatter > 8)
                            this.game.LastHomeTeamBatter = 0;
                        lastBatterIndex = this.game.LastHomeTeamBatter;
                        this.game.LastHomeTeamBatter++;
                    }
                }

                if (CheckStealAttempt(this.teamAtBat.Coach))
                    DoSteal(this.teamAtBat.Coach);
                currentAtBat = new AtBat(this.teamAtBat.Roster.Lineup[lastBatterIndex], this.fieldingTeam.Roster.CurrentPitcher, this);
                this.atBats.Add(currentAtBat);
                currentAtBat.gamePlayResultHandled += OnGamePlayResultHandled;
                this.game.Announcer.AnnounceToConsole(String.Format("{0} is now up to bat.", this.currentAtBat.Batter));
                currentAtBat.Execute();
            }
        }

        /// <summary>
        /// Does the steal attempt.
        /// </summary>
        /// <param name="coach">Coach</param>
        private void DoSteal(Coach coach)
        {
            Base firstBase = this.game.Bases.FirstBase;
            Base secondBase = this.game.Bases.SecondBase;
            Base thirdBase = this.game.Bases.ThirdBase;
            Base homePlate = this.game.Bases.HomePlate;

            try
            {
                if (firstBase.IsOccupied && secondBase.IsOccupied && thirdBase.IsVacant)//Double steal??
                {
                    Player firstRunner = firstBase.CurrentBaserunner;
                    Player secondRunner = secondBase.CurrentBaserunner;

                    StealAttempt steal2ndTo3rd = new StealAttempt(this.fieldingTeam.Roster.CurrentPitcher, secondRunner, this.fieldingTeam.Roster.GetPlayerAtPosition("C"), secondBase, thirdBase);
                    steal2ndTo3rd.StealAttemptHandled += OnStealAttemptHandled;
                    steal2ndTo3rd.Execute();//catcher will always throw to third; first-to-second will always be safe
                    StealAttempt steal1stTo2nd = new StealAttempt(this.fieldingTeam.Roster.CurrentPitcher, firstRunner, this.fieldingTeam.Roster.GetPlayerAtPosition("C"), firstBase, secondBase, true);
                    steal1stTo2nd.Execute();
                    if (!steal2ndTo3rd.WasSuccessful)
                        this.currentOut++;
                    if (this.currentOut > 2)
                        EndOfInning(steal2ndTo3rd);
                }

                StealAttempt attempt = null;
                if (secondBase.IsOccupied && thirdBase.IsVacant)
                {
                    Player runner = secondBase.CurrentBaserunner;
                    attempt = new StealAttempt(this.fieldingTeam.Roster.CurrentPitcher, runner, this.fieldingTeam.Roster.GetPlayerAtPosition("C"), secondBase, thirdBase);
                    attempt.StealAttemptHandled += OnStealAttemptHandled;
                    attempt.Execute();
                }
                if (firstBase.IsOccupied && secondBase.IsVacant)
                {
                    Player runner = firstBase.CurrentBaserunner;
                    attempt = new StealAttempt(this.fieldingTeam.Roster.CurrentPitcher, runner, this.fieldingTeam.Roster.GetPlayerAtPosition("C"), firstBase, secondBase);
                    attempt.StealAttemptHandled += OnStealAttemptHandled;
                    attempt.Execute();
                }
                if (!attempt.WasSuccessful)
                    this.currentOut++;
                if (this.currentOut > 2)
                    EndOfInning(attempt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Checks for steal attempt.
        /// </summary>
        /// <param name="coach">Coach</param>
        private bool CheckStealAttempt(Coach coach)
        {
            if (this.game.Bases.AreEmpty || this.game.Bases.AreLoaded)
                return false;
            if (this.currentOut == 2)//no coach will steal with 2 outs
                return false;

            Base firstBase = this.game.Bases.FirstBase;
            Base secondBase = this.game.Bases.SecondBase;
            Base thirdBase = this.game.Bases.ThirdBase;
            Base homePlate = this.game.Bases.HomePlate;
            int roll;

            if(firstBase.IsOccupied && secondBase.IsOccupied && thirdBase.IsVacant)//Double steal??
            {
                Player firstRunner = firstBase.CurrentBaserunner;
                Player secondRunner = secondBase.CurrentBaserunner;
                if ((firstRunner.BattingStats.Speed >= coach.CoachingStats.MinimumStealSpeed) && (secondRunner.BattingStats.Speed >= (coach.CoachingStats.MinimumStealSpeed + 10)))
                {
                    roll = Dice.Roll2d10();
                    return roll <= coach.CoachingStats.Steal2ndBase && roll <= coach.CoachingStats.Steal3rdBase;

                }
                return false;
            }
            if (secondBase.IsOccupied && thirdBase.IsVacant)
            {
                Player runner = secondBase.CurrentBaserunner;

                if (runner.BattingStats.Speed >= (coach.CoachingStats.MinimumStealSpeed+10))
                {
                    roll = Dice.Roll2d10();
                    return roll <= coach.CoachingStats.Steal3rdBase;
                }
            }
            if(firstBase.IsOccupied && secondBase.IsVacant)
            {
                Player runner = firstBase.CurrentBaserunner;
               
                if (runner.BattingStats.Speed >= coach.CoachingStats.MinimumStealSpeed)
                {
                    roll = Dice.Roll2d10();
                    return roll <= coach.CoachingStats.Steal2ndBase;
                }
            }
            return false;
        }

        /// <summary>
        /// On the steal attempt handled.
        /// </summary>
        /// <param name="e">StealAttemptEventArgs</param>
        private void OnStealAttemptHandled(StealAttemptEventArgs e)
        {
            this.game.Announcer.AnnounceToConsole(e.Attempt.ToString());
        }

        /// <summary>
        /// Ons the game play result handled.
        /// </summary>
        /// <param name="result">GamePlayResultEventArgs</param>
        protected virtual void OnGamePlayResultHandled(global::StatusQuoBaseball.Gameplay.GamePlayResultEventArgs result)
        {
            this.game.Announcer.AnnounceToConsole(result.GamePlayResult.ToString());
            if(result.GamePlayResult is Balk)
            {
                if(!this.game.Bases.AreEmpty)
                {
                    this.game.Bases.PlaceBatter(this.teamAtBat, null, this.currentAtBat.Pitcher, result.GamePlayResult);
                   result.GamePlayResult.Execute();
                }

            }
            else
                result.GamePlayResult.Execute();
            //make sure no balks happen on empty bases

            lastResult = result.GamePlayResult;
            if (result.GamePlayResult is Out)
            {
                Out theOut = (Out)result.GamePlayResult;
                if (!theOut.IsError)
                {
                    if (!(theOut is Strikeout))
                    {
                        if (theOut is GroundOut)
                        {
                            if (!this.game.Bases.AreEmpty)
                            {
                                Bases.Assist assist = new Bases.Assist(this.game, this, theOut, this.game.Bases);
                                assist.Execute();
                                this.game.Announcer.AnnounceToConsole(assist.ToString());
                            }
                            this.currentOut++;
                        }
                        else//Flyout or Deep Flyout
                        {
                            if(theOut is DeepFlyOut)
                            {
                                if (!this.game.Bases.AreEmpty && this.currentOut < 2)
                                { 
                                    SacrificeFly sacrificeFly = new SacrificeFly(this, theOut.ControllingPlayer, theOut.NonControllingPlayer, theOut.Batter);
                                    sacrificeFly.Execute();
                                }
                            }
                            this.currentOut++;
                        }
                    }
                    else//strikeout
                    {
                        this.currentOut++;
                    }
                    if (theOut.Fielder != null)//some type of out that has a fielder
                        theOut.Fielder.FieldingStatistics.LogStat(theOut);
                }
                else
                {
                    //Create an error object
                    Error error = new Error(theOut.Fielder, theOut, currentAtBat.Batter, currentAtBat.Pitcher, currentAtBat.Batter);
                    error.Execute();
                    this.game.Scoreboard.AddInningError(theOut.Fielder.Team);
                    this.game.Announcer.AnnounceToConsole(error.ToString());
                    this.game.Bases.PlaceBatter(this.teamAtBat, this.currentAtBat.Batter, this.currentAtBat.Pitcher, error);
                    //this.currentOut--;
                }
                if (this.currentOut > 2)
                    EndOfInning(result.GamePlayResult);
            }
            else if(!(result.GamePlayResult is Balk))//Hit or walk
            {
               
                if (result.GamePlayResult is Hit)
                {
                    this.game.Scoreboard.AddInningHit(this.teamAtBat);
                }
                this.game.Bases.PlaceBatter(this.teamAtBat, this.currentAtBat.Batter, this.currentAtBat.Pitcher, result.GamePlayResult);
            }
            this.game.Announcer.AnnounceToConsole(this.game.Bases.ToString());
        }

        /// <summary>
        /// Ends the inning.
        /// </summary>
        private void EndOfInning(GamePlayResult result)
        {
            this.currentOut = 0; //reset outs
            this.game.Bases.ClearBases();
            if (isTopOfInning)//if top of inning, send signal to toggle inning in Game.
            {
                OnInningAction(true, false, result);
            }
            else//if not top of the inning, and 3 outs, the inning is over
            {
                this.isInningOver = true;
                OnInningAction(false, true, result);
            }
        }

        /// <summary>
        /// Ons the inning action.
        /// </summary>
        /// <param name="toggleInning">If set to <c>true</c> toggle inning.</param>
        /// <param name="_isInningOver">If set to <c>true</c> is inning over.</param>
        /// <param name="result">Result.</param>
        private void OnInningAction(bool toggleInning, bool _isInningOver, GamePlayResult result)
        {
            if (this.InningActionHandled != null)
                InningActionHandled(new InningActionEventArgs(this, toggleInning, _isInningOver, result));
        }

        /// <summary>
        /// Gets the current out.
        /// </summary>
        /// <value>The current out.</value>
        public int CurrentOut { get => currentOut; set => currentOut = value; }

        /// <summary>
        /// Gets the inning number.
        /// </summary>
        /// <value>The inning number.</value>
        public int InningNumber { get => inningNumber; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Inning"/> is top of inning.
        /// </summary>
        /// <value><c>true</c> if is top of inning; otherwise, <c>false</c>.</value>
        public bool IsTopOfInning { get => isTopOfInning; set => isTopOfInning = value; }

        /// <summary>
        /// Gets or sets the team at bat.
        /// </summary>
        /// <value>Team</value>
        public Team TeamAtBat { get => teamAtBat; set => teamAtBat = value; }

        /// <summary>
        /// Gets or sets the fielding team.
        /// </summary>
        /// <value>The fielding team.</value>
        public Team FieldingTeam { get => fieldingTeam; set => fieldingTeam = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Inning"/> is inning over.
        /// </summary>
        /// <value><c>true</c> if is inning over; otherwise, <c>false</c>.</value>
        public bool IsInningOver { get => isInningOver; }

        /// <summary>
        /// Gets the current at bat.
        /// </summary>
        /// <value>The current at bat.</value>
        public AtBat CurrentAtBat { get => currentAtBat; }

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <value>The game.</value>
        public Game Game { get => game; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Inning"/> bottom of
        /// inning not played.
        /// </summary>
        /// <value><c>true</c> if bottom of inning not played; otherwise, <c>false</c>.</value>
        public bool BottomOfInningNotPlayed { get => bottomOfInningNotPlayed; set => bottomOfInningNotPlayed = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Inning"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Inning"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            if (isTopOfInning)
                ret.Append("Top ");
            else
                ret.Append("Bottom ");
            ret.AppendFormat("of the {0} inning.", OrdinalNumberGenerator.Generate(this.inningNumber));
            return ret.ToString();
        }
    }
}

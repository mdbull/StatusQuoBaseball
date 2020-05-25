using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Run scored event handler.
    /// </summary>
    public delegate void RunScoredEventHandler(RunScoredEventArgs e);

    /// <summary>
    /// Run scored event arguments.
    /// </summary>
    public class RunScoredEventArgs : EventArgs
    {
        private Player runner ;
        private Player batter ;
        private Player pitcher ;
        private Team team ;
        private GamePlayResult result ;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.RunScoredEventArgs"/> class.
        /// </summary>
        /// <param name="team">Team</param>
        /// <param name="runner">Player</param>
        /// <param name="batter">Player</param>
        /// <param name="pitcher">Player</param>
        /// <param name="result">GamePlayResult</param>
        public RunScoredEventArgs(Team team, Player runner, Player batter, Player pitcher, GamePlayResult result)
        {
            this.team = team;
            this.runner = runner;
            this.batter = batter;
            this.pitcher = pitcher;
            this.result = result;
        }

        /// <summary>
        /// Gets the runner.
        /// </summary>
        /// <value>Player</value>
        public Player Runner { get => runner; }

        /// <summary>
        /// Gets or sets the batter.
        /// </summary>
        /// <value>Player</value>
        public Player Batter { get => batter; set => batter = value; }

        /// <summary>
        /// Gets or sets the pitcher.
        /// </summary>
        /// <value>Player</value>
        public Player Pitcher { get => pitcher; set => pitcher = value; }

        /// <summary>
        /// Gets the team.
        /// </summary>
        /// <value>Team</value>
        public Team Team { get => team; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>GamePlayResult</value>
        public GamePlayResult Result { get => result; set => result = value; }
    }

    /// <summary>
    /// Bases.
    /// </summary>
    public class Bases
    {
        /// <summary>
        /// Assist.
        /// </summary>
        public class Assist:IExecutable
        {
            private readonly Game game;
            private readonly Inning inning;
            private readonly Out outType;
            private Bases _bases;
            private string assistChain = string.Empty;

            private List<string> positions = new List<string>();

            /// <summary>
            /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Bases.Assist"/> class.
            /// </summary>
            /// <param name="game">Game</param>
            /// <param name="inning">Inning</param>
            /// <param name="outType">OutType</param>
            /// <param name="bases">Bases</param>
            public Assist(Game game, Inning inning, Out outType, Bases bases)
            {
                this.game = game;
                this.inning = inning;
                this.outType = outType;
                this._bases = bases;
            }

            /// <summary>
            /// Gets the bases.
            /// </summary>
            /// <value>Bases</value>
            public Bases Bases { get => _bases;}

            /// <summary>
            /// Gets the game.
            /// </summary>
            /// <value>Game</value>
            public Game Game => game;

            /// <summary>
            /// Gets the type of the out.
            /// </summary>
            /// <value>Out</value>
            public Out OutType => outType;

            /// <summary>
            /// Gets the assist chain.
            /// </summary>
            /// <value>string</value>
            public string AssistChain { get => assistChain; }

            /// <summary>
            /// Execute this instance.
            /// </summary>
            public void Execute()
            {
                Player fielder = outType.Fielder;

                try
                {
                    positions.Add(fielder.CurrentPosition);
                    fielder.FieldingStatistics.Assists++;
                    if (game.CurrentInning.CurrentOut == 2)//throw home to prevent run inning ends
                    {
                        if (_bases[2].CurrentBaserunner != null && _bases[1].CurrentBaserunner != null)//throw home to end inning
                        {
                            positions.Add(Positions.PositionNames[1]);//fielder to catcher
                            Player catcher = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[1]);
                            catcher.FieldingStatistics.Assists++;
                            this.inning.CurrentOut++;
                            this.assistChain = $"{fielder} throws to {catcher} for the final out of the inning.";
                        }
                    }
                    else if (game.CurrentInning.CurrentOut == 1)
                    {
                        if (_bases[2].CurrentBaserunner != null && _bases[1].CurrentBaserunner != null)//throw home and then to 3b to end inning
                        {
                            positions.Add(Positions.PositionNames[1]);//fielder to catcher
                            Player catcher = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[1]);
                            catcher.FieldingStatistics.Assists++;
                            positions.Add(Positions.PositionNames[4]);//catcher to 3B
                            Player thirdBaseman = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[4]);
                            thirdBaseman.FieldingStatistics.Assists++;
                            this.assistChain = $"Double Play!!!{fielder} to {catcher} to {thirdBaseman} for final outs of the inning.";

                        }
                        else if (_bases[0].CurrentBaserunner != null)//throw to second then first
                        {
                            positions.Add(Positions.PositionNames[3]);//fielder to second base to first
                            Player secondBaseman = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[3]);
                            secondBaseman.FieldingStatistics.Assists++;
                            positions.Add(Positions.PositionNames[2]);
                            Player firstBaseman = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[2]);
                            firstBaseman.FieldingStatistics.Assists++;
                            this.assistChain = $"Double Play!!!{fielder} to {secondBaseman} to {firstBaseman} for final outs of the inning.";

                        }
                        this.inning.CurrentOut +=2;
                        this.game.CurrentInning.FieldingTeam.Roster.CurrentPitcher.PitchingStatistics.TotalOuts++;//one out is already recorded in the Inning class Execute method.
                    }
                    else//Possible Triple Play?
                    {
                        if (_bases.AreLoaded)
                        {
                            positions.Add(Positions.PositionNames[1]);//fielder to catcher
                            Player catcher = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[1]);
                            catcher.FieldingStatistics.Assists++;
                            positions.Add(Positions.PositionNames[4]);//catcher to 3B
                            Player thirdBaseman = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[4]);
                            thirdBaseman.FieldingStatistics.Assists++;
                            positions.Add(Positions.PositionNames[5]);//3B to 2B
                            Player secondBaseman = fielder.Team.Roster.GetPlayerAtPosition(Positions.PositionNames[5]);
                            secondBaseman.FieldingStatistics.Assists++;
                            this.assistChain = $"TRIPLE PLAY!!!{fielder} to {catcher} to {thirdBaseman} to {secondBaseman} for the final outs of the inning.";
                            this.inning.CurrentOut += 3;
                            this.game.CurrentInning.FieldingTeam.Roster.CurrentPitcher.PitchingStatistics.TotalOuts+=2;//one out is already recorded in the Inning class Execute method.

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Bases.Assist"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Bases.Assist"/>.</returns>
            public override string ToString()
            {
                return assistChain;
            }

        }

        /// <summary>
        /// Occurs when run scored event handled.
        /// </summary>
        public event RunScoredEventHandler runScoredEventHandled = null;

        private Base[] _bases;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Bases"/> class.
        /// </summary>
        public Bases()
        {
            SetBases();
        }

        /// <summary>
        /// Sets the bases.
        /// </summary>
        private void SetBases()
        {
            this._bases = new Base[4];
            this._bases[0] = new Base(0, "1st Base");
            this._bases[1] = new Base(1, "2nd Base");
            this._bases[2] = new Base(2, "3rd Base");
            this._bases[3] = new Base(3, "Home Plate");
        }

        /// <summary>
        /// Clears the bases.
        /// </summary>
        public void ClearBases()
        {
            foreach(Base b in this._bases)
            {
                b.ClearBase();
            }
        }
        
        /// <summary>
        /// Places the batter.
        /// </summary>
        /// <param name="team">Team.</param>
        /// <param name="batter">Batter.</param>
        /// <param name="pitcher">Pitcher.</param>
        /// <param name="result">Result.</param>
        public void PlaceBatter(Team team, Player batter, Player pitcher, GamePlayResult result)
        {
            int totalBases = 0;
            if (!(result is Balk))
            {

                if (result is Single || result is SacrificeFly || result is Error) //An error will push runners as well
                {
                    totalBases = 1;
                }
                else if (result is Double)
                {
                    totalBases = 2;
                }
                else if (result is Triple)
                {
                    totalBases = 3;
                }
                else if (result is HomeRun)
                {
                    totalBases = 4;
                }
                else if (result is OtherResult)
                {
                    totalBases = -1;
                }

                PushOtherBaserunners(team, batter, pitcher, totalBases, result);
                if (!(result is SacrificeFly) && totalBases >= 0)
                    this._bases[totalBases - 1].PlaceRunnerOnBase(batter);

                if (result is HomeRun)
                {
                    OnRunScored(team, batter, batter, pitcher, result);
                }
            }
            else
            {
                totalBases = 1;
                PushOtherBaserunners(team, batter, pitcher, totalBases, result);
            }
        }

        /// <summary>
        /// Pushes the other baserunners.
        /// </summary>
        /// <param name="team">Team</param>
        /// <param name="batter">Player</param>
        /// <param name="pitcher">Player</param>
        /// <param name="totalBases">int</param>
        /// <param name="result">GamePlayResult</param>
        private void PushOtherBaserunners(Team team, Player batter, Player pitcher, int totalBases, GamePlayResult result)
        {
            Base initialBase = null;
            Base destinationBase = null;
            if (totalBases >= 1) // some type of play that can move baserunners and create a run
            {
                for (int i = this._bases.Length - 2; i >= 0; i--)
                {
                    Base currentBase = this._bases[i];
                    if (!currentBase.IsVacant)
                    {
                        initialBase = currentBase;
                        if ((initialBase.Index + totalBases) >= 3)
                        {
                            destinationBase = this._bases[3];
                            destinationBase.PlaceRunnerOnBase(initialBase.CurrentBaserunner);
                            initialBase.ClearBase(); //Home plate
                            OnRunScored(team, destinationBase.CurrentBaserunner, batter, pitcher, result);
                        }
                        else
                        {
                            destinationBase = this._bases[initialBase.Index + totalBases];
                            destinationBase.PlaceRunnerOnBase(initialBase.CurrentBaserunner);
                            initialBase.ClearBase();
                        }
                    }
                }
            }
            else 
            {
                Base third = this._bases[2];
                Base second = this._bases[1];
                Base first = this._bases[0];

                if (result is DeepFlyOut)//Deep Fly outs can move runners
                {
                    //NOTE: This code will be reached unless there are fewer than 2 outs.
                    //The batter is not placed because he is out.
                    PushOtherBaserunners(team, null, pitcher, 1, result);
                }
                else//a walk, HBP, balk that will only cause a run if the bases are loaded
                {
                    if (this.AreLoaded)//Push runners as scoring a run will happen
                    {
                        PushOtherBaserunners(team, batter, pitcher, 1, result);
                        first.PlaceRunnerOnBase(batter);
                    }
                    else if (this.AreEmpty)
                    {
                        first.PlaceRunnerOnBase(batter);
                    }
                    else
                    {
                        //Logic Table
                        //The default action is to place a runner on first base
                        //1B            2B              3B
                        /*O             O               X       Place batter on first
                         *X             O               O       Move runner to 2nd and place batter on 1st
                         *O             X               O       Place batter on first
                         *O             O               O       Place batter on first
                         *O             X               X       Place batter on first
                         *X             X               O       Move runners to 2nd and 3rd and place batter on 1st       
                         *X             O               X       Move runner to 2nd and place batter on 1st
                        */

                        //Only three situations have multiple movements           
                        if (first.IsOccupied && second.IsVacant && third.IsVacant)
                        {
                            second.PlaceRunnerOnBase(first.CurrentBaserunner);
                        }
                        else if (first.IsOccupied && second.IsOccupied && third.IsVacant)
                        {
                            third.PlaceRunnerOnBase(second.CurrentBaserunner);
                            second.PlaceRunnerOnBase(first.CurrentBaserunner);
                        }
                        else if (first.IsOccupied && second.IsVacant && third.IsOccupied)
                        {
                            second.PlaceRunnerOnBase(first.CurrentBaserunner);
                        }

                        //A runner is always placed on first after walk, HBP, or error
                        first.PlaceRunnerOnBase(batter);
                    }
                }
            }
        }

        /// <summary>
        /// On the run scored.
        /// </summary>
        /// <param name="team">Team</param>
        /// <param name="runner">Player</param>
        /// <param name="batter">Player</param>
        /// <param name="pitcher">Player</param>
        /// <param name="result">GamePlayResult</param>
        private void OnRunScored(Team team, Player runner, Player batter, Player pitcher, GamePlayResult result)
        {
            if (runScoredEventHandled != null)
                runScoredEventHandled(new RunScoredEventArgs(team, runner, batter, pitcher, result));
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Bases"/> are loaded.
        /// </summary>
        /// <value><c>true</c> if are loaded; otherwise, <c>false</c>.</value>
        public bool AreLoaded
        {
            get
            {
                foreach(Base b in this._bases)
                {
                    if (b.IsVacant)
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Bases"/> are empty.
        /// </summary>
        /// <value><c>true</c> if are empty; otherwise, <c>false</c>.</value>
        public bool AreEmpty
        {
            get
            {
                foreach (Base b in this._bases)
                {
                    if (!b.IsVacant)
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Sets the <see cref="T:StatusQuoBaseball.Gameplay.Bases"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Base this[int index]
        {
            get
            {
                return this._bases[index];
            }
        }

        /// <summary>
        /// Gets the first base.
        /// </summary>
        /// <value>Base</value>
        public Base FirstBase
        {
            get => this._bases[0];
        }

        /// <summary>
        /// Gets the second base.
        /// </summary>
        /// <value>Base</value>
        public Base SecondBase
        {
            get => this._bases[1];
        }

        /// <summary>
        /// Gets the third base.
        /// </summary>
        /// <value>Base</value>
        public Base ThirdBase
        {
            get => this._bases[2];
        }

        /// <summary>
        /// Gets the home plate.
        /// </summary>
        /// <value>Base</value>
        public Base HomePlate
        {
            get => this._bases[3];
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Bases"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Bases"/>.</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            if (this.AreEmpty)
                ret.Append("Bases are empty.");
            else
                ret.AppendFormat($"ON BASE: Third={this._bases[2].CurrentBaserunner}, Second={this._bases[1].CurrentBaserunner}, First={this._bases[0].CurrentBaserunner}");
            return ret.ToString();
        }
    }

    /// <summary>
    /// Base.
    /// </summary>
    public class Base
    {
        private int index;
        private string name = String.Empty;
        private Player currentBaserunner;
       

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Base"/> class.
        /// </summary>
        /// <param name="index">int</param>
        /// <param name="name">string</param>
        public Base(int index, string name)
        {
            this.index = index;
            this.name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; }

        /// <summary>
        /// Gets or sets the current baserunner.
        /// </summary>
        /// <value>Player</value>
        public Player CurrentBaserunner { get => currentBaserunner; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Base"/> is empty.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public bool IsVacant { get => this.currentBaserunner ==null; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Base"/> is occupied.
        /// </summary>
        /// <value><c>true</c> if is occupied; otherwise, <c>false</c>.</value>
        public bool IsOccupied { get => this.currentBaserunner != null; }

        /// <summary>
        /// Gets the index of the base.
        /// </summary>
        /// <value>int</value>
        public int Index { get => index; }

        /// <summary>
        /// Places the runner on base.
        /// </summary>
        /// <param name="baseRunner">Player</param>
        public void PlaceRunnerOnBase(Player baseRunner)
        {
            this.currentBaserunner = baseRunner;
        }

        /// <summary>
        /// Clears the base.
        /// </summary>
        public void ClearBase()
        {
            this.currentBaserunner = null;
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Base"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Base"/>.</returns>
        public override string ToString()
        {
            return name;
        }
    }
}


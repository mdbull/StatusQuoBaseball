using System;
using System.Collections.Generic;
using System.Text;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Game
    /// </summary>
    public class Game:Entity, IExecutable
    {
        private static readonly string[] gameStartTimes = ConfigurationManager.GetConfigurationValue("GAME_START_TIMES").Split(',');
        private static int gamesPlayedInSeason;
        private Venue venue;
        private Announcer announcer;
        private Scoreboard scoreboard;

        private Team homeTeam;
        private int lastHomeTeamBatter;

        private Team roadTeam;
        private int lastRoadTeamBatter;

        private Team winner;
        private Team loser;

        private string gameTime = string.Empty;

        private Bases bases;

        private int currentInningIndex = -1;
        private Inning currentInning;
        private int maxInnings;
        private List<Inning> innings;
        private bool isInExtraInnings;
        private bool isSeasonMode;
        private bool gameOver;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Game"/> class.
        /// </summary>
        /// <param name="venue">Venue</param>
        /// <param name="roadTeam">Team</param>
        /// <param name="homeTeam">Team</param>
        /// <param name="gameTime">string</param>
        /// <param name="maxInnings">int</param>
        /// <param name="isSeasonMode">bool</param>
        public Game(Venue venue, Team roadTeam, Team homeTeam, string gameTime, int maxInnings, bool isSeasonMode=false)
        {
            this.venue = venue;
            this.scoreboard = new Scoreboard(this, roadTeam, homeTeam);
            this.roadTeam = roadTeam;
            this.homeTeam = homeTeam;
            this.roadTeam.Game = this;
            this.homeTeam.Game = this;
            this.roadTeam.TeamActionEventHandled += OnTeamActionEventHandled;
            this.homeTeam.TeamActionEventHandled += OnTeamActionEventHandled;
            this.gameTime = gameTime;
            this.isSeasonMode = isSeasonMode;
            if (this.isSeasonMode)
                this.id = $"Game {gamesPlayedInSeason + 1} ";
            else
                this.id = "Game ";
            this.id += $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} {this.roadTeam} v {this.homeTeam}@{this.gameTime}";
            BuildToString();
            this.innings = new List<Inning>();
            this.maxInnings = maxInnings;

            this.bases =new Bases();
            this.bases.runScoredEventHandled += OnRunScored;

        }

        /// <summary>
        /// Ons the team action event handled.
        /// </summary>
        /// <param name="e">TeamActionEventArgs</param>
        private void OnTeamActionEventHandled(TeamActionEventArgs e)
        {
            this.announcer.AnnounceToConsole(e.Msg);
        }

        /// <summary>
        /// Generates the game time.
        /// </summary>
        /// <returns>string</returns>
        public static string GenerateGameTime()
        {
            int diceRoll = Dice.Roll(0, gameStartTimes.Length);
            return gameStartTimes[diceRoll];
        }

        /// <summary>
        /// Play this instance.
        /// </summary>
        public void Execute()
        {

            this.roadTeam.Roster.SetStartingLineup();
            this.homeTeam.Roster.SetStartingLineup();
            this.roadTeam.ShowExtendedToString = true;
            this.homeTeam.ShowExtendedToString = true;
            string time = Convert.ToInt32(this.gameTime[0]) >= 5 ? time = "Tonight's" : time = "Today's";
            this.announcer.AnnounceToConsole($"My name is {this.announcer.Name}");
            this.announcer.AnnounceToConsole(String.Format("Welcome to {0} in {1}", this.venue.Name, this.venue.Location));
            this.announcer.AnnounceToConsole($"{time} game features the {this.roadTeam} vs the {this.homeTeam}");
            this.announcer.AnnounceToConsole(String.Format("There are {0:0,###} in attendance.", this.venue.Capacity));
            this.announcer.AnnounceToConsole($"{time} pitching matchup features {this.roadTeam.Roster.CurrentPitcher} of the {this.roadTeam.ToString()} vs. {this.homeTeam.Roster.CurrentPitcher} of the {this.homeTeam.ToString()}");
            AddInning();
            while (!this.gameOver)
            {

                this.currentInning.GamePlayResultHandled += OnGamePlayResultHandled;
                this.currentInning.InningActionHandled += OnInningActionHandled;
                this.currentInning.Execute();
            }
            ConductEndOfGame();
        }

        /// <summary>
        /// Conducts the end of game.
        /// </summary>
        private void ConductEndOfGame()
        {
            int winnerScore, loserScore = 0;
            this.winner = this.scoreboard.RoadTeamScore > this.scoreboard.HomeTeamScore ? this.scoreboard.RoadTeam : this.scoreboard.HomeTeam;
            winnerScore = this.scoreboard.RoadTeamScore > this.scoreboard.HomeTeamScore ? this.scoreboard.RoadTeamScore : this.scoreboard.HomeTeamScore;
            this.loser = this.scoreboard.RoadTeamScore < this.scoreboard.HomeTeamScore ? this.scoreboard.RoadTeam : this.scoreboard.HomeTeam;
            loserScore = this.scoreboard.RoadTeamScore < this.scoreboard.HomeTeamScore ? this.scoreboard.RoadTeamScore : this.scoreboard.HomeTeamScore;
            this.announcer.AnnounceToConsole($"And that is the end of the game. The final score, the {this.winner} {this.scoreboard.RoadTeamScore}, the {this.loser} {this.scoreboard.HomeTeamScore}. Until next time, this is {this.announcer.Name}. See you then.");
            AssignWinningPitcher();
            AssignLosingPitcher();
            if (this.isSeasonMode)
            {
                UpdateSeasonStatistics(this.roadTeam);
                UpdateSeasonStatistics(this.homeTeam);
            }
            Game.gamesPlayedInSeason++;
        }

        /// <summary>
        /// Updates the season statistics.
        /// </summary>
        /// <param name="team">Team</param>
        private void UpdateSeasonStatistics(Team team)
        {
            foreach(Player p in team.Roster.Players)
            {
                if (p.BattingStatistics != null)
                {
                    p.SeasonStatistics.LogGameStats((BattingStatisticsContainer)p.BattingStatistics.Clone());
                }

                if (p.PitchingStatistics != null)
                {

                    p.SeasonStatistics.LogGameStats((PitchingStatisticsContainer)p.PitchingStatistics.Clone(),this.scoreboard.InningScores.Length);
                
                }

                if (p.FieldingStatistics != null)
                {
                    p.SeasonStatistics.LogGameStats((FieldingStatisticsContainer)p.FieldingStatistics.Clone());
                }

            }
            team.SeasonStatisticsContainer.LogTeamGameStats(this.scoreboard.InningScores.Length, team == this.winner);
        }

        /// <summary>
        /// Assigns the winning pitcher.
        /// </summary>
        private void AssignWinningPitcher()
        {
            Player potentialWinner = null;
            PitchingChangeInformation[] winningTeamPitchers = winner.Roster.PitchingOrder2.ToArray();
            if(winningTeamPitchers.Length==1)
            {
                potentialWinner = winningTeamPitchers[0].IncomingPitcher;
            }
            else
            {
                for(int i=1; i < winningTeamPitchers.Length; i++)
                {
                    if(winningTeamPitchers[i].TeamHasLead && winningTeamPitchers[i].OutgoingPitcher.PitchingStatistics.InningsPitched >= 5)
                    {
                        potentialWinner = winningTeamPitchers[i].OutgoingPitcher;
                    }
                    else if(winningTeamPitchers[i-1].TeamHasLead==false && winningTeamPitchers[i].TeamHasLead)
                    {
                        potentialWinner = winningTeamPitchers[i].IncomingPitcher;
                    }
                    else
                    {
                        potentialWinner = winningTeamPitchers[i-1].IncomingPitcher;
                    }
                }
            }
            potentialWinner.PitchingStatistics.Wins++;
            potentialWinner.PitchingStatistics.PitchingTotalDecisions++;
            AssignSavingPitcher(potentialWinner);
        }

        /// <summary>
        /// Assigns the saving pitcher.
        /// </summary>
        private void AssignSavingPitcher(Player winningPitcher)
        {
            PitchingChangeInformation[] winningTeamPitchers = winner.Roster.PitchingOrder2.ToArray();
            if (winningTeamPitchers.Length>1)
            {
                PitchingChangeInformation lastPitcher = winningTeamPitchers[winningTeamPitchers.Length - 1];
                if (winningPitcher != lastPitcher.IncomingPitcher)
                {
                    Player potentialCloser = null;
                    int scoreDifferential = 0;
                    if (lastPitcher.IncomingPitcher.Team == this.roadTeam)
                    {
                        scoreDifferential = this.scoreboard.RoadTeamScore - this.scoreboard.HomeTeamScore;
                    }
                    else
                    {
                        scoreDifferential = this.scoreboard.HomeTeamScore - this.scoreboard.RoadTeamScore;
                    }
                    if (scoreDifferential < 3)
                    {
                        potentialCloser = lastPitcher.IncomingPitcher;
                        potentialCloser.PitchingStatistics.Saves++;
                    }
                }
            }
        }

        /// <summary>
        /// Assigns the losing pitcher.
        /// </summary>
        private void AssignLosingPitcher()
        {
            Player potentialLoser = null;
            PitchingChangeInformation[] losingTeamPitchers = loser.Roster.PitchingOrder2.ToArray();
            if(losingTeamPitchers.Length == 1)
            {
                potentialLoser = losingTeamPitchers[0].IncomingPitcher;
            }
            else
            {
                for (int i = 1; i < losingTeamPitchers.Length; i++)
                {
                    if (losingTeamPitchers[i-1].TeamHasLead && !(losingTeamPitchers[i].TeamHasLead))
                    {
                        potentialLoser = losingTeamPitchers[i].OutgoingPitcher;
                    }
                    else
                    {
                        potentialLoser = losingTeamPitchers[i].IncomingPitcher;
                    }
                }
            }
            potentialLoser.PitchingStatistics.Losses++;
            potentialLoser.PitchingStatistics.PitchingTotalDecisions++;
        }

        /// <summary>
        /// Clears the game stats.
        /// </summary>
        /// <param name="team">Team.</param>
        public void ClearGameStats(Team team)
        {
            foreach (Player p in team.Roster.Players)
            {
                if (p.BattingStatistics != null)
                {
                    p.BattingStatistics.ClearStats();
                }

                if (p.PitchingStatistics != null)
                {
                    p.PitchingStatistics.ClearStats();
                }

                if (p.FieldingStatistics != null)
                {
                    p.FieldingStatistics.ClearStats();
                }
                p.MadeAppearance = false;
                p.CurrentStamina = p.Stamina;
            }
        }

        /// <summary>
        /// Signals the game over.
        /// </summary>
        private void SignalGameOver()
        {
            this.gameOver = true;
        }

        /// <summary>
        /// Ons the run scored.
        /// </summary>
        /// <param name="e">E.</param>
        protected virtual void OnRunScored(RunScoredEventArgs e)
        {
            //if the runner scores, it is a run
            e.Runner.BattingStatistics.LogStat(e.Result,1);
            e.Result.Batter.BattingStatistics.LogStat(e.Result, 2);
            e.Pitcher.PitchingStatistics.LogStat(e.Result,1);

            this.announcer.AnnounceToConsole(String.Format("{0} scored!",e.Runner));
            this.scoreboard.AddInningScore(e.Team);
            this.announcer.AnnounceToConsole(String.Format("The score is now {0}",this.scoreboard));

        }

        /// <summary>
        /// Ons the game play result handled.
        /// </summary>
        /// <param name="e">E.</param>
        protected virtual void OnGamePlayResultHandled(GamePlayResultEventArgs e)
        {
            this.announcer.AnnounceToConsole(e.ToString());
        }

        /// <summary>
        /// Ons the inning action handled.
        /// </summary>
        /// <param name="e">E.</param>
        protected virtual void OnInningActionHandled(InningActionEventArgs e)
        {
            
            if(e.IsInningOver)
            {
                this.announcer.AnnounceToConsole($"{Configuration.ConfigurationManager.GetConfigurationValue("END_OF_INNING_BOXSCORE_SEPARATOR")}\nAnd that is the end of the {e.Inning.InningNumber} inning");
                this.announcer.AnnounceToConsole(this.scoreboard.ToString());
                this.announcer.AnnounceToConsole(new GameStatisticsDisplayer(this.scoreboard).GetBoxScore());
                this.announcer.AnnounceToConsole(Configuration.ConfigurationManager.GetConfigurationValue("END_OF_INNING_SEPARATOR"));
                ////Inning is over. Check for end of game
                this.gameOver = this.IsGameOver();
                if (!this.gameOver)
                   AddInning();
                else
                    SignalGameOver();

            }
            else if (e.ToggleInning)
            {
                if (!this.gameOver)
                {
                    ToggleInning();
                    this.announcer.AnnounceToConsole($"We now go to the bottom of the {e.Inning.InningNumber} inning");
                    this.announcer.AnnounceToConsole(this.scoreboard.ToString());
                    this.announcer.AnnounceToConsole(Configuration.ConfigurationManager.GetConfigurationValue("TOGGLE_INNING_SEPARATOR"));
                }
                else
                {
                    SignalGameOver();
                }
            }
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendFormat($"Game {this.roadTeam} vs. {this.homeTeam}");
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Ises the game over.
        /// </summary>
        /// <returns><c>true</c>, if game over was ised, <c>false</c> otherwise.</returns>
        private bool IsGameOver()
        {
            if(this.currentInning.InningNumber == this.maxInnings)
            {
                if (this.scoreboard.HomeTeamScore != this.scoreboard.RoadTeamScore)
                {
                    return true;
                }
                else
                {
                    this.isInExtraInnings = true;
                    this.announcer.AnnounceToConsole("We are in extra innings!");
                    return false;
                }
            }
            else if(this.isInExtraInnings)
            {
                if(this.scoreboard.HomeTeamScore != this.scoreboard.RoadTeamScore)
                    return true;
                return false;
            }
            return false;
        }

        /// <summary>
        /// Adds the inning.
        /// </summary>
        private void AddInning()
        {
            this.currentInningIndex++;
            if ((currentInningIndex + 1) <= this.maxInnings || this.isInExtraInnings)
            {
                this.innings.Add(new Inning(currentInningIndex + 1, this));
                this.currentInning = this.innings[this.currentInningIndex];
                this.currentInning.TeamAtBat = this.roadTeam;
                this.currentInning.FieldingTeam = this.homeTeam;
                this.currentInning.IsTopOfInning = true;
                this.announcer.AnnounceToConsole($"We now go to the top of the {this.currentInning}.");
           
                this.announcer.AnnounceToConsole($"The {this.currentInning.TeamAtBat.Name} {this.currentInning.TeamAtBat.Mascot} are up to bat.");
                this.scoreboard.AddInning();

            }
            else
            {
                SignalGameOver();
            }
        }

        /// <summary>
        /// Toggles the inning.
        /// </summary>
        private void ToggleInning()
        {
            this.bases.ClearBases();
            this.currentInning = this.innings[this.currentInningIndex];
            if (this.currentInning.IsTopOfInning)
            {
                this.currentInning.IsTopOfInning = false;
                this.currentInning.TeamAtBat = this.homeTeam;
                this.currentInning.FieldingTeam = this.roadTeam;
                this.gameOver = this.IsGameOver();
                if(this.gameOver)
                {
                    if(this.scoreboard.HomeTeamScore > this.scoreboard.RoadTeamScore)
                    {
                        this.currentInning.BottomOfInningNotPlayed = true;
                        this.scoreboard.AddBottomOfInningNotPlayed();
                    }
                }
            }
            else
            {
                
                this.currentInning.IsTopOfInning = true;
                this.currentInning.TeamAtBat = this.roadTeam;
            }
        }

        /// <summary>
        /// Gets or sets the home team.
        /// </summary>
        /// <value>The home team.</value>
        public Team HomeTeam { get => homeTeam; }

        /// <summary>
        /// Gets or sets the road team.
        /// </summary>
        /// <value>The road team.</value>
        public Team RoadTeam { get => roadTeam; }

        /// <summary>
        /// Gets or sets the game time.
        /// </summary>
        /// <value>The game time.</value>
        public string GameTime { get => gameTime; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Game"/> game over.
        /// </summary>
        /// <value><c>true</c> if game over; otherwise, <c>false</c>.</value>
        public bool GameOver { get => gameOver; }

        /// <summary>
        /// Gets the last home team batter.
        /// </summary>
        /// <value>The last home team batter.</value>
        public int LastHomeTeamBatter { get => lastHomeTeamBatter; set => lastHomeTeamBatter = value; }

        /// <summary>
        /// Gets the last road team batter.
        /// </summary>
        /// <value>The last road team batter.</value>
        public int LastRoadTeamBatter { get => lastRoadTeamBatter; set => lastRoadTeamBatter = value; }

        /// <summary>
        /// Gets the current inning.
        /// </summary>
        /// <value>The current inning.</value>
        public Inning CurrentInning { get => currentInning;}

        /// <summary>
        /// Gets the bases.
        /// </summary>
        /// <value>The bases.</value>
        public Bases Bases { get => bases; }

        /// <summary>
        /// Gets the innings.
        /// </summary>
        /// <value>The innings.</value>
        public Inning [] Innings
        {
            get { return this.innings.ToArray(); }
        }

        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <value>The scoreboard.</value>
        public Scoreboard Scoreboard { get => scoreboard; }

        /// <summary>
        /// Gets or sets the announcer.
        /// </summary>
        /// <value>The announcer.</value>
        public Announcer Announcer { get => announcer; set => announcer = value; }

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>The venue.</value>
        public Venue Venue { get => venue; set => venue = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Game"/> is in extra innings.
        /// </summary>
        /// <value><c>true</c> if is in extra innings; otherwise, <c>false</c>.</value>
        public bool IsInExtraInnings { get => isInExtraInnings; set => isInExtraInnings = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Game"/> is season mode.
        /// </summary>
        /// <value><c>true</c> if is season mode; otherwise, <c>false</c>.</value>
        public bool IsSeasonMode { get => isSeasonMode; set => isSeasonMode = value; }

        /// <summary>
        /// Gets the games played in season.
        /// </summary>
        /// <value>int</value>
        public static int GamesPlayedInSeason
        {
            get { return Game.gamesPlayedInSeason; }
        }

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <value>Team</value>
        public Team Winner { get => winner;  }

        /// <summary>
        /// Gets the loser.
        /// </summary>
        /// <value>Team</value>
        public Team Loser { get => loser;  }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Game"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Game"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }


    }
}

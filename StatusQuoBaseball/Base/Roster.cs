using System;
using System.Collections.Generic;
using System.Linq;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Roster substitution event handler.
    /// </summary>
    public delegate void RosterSubstitutionEventHandler(RosterSubstitutionEventArgs e);

    /// <summary>
    /// Roster substitution event arguments.
    /// </summary>
    public class RosterSubstitutionEventArgs : EventArgs
    {
        private Player outgoing;
        private Player incoming;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.RosterSubstitutionEventArgs"/> class.
        /// </summary>
        /// <param name="outgoing">Player</param>
        /// <param name="incoming">Player</param>
        public RosterSubstitutionEventArgs(Player outgoing, Player incoming)
        {
            this.outgoing = outgoing;
            this.incoming = incoming;
        }

        /// <summary>
        /// Gets the player being removed.
        /// </summary>
        /// <value>Player</value>
        public Player Outgoing { get => outgoing; }

        /// <summary>
        /// Gets the player being inserted into the lineup.
        /// </summary>
        /// <value>Player</value>
        public Player Incoming { get => incoming; }
    }

    /// <summary>
    /// Pitching change information.
    /// </summary>
    [Serializable]
    public class PitchingChangeInformation
    {
        private readonly Inning inning;
        private readonly Player incomingPitcher;
        private readonly Player outgoingPitcher;
        private readonly bool teamHasLead;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PitchingChangeInformation"/> class.
        /// </summary>
        /// <param name="inning">Inning</param>
        /// <param name="incomingPitcher">Player</param>
        /// <param name="teamHasLead">If set to <c>true</c> team has lead.</param>
        public PitchingChangeInformation(Inning inning, Player incomingPitcher, Player outgoingPitcher, bool teamHasLead)
        {
            this.inning = inning;
            this.incomingPitcher = incomingPitcher;
            this.outgoingPitcher = outgoingPitcher;
            this.teamHasLead = teamHasLead;
        }

        /// <summary>
        /// Gets the inning.
        /// </summary>
        /// <value>Inning</value>
        public Inning Inning => inning;

        /// <summary>
        /// Gets the incoming pitcher.
        /// </summary>
        /// <value>Player</value>
        public Player IncomingPitcher => incomingPitcher;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.PitchingChangeInformation"/> team
        /// has lead.
        /// </summary>
        /// <value><c>true</c> if team has lead; otherwise, <c>false</c>.</value>
        public bool TeamHasLead => teamHasLead;

        /// <summary>
        /// Gets the outgoing pitcher.
        /// </summary>
        /// <value>Player</value>
        public Player OutgoingPitcher => outgoingPitcher;
    }

    /// <summary>
    /// Roster.
    /// </summary>
    public class Roster
    {
#pragma warning disable 67
        /// <summary>
        /// Occurs when roster substitution event handled.
        /// </summary>
        public event RosterSubstitutionEventHandler RosterSubstitutionEventHandled { add { } remove { } }
#pragma warning restore 67
        private List<Player> availablePlayers = new List<Player>();

        private Queue<Player> pitchingOrder = new Queue<Player>();

        private Queue<PitchingChangeInformation> pitchingOrder2 = new Queue<PitchingChangeInformation>();

        private Player[] players;

        private Player[] positionPlayers;

        private Player[] lineup = new Player[9];

        private Player currentPitcher;

        private List<Player> bullpen;

        private List<Player> startingPitchers;

        private int rosterBatterRating;

        private int rosterPowerRating;

        private int rosterSpeedRating;

        private int rosterPitchingControl;

        private int rosterPowerPitching;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Roster"/> class.
        /// </summary>
        /// <param name="team">Team</param>
        /// <param name="players">Player []</param>
        public Roster(Team team, Player[] players)
        {
            this.players = players;
            this.availablePlayers = new List<Player>(this.players);
            foreach (Player p in this.players)
                p.Team = team;
            RankPositionPlayersByBatterRating();
            CalculateRosterBatterRating(8);
            CalculateRosterPowerRating(Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_ROSTER_RATINGS_MAX_DEPTH")));
            CalculateRosterSpeedRating(Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_ROSTER_RATINGS_MAX_DEPTH")));
            CalculateRosterPitchingControl(7);
            CalculateRosterPowerPitchingRating(7);
        
        }

        /// <summary>
        /// Calculates the roster batter rating. This is based on the top N rated hitters on the team.
        /// </summary>
        /// <param name="n">int</param>
        private void CalculateRosterBatterRating(int n)
        {
            //Roster Batter rating
            var tempLineup = from p in this.players
                             where p.BattingStats != null
                             select p;
            this.rosterBatterRating = (int)tempLineup.OrderByDescending(batter => batter.BattingStats.BatterRating).Take(n).Average(batter => batter.BattingStats.BatterRating);

        }

        /// <summary>
        /// Calculates the roster power rating. This is based on the top N power hitters on the team.
        /// </summary>
        /// <param name="n">int</param>
        private void CalculateRosterPowerRating(int n)
        {
            //Roster power rating
            var tempLineup = from p in this.players
                             where p.BattingStats != null
                             select p;
            this.rosterPowerRating = (int)tempLineup.OrderByDescending(batter => batter.BattingStats.PowerRating).Take(n).Average(batter => batter.BattingStats.PowerRating);

        }

        /// <summary>
        /// Calculates the roster power rating.
        /// </summary>
        /// <param name="n">int</param>
        private void CalculateRosterSpeedRating(int n)
        {
            //Roster speed rating
            var tempLineup = from p in this.players
                             where p.BattingStats != null
                             select p;
            this.rosterSpeedRating = (int)tempLineup.OrderByDescending(batter => batter.BattingStats.Speed).Take(n).Average(batter => batter.BattingStats.Speed);

        }

        /// <summary>
        /// Calculates the roster pitching control based on the top N pitchers.
        /// </summary>
        /// <param name="n">int</param>
        private void CalculateRosterPitchingControl(int n)
        {
            //Roster pitching control
            var tempLineup = from p in this.players
                             where p.PitchingStats != null
                             select p;
            this.rosterPitchingControl = (int)tempLineup.OrderByDescending(pitcher => pitcher.PitchingStats.Control).Take(n).Average(pitcher => pitcher.PitchingStats.Control);

        }

        private void CalculateRosterPowerPitchingRating(int n)
        {
            //Roster pitching control
            var tempLineup = from p in this.players
                             where p.PitchingStats != null
                             select p;
            this.rosterPowerPitching = (int)tempLineup.OrderByDescending(pitcher => pitcher.PitchingStats.PowerRating).Take(n).Average(pitcher => pitcher.PitchingStats.PowerRating);

        }


        /// <summary>
        /// Sets the starting lineup.
        /// </summary>
        public void SetStartingLineup()
        {
            List<Player> tempLineup = new List<Player>();
            //Assume top players have the most games
            //Find the starters
            Player catcher = GetStarter("C");
            Player firstBaseman = GetStarter("1B");
            Player secondBaseman = GetStarter("2B");
            Player thirdBaseman = GetStarter("3B");
            Player shortstop = GetStarter("SS");

            //Lahman Database doesn't distinguish between different outfield positions! 😠😠😠😠😠😠😠
            Player[] outfielders = GetTopNPlayers("OF", 3);
            Player leftField = outfielders[1];

            leftField.CurrentPosition = "LF";
            Player centerField = outfielders[0];//list is sorted by games played then by speed, so fastest outfielder should be center fielder.

            centerField.CurrentPosition = "CF";
            Player rightField = outfielders[2];

            rightField.CurrentPosition = "RF";
            tempLineup.AddRange(new Player[] { catcher, firstBaseman, secondBaseman, thirdBaseman, shortstop, leftField, centerField, rightField /*,this.currentPitcher*/ });

            //Set batting order
            //Fastest player goes lead off
            Player[] speedsters = tempLineup.OrderByDescending(batter => batter.BattingStats.Speed).ToArray();
            Player[] hitters = tempLineup.OrderByDescending(batter => batter.BattingStats.BatterRating).ThenByDescending(batter => batter.BattingStats.Speed).ToArray();
            Player[] sluggers = tempLineup.OrderByDescending(batter => batter.BattingStats.PowerRating).ThenByDescending(batter => batter.BattingStats.BatterRating).ToArray();
            tempLineup.Clear();

            List<Player[]> arrays = new List<Player[]>();
            arrays.Add(speedsters);
            arrays.Add(speedsters);
            arrays.Add(hitters);
            arrays.Add(sluggers);
            arrays.Add(sluggers);
            arrays.Add(hitters);
            arrays.Add(speedsters);
            arrays.Add(speedsters);

            for (int i = 0; i < this.lineup.Length - 1; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    try
                    {
                        if (!ArrayUtilities<Player>.ArrayContains(arrays[i][j], this.lineup))
                        {
                            this.lineup[i] = GetNextAvailablePlayer(j, arrays[i]);
                            break;
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            SetStartingPitchers(Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_MAX_STARTING_ROTATION")));
            this.startingPitchers = RankPitchersByStamina(this.startingPitchers.ToArray());
            SetBullpen();
            this.bullpen = RankPitchersByStamina(this.bullpen.ToArray());

            this.currentPitcher = GetStartingPitcher(Convert.ToInt32(Configuration.ConfigurationManager.GetConfigurationValue("PROFESSIONAL_PITCHING_ROTATION_SIZE")));//choose randomly from the top 4 pitchers.
            this.currentPitcher.SeasonStatistics.SeasonPitchingStatistics.PitchingTotalGamesAppeared++;
            this.currentPitcher.SeasonStatistics.SeasonPitchingStatistics.PitchingGamesStarted++;
            this.lineup[8] = this.currentPitcher;
            this.pitchingOrder.Enqueue(this.currentPitcher);
            this.pitchingOrder2.Enqueue(new PitchingChangeInformation(new Inning(1,null), this.currentPitcher, null, false));
            for (int i = 0; i < this.lineup.Length; i++)
            {
                this.lineup[i].MadeAppearance = true;

                this.lineup[i].SeasonStatistics.TotalGamesPlayed++;
                this.lineup[i].SeasonStatistics.TotalGamesStarted++;
            }

            foreach (Player p in this.lineup)
                this.availablePlayers.Remove(p);

            //Ugly HACK to convert "OF" to "LF", "CF", "RF"
            foreach (Player p in this.availablePlayers)
            {
                if (p.NaturalPosition == "OF")
                {
                    string[] outfieldPositions = { "LF", "CF", "RF" };
                    p.NaturalPosition = outfieldPositions[Dice.Roll(0, 3)];
                    p.CurrentPosition = p.NaturalPosition;
                }
            }
        }

        /// <summary>
        /// Substitutes the player.
        /// </summary>
        /// <returns>Player</returns>
        /// <param name="outgoingPlayer">Player</param>
        /// <param name="game">Game</param>
        public Player SubstitutePlayer(Player outgoingPlayer, Game game = null)
        {
            Player incomingPlayer = null;
            int outgoingPlayerIndex = this.lineup.ToList().IndexOf(outgoingPlayer);
            Player[] replacements = null;
            if (outgoingPlayer.CurrentPosition != "P")
            {
                var playersAtPosition = from p in this.players
                                        where (p.CurrentPosition == outgoingPlayer.CurrentPosition) && (!p.MadeAppearance)
                                        orderby p.Stamina descending
                                        select p;
                replacements = playersAtPosition.ToArray();
            }
            else
            {
                var playersAtPosition = from p in this.bullpen
                                        where !p.MadeAppearance
                                        select p;
                replacements = playersAtPosition.ToArray();
            }

            if (replacements.Length > 0)
            {
                incomingPlayer = replacements[0];
                this.availablePlayers.Remove(outgoingPlayer);
                this.availablePlayers.Remove(incomingPlayer);
                this.lineup[outgoingPlayerIndex] = incomingPlayer;
                if (incomingPlayer.CurrentPosition == "P")
                {
                    this.currentPitcher = incomingPlayer;
                    this.currentPitcher.SeasonStatistics.SeasonPitchingStatistics.PitchingTotalGamesAppeared++;
                    this.pitchingOrder.Enqueue(this.currentPitcher);
                    if (game != null)
                    {
                        Team teamInLead = game.Scoreboard.TeamInLead;
                        bool teamHasLead = (teamInLead != null && (teamInLead == this.currentPitcher.Team)) ? true : false;
                        this.pitchingOrder2.Enqueue(new PitchingChangeInformation(game.CurrentInning, this.currentPitcher,outgoingPlayer,teamHasLead));
                    }
                }
                incomingPlayer.MadeAppearance = true;
            }
            return incomingPlayer ?? outgoingPlayer;
        }

        /// <summary>
        /// Gets the next available player.
        /// </summary>
        /// <returns>Player</returns>
        /// <param name="lastIndex">int</param>
        /// <param name="list">Player[]</param>
        public Player GetNextAvailablePlayer(int lastIndex, Player[] list)
        {
            return list[lastIndex];
        }

        /// <summary>
        /// Ranks the position players by batter rating.
        /// </summary>
        public void RankPositionPlayersByBatterRating()
        {
            var tempLineup = from p in this.players
                             where p.BattingStats != null && p.NaturalPosition != "P"
                             select p;
            Player[] sortedLineup = tempLineup.OrderByDescending(batter => batter.BattingStats.BatterRating).ToArray();
            this.positionPlayers = new List<Player>(sortedLineup).ToArray();
        }

        /// <summary>
        /// Gets the player at position.
        /// </summary>
        /// <returns>Player</returns>
        /// <param name="position">string</param>
        public Player GetPlayerAtPosition(string position)
        {
            for (int i = 0; i < lineup.Length; i++)
            {
                if (lineup[i].CurrentPosition == position)
                    return lineup[i];
            }
            return null;
        }
        /// <summary>
        /// Gets the starter for a position.
        /// </summary>
        /// <returns>Player</returns>
        /// <param name="position">string</param>
        private Player GetStarter(string position)
        {
            try
            {
                var tempPlayers = from player in this.positionPlayers
                                  where player.NaturalPosition == position
                                  select player;
                Player[] sorted = tempPlayers.OrderByDescending(batter => batter.BattingStats.GamesPlayed).ToArray();
                return sorted[0];//the best player (by games played)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// Returns top N players of a position.
        /// This is needed because the Lahman database doesn't distinguish between the different types of outfield positions.
        /// </summary>
        /// <returns>Player[]</returns>
        /// <param name="position">string</param>
        /// <param name="n">int</param>
        private Player[] GetTopNPlayers(string position, int n)
        {
            var tempPlayers = from player in this.positionPlayers
                              where player.NaturalPosition == position
                              select player;
            return tempPlayers.OrderByDescending(batter => batter.BattingStats.GamesPlayed).ThenBy(batter => batter.BattingStats.Speed).Take(n).ToArray();
        }

        /// <summary>
        /// Sets the starting pitchers.
        /// </summary>
        /// <param name="n">int</param>
        private void SetStartingPitchers(int n)
        {
            try
            {
                var tempPlayers = from player in this.players
                                  where player.NaturalPosition == "P"
                                  select player;
                this.startingPitchers = tempPlayers.Where(pitcher => pitcher.PitchingStats.StartPct > 0).OrderByDescending(pitcher => pitcher.Stamina).OrderByDescending(pitcher => pitcher.PitchingStats.Control).Take(n).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Sets the bullpen and also chooses the starting pitcher.
        /// </summary>
        private void SetBullpen()
        {
            this.bullpen = new List<Player>();
            foreach (Player p in this.availablePlayers)
            {
                if (p.NaturalPosition == "P")
                {
                    p.MadeAppearance = false;
                    this.bullpen.Add(p);
                }
            }
            this.bullpen = this.bullpen.Except(this.startingPitchers).ToList();
        }

        /// <summary>
        /// Gets the starting pitcher. Will choose between the top N pitchers provided
        /// </summary>
        /// <returns>Player</returns>
        public Player GetStartingPitcher(int numPitchers)
        {
            return this.startingPitchers[Dice.Roll(0, numPitchers)];
        }

        /// <summary>
        /// Ranks the pitchers by control.
        /// </summary>
        /// <returns>List(Player)</returns>
        /// <param name="pitchers">Player[]</param>
        public List<Player> RankPitchersByControl(Player[] pitchers)
        {
            Player[] sortedPitchers = pitchers.OrderBy(pitcher => pitcher.PitchingStats.Control).ThenByDescending(pitcher => pitcher.Stamina).ToArray();
            return new List<Player>(sortedPitchers);
        }

        /// <summary>
        /// Ranks the pitchers by stamina.
        /// </summary>
        public List<Player> RankPitchersByStamina(Player[] pitchers)
        {
            Player[] sortedPitchers = pitchers.OrderByDescending(pitcher => pitcher.Stamina).ThenByDescending(pitcher => pitcher.PitchingStats.Control).ToArray();
            return new List<Player>(sortedPitchers);
        }

        /// <summary>
        /// Gets or sets the lineup.
        /// </summary>
        /// <value>The lineup.</value>
        public Player[] Lineup { get => lineup; set => lineup = value; }

        /// <summary>
        /// Gets or sets the position players.
        /// </summary>
        /// <value>The position players.</value>
        public Player[] PositionPlayers { get => positionPlayers; set => positionPlayers = value; }

        /// <summary>
        /// Gets or sets the current pitcher.
        /// </summary>
        /// <value>The current pitcher.</value>
        public Player CurrentPitcher { get => currentPitcher; set => currentPitcher = value; }

        /// <summary>
        /// Gets or sets the bullpen.
        /// </summary>
        /// <value>The bullpen.</value>
        public Player[] Bullpen { get => bullpen.ToArray(); set => bullpen = new List<Player>(value); }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>The players.</value>
        public Player[] Players { get => players; }

        /// <summary>
        /// Gets the size of the roster.
        /// </summary>
        /// <value>int</value>
        public int RosterSize { get => players.Length; }

        /// <summary>
        /// Gets the available players (who have not made an appearance).
        /// </summary>
        /// <value>List(Player)</value>
        public List<Player> AvailablePlayers { get => availablePlayers; }

        /// <summary>
        /// Gets the pitching order.
        /// </summary>
        /// <value>Queue</value>
        public Queue<Player> PitchingOrder { get => pitchingOrder; set => pitchingOrder = value; }

        /// <summary>
        /// Gets or sets the starting pitchers.
        /// </summary>
        /// <value>List(Player)</value>
        public Player[] StartingPitchers { get => startingPitchers.ToArray(); set => startingPitchers = new List<Player>(value); }

        /// <summary>
        /// Gets the roster batter rating.
        /// </summary>
        /// <value>int</value>
        public int RosterBatterRating { get => rosterBatterRating; }

        /// <summary>
        /// Gets the roster power rating.
        /// </summary>
        /// <value>int</value>
        public int RosterPowerRating { get => rosterPowerRating; }

        /// <summary>
        /// Gets the roster speed rating.
        /// </summary>
        /// <value>int</value>
        public int RosterSpeedRating { get => rosterSpeedRating; }

        /// <summary>
        /// Gets the roster control.
        /// </summary>
        /// <value>int</value>
        public int RosterControl { get => rosterPitchingControl; }

        /// <summary>
        /// Gets the roster power pitching.
        /// </summary>
        /// <value>int</value>
        public int RosterPowerPitching { get => rosterPowerPitching; }

        /// <summary>
        /// Gets or sets the pitching order2.
        /// </summary>
        /// <value>Queue</value>
        public Queue<PitchingChangeInformation> PitchingOrder2 { get => pitchingOrder2; set => pitchingOrder2 = value; }
    }
}

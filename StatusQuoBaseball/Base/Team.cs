using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Database;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Team action event handler.
    /// </summary>
    public delegate void TeamActionEventHandler(TeamActionEventArgs e);

    /// <summary>
    /// Team action event arguments.
    /// </summary>
    public class TeamActionEventArgs : EventArgs
    {
        private Team team;
        private string msg = string.Empty;

       /// <summary>
       /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamActionEventArgs"/> class.
       /// </summary>
       /// <param name="team">Team</param>
       /// <param name="msg">string</param>
        public TeamActionEventArgs(Team team, string msg)
        {
            this.team = team;
            this.msg = msg;
        }

        /// <summary>
        /// Gets the team doing the action.
        /// </summary>
        /// <value>Team</value>
        public Team Team { get => team;}

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>string</value>
        public string Msg { get => msg; }


    }

    /// <summary>
    /// Represents a collection of players.
    /// </summary>
    public class Team: Entity
    {
        /// <summary>
        /// Occurs when team action event handled.
        /// </summary>
        public event TeamActionEventHandler TeamActionEventHandled;

        private int year;
        private Game game;
        private Roster roster;
        private Coach coach;
        private string name = string.Empty;
        private string rawName = string.Empty; //e.g., New York Yankees, not New York Yankees (2001)
        private string mascot = string.Empty;
        private bool capitalizeNames;
        private TeamInfoDisplayer displayer;
        private TeamSeasonStatisticsContainer seasonStatisticsContainer;
        private bool showExtendedToString;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Team"/> class
        /// </summary>
        /// <remarks>If a year is not entered, the current year will be assumed.</remarks>
        /// <param name="name">Name</param>
        /// <param name="mascot">Mascot</param>
        /// <param name="coach">Coach</param>
        /// <param name="year">int</param>
        public Team(string name, string mascot, Coach coach, int year=0, Game game=null)
        {
            this.name = name;
            this.mascot = mascot;
            this.coach = coach;
            this.year = year;
            this.game = game;
            this.seasonStatisticsContainer = new TeamSeasonStatisticsContainer(this);
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Gets the team name parts.
        /// </summary>
        /// <returns>ValueTuple(string,string)</returns>
        /// <param name="franchiseName">string[]</param>
        public static ValueTuple<string,string> GetTeamNameParts(string [] franchiseName)
        {
            string teamName = string.Empty;
            string teamMascot = string.Empty;

            if (franchiseName.Length == 2)
            {
                teamName = franchiseName[0];
                teamMascot = franchiseName[1];
            }
            else if (franchiseName.Length == 3)//most common and most difficult
            {
                if (franchiseName[0].Contains("New") || franchiseName[0].Contains("Kansas") || franchiseName[0].Contains("Los") || franchiseName.Contains("San") || franchiseName.Contains("St") || franchiseName.Contains("Fort"))
                {
                    teamName = $"{franchiseName[0]} {franchiseName[1]}";
                    teamMascot = $"{franchiseName[2]}";
                }
                else
                {
                    teamName = $"{franchiseName[0]}";
                    teamMascot = $"{franchiseName[1]} {franchiseName[2]}";
                }
            }
            else if (franchiseName.Length == 4)
            {
                teamName = $"{franchiseName[0]} {franchiseName[1]}";
                teamMascot = $"{franchiseName[2]} {franchiseName[3]}";
            }
            else if (franchiseName.Length == 5)//Los Angeles Angels of Anaheim
            {
                teamName = $"{franchiseName[0]} {franchiseName[1]}";
                teamMascot = $"{franchiseName[2]} {franchiseName[3]} {franchiseName[4]}";
            }
            return new ValueTuple<string, string>(teamName, teamMascot);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Team"/> class.
        /// </summary>
        /// <remarks>If a year is not entered, the current year will be assumed.</remarks>
        /// <param name="name">Name</param>
        /// <param name="mascot">Mascot</param>
        /// <param name="year">int</param>
        public Team(string name, string mascot, int year=0)
        {
            this.name = name;
            this.mascot = mascot;
            this.year = year;
            this.seasonStatisticsContainer = new TeamSeasonStatisticsContainer(this);
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Loads the team from database.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="searchTerm">string</param>
        /// <param name="year">int</param>
        /// <param name="capitalizeNames">If set to <c>true</c> capitalize names.</param>
        public static Team LoadTeamFromDatabase(string searchTerm, int year, bool capitalizeNames=false)
        {
            Team team = null;
            Db database = null;
            try
            {
                database = new Db(MainClass.conn);
                team = DatabaseTeamLoader.LoadTeamFromFranchiseID(searchTerm, year, database);
                if (team != null)
                {
                    team.CapitalizeNames = capitalizeNames;
                    return team;
                }
            }
            catch (Exception ex)
            {
                //Eat this one
                //ex.Message.ToString();
                Console.WriteLine($"Unable to load team with search term '{searchTerm}'");
                Console.WriteLine(ex.Message);
            }
            return team;
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            if(this.mascot.Contains("("))
            {
                int indexOfOpeningParentheses = this.mascot.IndexOf("(", StringComparison.Ordinal);
                this.year = Convert.ToInt32(this.mascot.Substring(indexOfOpeningParentheses + 1, 4));
                this.mascot = this.mascot.Substring(0, indexOfOpeningParentheses-1);
            }

            this.rawName = String.Concat(this.name, " ", this.mascot).TrimEnd(' ');
            this.toString = this.rawName;
            if ((year>0) && (year != DateTime.Now.Year))
                this.toString+=$" ({year})";
        }

        /// <summary>
        /// Adds the game to team stats.
        /// </summary>
        /// <param name="game">Game</param>
        public void AddGameToTeamStatistics(Game game)
        {
            foreach(Player p in this.roster.Players)
            {
                p.BattingStatistics.Game = game;
                p.PitchingStatistics.Game = game;
                p.FieldingStatistics.Game = game;
            }
        }

        /// <summary>
        /// Getsthe coach of the team.
        /// </summary>
        /// <value>Coach</value>
        public Coach Coach { get => coach; set => coach = value; }

      
        /// <summary>
        /// Gets the roster of the team.
        /// </summary>
        /// <value>Roster</value>
        public Roster Roster 
        { 
            get => roster;
            set
            {
                roster = value;
                if (roster != null)
                    roster.RosterSubstitutionEventHandled += OnRosterSubstitution;
                for(int i =0; i < roster.Players.Length; i++)
                {
                    roster.Players[i].Team = this;
                    roster.Players[i].Year = this.Year;
                }
            }
        }

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; }

        /// <summary>
        /// Gets the mascot of the team.
        /// </summary>
        /// <value>string</value>
        public string Mascot { get => mascot;}

        /// <summary>
        /// Gets or sets the year of the team.
        /// </summary>
        /// <value>int</value>
        public int Year { get => year; set => year = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Team"/> capitalize names.
        /// </summary>
        /// <value><c>true</c> if capitalize names; otherwise, <c>false</c>.</value>
        public bool CapitalizeNames 
        {
            get
            { 
                return capitalizeNames; 
            }
            set
            {
                capitalizeNames = value;

                foreach(Player p in roster.Players)
                {
                    p.CapitalizeName = capitalizeNames;
                    p.PlayerStaminaReduced += OnPlayerStaminaReduced;
                }
                this.coach.CapitalizeName = capitalizeNames;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Team"/> show extended to string.
        /// </summary>
        /// <value><c>true</c> if show extended to string; otherwise, <c>false</c>.</value>
        public bool ShowExtendedToString
        {
            get => showExtendedToString;
            set
            {
                showExtendedToString = value;
                foreach (Player p in roster.Players)
                {
                    p.ShowExtendedToString = showExtendedToString;
                }
            }
        }

        /// <summary>
        /// Ons the roster substitution.
        /// </summary>
        /// <param name="e">RosterSubstitutionEventArgs</param>
        private void OnRosterSubstitution(RosterSubstitutionEventArgs e)
        {
            string msg = $"Manager {this.coach.FullName} has substituted {e.Outgoing.ToString()} for {e.Incoming.ToString()}.";
            TeamActionEventHandled?.Invoke(new TeamActionEventArgs(this, msg));
        }

        /// <summary>
        /// Ons the player stamina reduced.
        /// </summary>
        /// <param name="e">PlayerStaminaReducedEventArgs</param>
        private void OnPlayerStaminaReduced(PlayerStaminaReducedEventArgs e)
        {
            if (e.Player.CurrentStamina <= this.coach.CoachingStats.SubstituteThreshold)
                SubsitutePlayer(e.Player);
        }

        /// <summary>
        /// Subsitutes the player.
        /// </summary>
        /// <param name="p">Player</param>
        private void SubsitutePlayer(Player p)
        {
            if (this.game != null)
                this.roster.SubstitutePlayer(p, this.game);
            else
                this.roster.SubstitutePlayer(p);

        }

        /// <summary>
        /// Gets or sets the displayer.
        /// </summary>
        /// <value>TeamInfoDisplayer</value>
        public TeamInfoDisplayer Displayer 
        { 
            get => displayer;
            set
            {
                displayer = value;
                displayer.Team = this;
            }
        }

        /// <summary>
        /// Gets the raw name of the team (e.g., no years or other information)
        /// </summary>
        /// <value>The name of the raw.</value>
        public string RawName { get => rawName; }

        /// <summary>
        /// Gets or sets the season statistics container.
        /// </summary>
        /// <value>The season statistics container.</value>
        public TeamSeasonStatisticsContainer SeasonStatisticsContainer { get => seasonStatisticsContainer; set => seasonStatisticsContainer = value; }

        /// <summary>
        /// Gets or sets the game the team is in.
        /// </summary>
        /// <value>Game</value>
        public Game Game { get => game; set => game = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Team"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Team"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }

        /// <summary>
        /// Gets all players from an array of teams.
        /// </summary>
        /// <returns>Player[]</returns>
        public static Player[] GetAllPlayers(Team[] teams)
        {
            List<Player> players = new List<Player>();

            foreach (Team team in teams)
            {
                players.AddRange(team.Roster.Players);
            }
            return players.ToArray();
        }
    }
}

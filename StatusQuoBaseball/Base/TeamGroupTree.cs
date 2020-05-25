using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Team group.
    /// </summary>
    public class TeamGroupTree : EntityList<TeamGroup>, IExecutable
    {
        private string parentDirectoryPath;
        private string directoryPath;
        private int seriesLength = 3;
        private bool isSilentMode;
        private bool logSeasonStats;
        private bool logSeasonStandings;
        private int interval = 250;
        private RoundRobin robin;

       /// <summary>
       /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.TeamGroupTree"/> is silent mode.
       /// </summary>
       /// <value><c>true</c> if is silent mode; otherwise, <c>false</c>.</value>
        public bool IsSilentMode { get => isSilentMode; set => isSilentMode = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.TeamGroupTree"/> log season stats.
        /// </summary>
        /// <value><c>true</c> if log season stats; otherwise, <c>false</c>.</value>
        public bool LogSeasonStats { get => logSeasonStats; set => logSeasonStats = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.TeamGroupTree"/> log season standings.
        /// </summary>
        /// <value><c>true</c> if log season standings; otherwise, <c>false</c>.</value>
        public bool LogSeasonStandings { get => logSeasonStandings; set => logSeasonStandings = value; }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>int</value>
        public int Interval { get => interval; set => interval = value; }

        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        /// <value>string</value>
        public string DirectoryPath { get => directoryPath; set => directoryPath = value; }

        /// <summary>
        /// Gets or sets the parent directory path.
        /// </summary>
        /// <value>string</value>
        public string ParentDirectoryPath { get => parentDirectoryPath; set => parentDirectoryPath = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamGroup"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        /// <param name="seriesLength">int</param>
        public TeamGroupTree(string id, string name, int seriesLength=3) : base(id,name)
        {
            this.seriesLength = seriesLength;
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            List<Team> teams = new List<Team>();
            foreach (TeamGroup teamGroup in this)
            {
                foreach (Team team in teamGroup)
                {
                    Console.WriteLine($"Adding team '{team}' to {this.name}");
                    System.Threading.Thread.Sleep(this.interval);
                    teams.Add(team);
                }
            }

            try
            {
                //parentDirectoryPath = System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
                directoryPath = System.IO.Path.Combine($"{parentDirectoryPath}{this.name}/");
                robin = new RoundRobin(seriesLength, isSilentMode, logSeasonStats, logSeasonStandings, interval, teams.ToArray());
                robin.ParentDirectoryPath = directoryPath;
                robin.RoundRobinProgressHandled += ReportProgress;
                robin.Execute();
                foreach (TeamGroup teamGroup in this)
                {
                    Console.WriteLine($"Logging standings for team group '{teamGroup}...");
                    System.Threading.Thread.Sleep(this.interval);
                    LogStandings(teamGroup);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Reports the progress of the round robin.
        /// </summary>
        /// <param name="e">ProgressReporterEventArgs</param>
        private void ReportProgress(ProgressReporterEventArgs e)
        {
            try
            {
                Console.Write(TextUtilities.ProgressBar($"Played game {e.GamesPlayed} of {e.NumGames}", e.GamesPlayed, e.NumGames, 10, '.'));
                System.Threading.Thread.Sleep(this.interval);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Logs the season stats.
        /// </summary>
        /// <param name="teamGroup">TeamGroup</param>
        public void LogStandings(TeamGroup teamGroup)
        {
            Standings standings = new Standings(teamGroup.ToArray());
            string path = $"{robin.ParentDirectoryPath}";
            Logger logger = new Logger(String.Format($"{path}{teamGroup.Name} Season Standings{ConfigurationManager.GetConfigurationValue("SEASON_STATS_EXTENSION")}"));

            string header = $"Standings";
            if (!this.IsSilentMode)
            {
                Console.WriteLine("");
                Console.WriteLine(header);
                Console.WriteLine(standings);
            }
            logger.LogMessage(header);
            logger.LogMessage(standings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name}");
         
            foreach (TeamGroup teamGroup in this)
            {
                sb.AppendLine($"\t{teamGroup.Name}");

                foreach(Team team in teamGroup)
                {
                    sb.AppendLine($"\t\t{team}");
                }
            }
            this.toString = sb.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroupTree"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroupTree"/>.</returns>
        public override string ToString()
        {
            if(this.toString.Length == 0)
            {
                BuildToString();
            }
            return this.toString;
        }

        /// <summary>
        /// Gets all players from all teams in the TeamGroupTree.
        /// </summary>
        /// <returns>Player[]</returns>
        public Player[] GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (TeamGroup group in this)
            {
                foreach (Team team in group)
                {
                    players.AddRange(team.Roster.Players);
                }
            }
            return players.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Series.
    /// </summary>
    [Serializable]
    public class Series:IExecutable,IProgressReporter
    {
        /// <summary>
        /// Occurs when series progress handled.
        /// </summary>
        public event ProgressReporterEventHandler SeriesProgressHandled;

        private string parentDirectoryPath;
        private List<Venue> venues = new List<Venue>();
        private List<Team> roadTeams = new List<Team>();
        private List<Team> homeTeams = new List<Team>();

        private List<Game> gamesPlayed = new List<Game>();
        private int numberOfRoadTeamHomeGames;
        private int numberOfHomeTeamHomeGames;

        private string seriesName;
        private Team roadTeam;
        private Team currentRoadTeam;
        private int roadTeamWins;

        private Team homeTeam;
        private Team currentHomeTeam;
        private int homeTeamWins;

        private Team seriesWinner;
        private Team seriesLoser;

        private int numGames;
        private bool playFullSeries;
        private bool silentMode;
        private bool isSeasonMode = true;//show series stats
        private bool isSeriesOver;

        private int interval = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/> class.
        /// </summary>
        /// <param name="seriesName">string</param>
        /// <param name="roadTeam">Team</param>
        /// <param name="homeTeam">Team</param>
        /// <param name="numGames">int</param>
        /// <param name="playFullSeries">bool</param>
        /// <param name="alternateVenues">bool</param>
        /// <param name="silentMode">If set to <c>true</c> silent mode.</param>
        /// <param name="isSeasonMode">If set to <c>true</c> is season mode.</param>
        /// <param name="interval">int</param>
        public Series(string seriesName, Team roadTeam, Team homeTeam, int numGames,bool playFullSeries=true, bool silentMode = false,bool alternateVenues=true, bool isSeasonMode=true, int interval=1000)
        {
            if (numGames % 2 == 0)
                throw new Exception("A playoff series must have an odd number of games.");
            this.seriesName = seriesName;
            this.roadTeam = roadTeam;
            this.homeTeam = homeTeam;
            this.numGames = numGames;
            this.playFullSeries = playFullSeries;
            this.silentMode = silentMode;
            this.isSeasonMode = isSeasonMode;
            this.interval = interval;

            if (alternateVenues)//playoff or world series, alternate venues
            {
                this.numberOfRoadTeamHomeGames = numGames / 2;
                this.numberOfHomeTeamHomeGames = (numGames / 2) + 1;


                for (int i = 0; i < this.numberOfHomeTeamHomeGames / 2; i++)
                {
                    venues.Add(VenueManager.GetVenue(homeTeam.RawName));
                    roadTeams.Add(roadTeam);
                    homeTeams.Add(homeTeam);
                }
                for (int i = 0; i < this.numberOfRoadTeamHomeGames; i++)
                {
                    venues.Add(VenueManager.GetVenue(roadTeam.RawName));
                    roadTeams.Add(homeTeam);
                    homeTeams.Add(roadTeam);
                }
                for (int i = 0; i < this.numberOfHomeTeamHomeGames / 2; i++)
                {
                    venues.Add(VenueManager.GetVenue(homeTeam.RawName));
                    roadTeams.Add(roadTeam);
                    homeTeams.Add(homeTeam);
                }
            }
            else//normal series, no alternation
            {
                for (int i = 0; i < numGames; i++)
                {
                    try //VenueManager will return a generically named stadium if nothing is found.
                    {
                        venues.Add(VenueManager.GetVenue(homeTeam.RawName));
                        roadTeams.Add(roadTeam);
                        homeTeams.Add(homeTeam);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Stadium for {homeTeam} not found.\n");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public void Execute()
        {
            int i = 0;
            Game g = null;

            Venue venue = null;
            currentRoadTeam = null;
            currentHomeTeam = null;
            while (!isSeriesOver)
            {
                try
                {
                    venue = venues[i];
                    currentRoadTeam = roadTeams[i];
                    currentHomeTeam = homeTeams[i];
                    g = new Game(venue, currentRoadTeam, currentHomeTeam, Game.GenerateGameTime(), Convert.ToInt32(ConfigurationManager.GetConfigurationValue("CURRENT_NUM_INNINGS_REGULATION")), true);
                    g.IsSeasonMode = true;

                    Logger logger = new Logger(String.Format($"{parentDirectoryPath}{this.seriesName}/{g.Id}{ConfigurationManager.GetConfigurationValue("GAME_FILE_EXTENSION")}"));

                    g.Announcer = new Announcer(Guid.NewGuid().ToString(), ConfigurationManager.GetConfigurationValue("ANNOUNCER_NAME"), logger);//make sure announcer commentary gets logged
                    g.Announcer.Silent = this.silentMode;
                    g.Announcer.AnnounceToConsole(ConfigurationManager.GetConfigurationValue("GAME_TITLE"));
                    g.Execute();
                    g.Announcer.AnnounceToConsole(new GameStatisticsDisplayer(g.Scoreboard).GetFullBoxScore());
                    Console.Write($"The winner is {g.Winner}\r");
                    if (g.Winner == roadTeam)
                        roadTeamWins++;
                    else
                        homeTeamWins++;
                    logger.WriteToFile();
                    g.ClearGameStats(roadTeam);
                    g.ClearGameStats(homeTeam);
                    gamesPlayed.Add(g);
                    if (!playFullSeries)
                    {
                        isSeriesOver |= (CheckSeriesOver(roadTeamWins) || CheckSeriesOver(homeTeamWins));
                    }
                    seriesWinner = homeTeamWins > roadTeamWins ? homeTeam : roadTeam;
                    seriesLoser = homeTeamWins < roadTeamWins ? homeTeam : roadTeam;
                    i++;
                    isSeriesOver |= i == this.numGames;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.ReadLine();
                }
            }
            if (IsSeasonMode)
            {
                //Show results of season/series
                ShowSeriesStatistics();
            }
        }

        /// <summary>
        /// Shows the series statistics.
        /// </summary>
        private void ShowSeriesStatistics()
        {
            Logger logger = new Logger(String.Format($"{parentDirectoryPath}{this.seriesName}/{this.seriesName} Stats{ConfigurationManager.GetConfigurationValue("SEASON_STATS_EXTENSION")}"));

            string header = $"{this.gamesPlayed.Count} games played in {this.seriesName}.\n{this}";

            Console.WriteLine(header);
            logger.LogMessage(header);

            SeasonStatisticsDisplayer roadTeamDisplayer = new SeasonStatisticsDisplayer(roadTeam);
            string roadTeamInfo = roadTeamDisplayer.GetTeamInformation();
            Console.WriteLine(roadTeamInfo);
            logger.LogMessage(roadTeamInfo);

            SeasonStatisticsDisplayer homeTeamDisplayer = new SeasonStatisticsDisplayer(homeTeam);
            string homeTeamInfo = homeTeamDisplayer.GetTeamInformation();
            Console.WriteLine(homeTeamInfo);
            logger.LogMessage(homeTeamInfo);
            logger.WriteToFile();
        }

        /// <summary>
        /// Checks the series over.
        /// </summary>
        /// <returns><c>true</c>, if series over was checked, <c>false</c> otherwise.</returns>
        /// <param name="numWins">int</param>
        private bool CheckSeriesOver(int numWins)
        {
            return numWins == (this.numberOfHomeTeamHomeGames) || (this.gamesPlayed.Count == this.numGames);
        }

        /// <summary>
        /// Gets the road team.
        /// </summary>
        /// <value>Team</value>
        public Team RoadTeam { get; }

        /// <summary>
        /// Team
        /// </summary>
        /// <value>The home team.</value>
        public Team HomeTeam { get; }

        /// <summary>
        /// Gets the games.
        /// </summary>
        /// <value>Game[]</value>
        public Game[] Games
        {
            get { return gamesPlayed.ToArray(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/> silent mode.
        /// </summary>
        /// <value><c>true</c> if silent mode; otherwise, <c>false</c>.</value>
        public bool SilentMode { get => silentMode; set => silentMode = value; }

        /// <summary>
        /// Gets the number of road team home games.
        /// </summary>
        /// <value>int</value>
        public int NumberOfRoadTeamHomeGames { get => numberOfRoadTeamHomeGames; }

        /// <summary>
        /// Gets the number of home team home games.
        /// </summary>
        /// <value>int</value>
        public int NumberOfHomeTeamHomeGames { get => numberOfHomeTeamHomeGames; }


        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>int</value>
        public int Interval { get => interval; set => interval = value; }

        /// <summary>
        /// Gets or sets the name of the series.
        /// </summary>
        /// <value>string</value>
        public string SeriesName { get => seriesName; set => seriesName = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/> is
        /// season mode.
        /// </summary>
        /// <value><c>true</c> if is season mode; otherwise, <c>false</c>.</value>
        public bool IsSeasonMode { get => isSeasonMode; set => isSeasonMode = value; }

        /// <summary>
        /// Gets the series winner.
        /// </summary>
        /// <value>Team</value>
        public Team SeriesWinner { get => seriesWinner; }

        /// <summary>
        /// Gets the series loser.
        /// </summary>
        /// <value>Team</value>
        public Team SeriesLoser { get => seriesLoser; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/> is series over.
        /// </summary>
        /// <value><c>true</c> if is series over; otherwise, <c>false</c>.</value>
        public bool IsSeriesOver { get => isSeriesOver; }

        /// <summary>
        /// Gets the current home team.
        /// </summary>
        /// <value>Team</value>
        public Team CurrentHomeTeam { get => currentHomeTeam; }

        /// <summary>
        /// Gets the current road team.
        /// </summary>
        /// <value>Team</value>
        public Team CurrentRoadTeam { get => currentRoadTeam; }

        /// <summary>
        /// Gets or sets the parent directory path.
        /// </summary>
        /// <value>string</value>
        public string ParentDirectoryPath { get => parentDirectoryPath; set => parentDirectoryPath = value; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.PlayoffSeries"/>.</returns>
        public override string ToString()
        {
            int winnerWins = homeTeamWins > roadTeamWins ? homeTeamWins : roadTeamWins;
            int loserLosses = gamesPlayed.Count - winnerWins;
            bool isTied = winnerWins == loserLosses;
            StringBuilder ret = new StringBuilder();
            ret.Append($"{seriesName} - ");
            if (isTied)
                ret.Append($"is tied {winnerWins}-{loserLosses}");
            else
            {
                ret.Append($"{seriesWinner}");
                if (isSeriesOver)
                    ret.Append($" wins the series ");
                else
                {
                    ret.Append($"leads the series ");

                }
                ret.Append($"{ winnerWins}-{ loserLosses}");
            }
            return ret.ToString();
        }

        /// <summary>
        /// Statuses the quo baseball. gameplay. IP rogress reporter. report progress.
        /// </summary>
        void IProgressReporter.ReportProgress()
        {
            OnSeriesProgressHandled();
        }

        /// <summary>
        /// Ons the series progress handled.
        /// </summary>
        private void OnSeriesProgressHandled()
        {
            int played = gamesPlayed.Count;
            if (this.SeriesProgressHandled != null)
            {
                if(this.playFullSeries)
                    this.SeriesProgressHandled(new ProgressReporterEventArgs(played, numGames,seriesName));
            }
            else
            {
                this.SeriesProgressHandled(new ProgressReporterEventArgs(played, numGames,seriesName));
            }
        }

    }
}

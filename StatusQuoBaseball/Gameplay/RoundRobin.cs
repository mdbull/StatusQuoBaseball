using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Base.RankingSorters;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Gameplay
{

    /// <summary>
    /// Round robin progress event handler.
    /// </summary>
    /// <param name="e">RoundRobinProgressEventArgs</param>
    public delegate void ProgressReporterEventHandler(ProgressReporterEventArgs e);

    /// <summary>
    /// Round robin scheduler
    /// </summary>
    [Serializable]
    public class RoundRobin:IExecutable,IProgressReporter
    {
        /// <summary>
        /// Occurs when round robin progress handled.
        /// </summary>
        public event ProgressReporterEventHandler RoundRobinProgressHandled;

        private const int BYE = -1;

        private Team[] _teams;
        private int seriesLength;
        private bool isSilentMode;
        private bool logSeasonStats;
        private bool logSeasonStandings;
        private string txt = string.Empty;
        private int interval = 250;
        private int totalGamesPlayed;
        private int totalGamesToPlay;
        private string directoryPath;
        private string parentDirectoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/> class.
        /// </summary>
        /// <param name="seriesLength">int</param>
        /// <param name="isSilentMode">bool</param>
        /// <param name="logSeasonStats">bool</param>
        /// <param name="logSeasonStandings">bool</param>
        /// <param name="interval">int</param>
        /// <param name="teams">Team[]</param>
        public RoundRobin(int seriesLength, bool isSilentMode=false, bool logSeasonStats = true, bool logSeasonStandings=true,int interval=1000, params Team[] teams)
        {
            this.interval = interval;
            this.seriesLength = seriesLength;
            this.isSilentMode = isSilentMode;
            this._teams = teams;
            this.logSeasonStats = logSeasonStats;
            this.logSeasonStandings = logSeasonStandings;
        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public void Execute()
        {
            directoryPath = System.IO.Path.Combine($"{parentDirectoryPath}");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            totalGamesToPlay = (((_teams.Length ) * (_teams.Length-1))/2)*3;
            try
            {
                int[,] results = GenerateRoundRobin(_teams.Length);

                // Display the result.
                int upperBound = results.GetUpperBound(1);
                int num_teams = _teams.Length;
                for (int round = 0; round <= upperBound; round++)
                {

                    txt += "Round " + round + ":\r\n";
                   
                    for (int team = 0; team < num_teams; team++)
                    {
                        if (results[team, round] == BYE)
                        {
                            txt += "\t" + _teams[team] + " (bye)\r\n";
                           
                        }
                        else if (team < results[team, round])
                        {
                            string seriesName = _teams[team] + " v " + _teams[results[team, round]] + "\r\n";
                            txt += "\t" + seriesName;

                            try
                            {
                                Series series = new Series(seriesName, _teams[team], _teams[results[team, round]], seriesLength,true, isSilentMode, false, true, this.interval);
                                series.ParentDirectoryPath = directoryPath;
                                series.SeriesProgressHandled += ReportSeriesProgress;
                                series.Execute();
                                totalGamesPlayed += seriesLength;
                                ReportProgress();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                try
                {
                    LogStats();
                    LogStandings();
                    LogRankings();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Ons the round robin progress handled.
        /// </summary>
        /// <param name="gamesPlayed">int</param>
        private void OnRoundRobinProgressHandled(int gamesPlayed)
        {
            if (this.RoundRobinProgressHandled != null)
                this.RoundRobinProgressHandled(new ProgressReporterEventArgs(gamesPlayed,totalGamesToPlay));
        }

        /// <summary>
        /// Logs the rankings.
        /// </summary>
        public void LogRankings()
        {
            LogBattingAverageRankings();
            LogHomeRunRankings();
            LogHitRankings();
            LogRBIRankings();
            LogStolenBasesRankings();
            LogStrikeoutRankings();
            LogSaveRankings();
            LogWinsRankings();
        }

        public void LogWinsRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "W", "SeasonStatistics.SeasonPitchingStatistics.Wins");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingByWins(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Wins Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the save rankings.
        /// </summary>
        public void LogSaveRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "SV", "SeasonStatistics.SeasonPitchingStatistics.Saves");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingBySaves(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Save Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the stolen bases rankings.
        /// </summary>
        public void LogStrikeoutRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "K", "SeasonStatistics.SeasonPitchingStatistics.Strikeouts");
            Player[] thePlayers = (Player[])rankings.Sort(new SortPitchingByStrikeouts(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Strikeout Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the stolen bases rankings.
        /// </summary>
        public void LogStolenBasesRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "SB", "SeasonStatistics.SeasonBattingStatistics.StolenBases");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingByStolenBases(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Stolen Bases Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the RBI Rankings.
        /// </summary>
        public void LogRBIRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "RBI", "SeasonStatistics.SeasonBattingStatistics.RBI");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingByRBI(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}RBI Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }


        /// <summary>
        /// Logs the hit rankings.
        /// </summary>
        public void LogHitRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "H", "SeasonStatistics.SeasonBattingStatistics.Hits");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingByHits(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Hit Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the batting average rankings.
        /// </summary>
        public void LogBattingAverageRankings()
        {
            Rankings<double> rankings = new Rankings<double>(Team.GetAllPlayers(_teams), "AVG", "SeasonStatistics.SeasonBattingStatistics.BattingAverage");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingAverageDescending(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Batting Average Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the home run rankings.
        /// </summary>
        public void LogHomeRunRankings()
        {
            Rankings<int> rankings = new Rankings<int>(Team.GetAllPlayers(_teams), "HR", "SeasonStatistics.SeasonBattingStatistics.Homeruns");
            Player[] thePlayers = (Player[])rankings.Sort(new SortBattingByHomeruns(), 10);
            Logger logger = new Logger($"{parentDirectoryPath}Homerun Rankings{ConfigurationManager.GetConfigurationValue("SEASON_RANKINGS_EXTENSION")}");
            logger.LogMessage(rankings.ToString());
            logger.WriteToFile();
        }

        /// <summary>
        /// Logs the season stats.
        /// </summary>
        public void LogStats()
        {
            Logger logger = null;
            string header = string.Empty;
            foreach (Team team in _teams)
            {
                logger = new Logger(String.Format($"{parentDirectoryPath}{team} Stats{ConfigurationManager.GetConfigurationValue("SEASON_STATS_EXTENSION")}"));
                header = $"{team} Stats";

                logger.LogMessage(header);
                SeasonStatisticsDisplayer teamDisplayer = new SeasonStatisticsDisplayer(team);
                string teamInfo = teamDisplayer.GetTeamInformation();
                logger.LogMessage(team.SeasonStatisticsContainer.ToString());
                logger.LogMessage(teamInfo);
                logger.WriteToFile();
            }
        }

        /// <summary>
        /// Logs the standings.
        /// </summary>
        public void LogStandings()
        {
            Standings standings = Standings.GetStandings(_teams);
            Logger logger = null;
            string header = "Season Standings";
            logger = new Logger(String.Format($"{parentDirectoryPath}Season Standings{ConfigurationManager.GetConfigurationValue("SEASON_STANDINGS_EXTENSION")}"));

            logger.LogMessage(header);
            logger.LogMessage(standings.ToString());
            logger.WriteToFile();
        }

        #region RoundRobin Logic

        /// <summary>
        /// Generates the round robin.
        /// </summary>
        /// <returns>int[,]</returns>
        /// <param name="num_teams">int</param>
        public int[,] GenerateRoundRobin(int num_teams)
        {
            // Return an array where results(i, j) gives
            // the opponent of team i in round j.
            if (num_teams % 2 == 0)
                return GenerateRoundRobinEven(num_teams);
            return GenerateRoundRobinOdd(num_teams);
        }


        /// <summary>
        /// Generates the round robin odd.
        /// </summary>
        /// <returns>int[,]</returns>
        /// <param name="num_teams">int</param>
        private int[,] GenerateRoundRobinOdd(int num_teams)
        {
            // Return an array where results(i, j) gives
            // the opponent of team i in round j.
            // Note: num_teams must be odd.
            int n2 = (num_teams - 1) / 2;
            int[,] results = new int[num_teams, num_teams];

            // Initialize the list of teams.
            int[] teams = new int[num_teams];
            for (int i = 0; i < num_teams; i++) teams[i] = i;

            // Start the rounds.
            for (int round = 0; round < num_teams; round++)
            {
                for (int i = 0; i < n2; i++)
                {
                    int team1 = teams[n2 - i];
                    int team2 = teams[n2 + i + 1];
                    results[team1, round] = team2;
                    results[team2, round] = team1;
                }

                // Set the team with the bye.
                results[teams[0], round] = BYE;

                // Rotate the array.
                RotateArray(teams);
            }

            return results;
        }

        /// <summary>
        /// Generates the round robin even.
        /// </summary>
        /// <returns>int[,]</returns>
        /// <param name="num_teams">int</param>
        private int[,] GenerateRoundRobinEven(int num_teams)
        {
            // Return an array where results(i, j) gives
            // the opponent of team i in round j.
            // Note: num_teams must be even.

            // Generate the result for one fewer teams.
            int[,] results = GenerateRoundRobinOdd(num_teams - 1);

            // Copy the results into a bigger array,
            // replacing the byes with the extra team.
            int[,] results2 = new int[num_teams, num_teams - 1];
            for (int team = 0; team < num_teams - 1; team++)
            {
                for (int round = 0; round < num_teams - 1; round++)
                {
                    if (results[team, round] == BYE)
                    {
                        // Change the bye to the new team.
                        results2[team, round] = num_teams - 1;
                        results2[num_teams - 1, round] = team;
                    }
                    else
                    {
                        results2[team, round] = results[team, round];
                    }
                }
            }

            return results2;
        }

        /// <summary>
        /// Rotates the array.
        /// </summary>
        /// <remarks>Rotate the entries one position.</remarks>
        /// <param name="teamIndices">int[]</param>
        private void RotateArray(int[] teamIndices)
        {
            int tmp = teamIndices[teamIndices.Length - 1];
            Array.Copy(teamIndices, 0, teamIndices, 1, teamIndices.Length - 1);
            teamIndices[0] = tmp;
        }
        #endregion

        /// <summary>
        /// Gets the teams.
        /// </summary>
        /// <value>Team[]</value>
        public Team[] Teams { get => _teams; }

        /// <summary>
        /// Gets the length of each series in the round robin.
        /// </summary>
        /// <value>int</value>
        public int SeriesLength { get => seriesLength; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/> log
        /// season standings.
        /// </summary>
        /// <value><c>true</c> if log season standings; otherwise, <c>false</c>.</value>
        public bool LogSeasonStandings { get => logSeasonStandings; set => logSeasonStandings = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/> log
        /// season stats.
        /// </summary>
        /// <value><c>true</c> if log season stats; otherwise, <c>false</c>.</value>
        public bool LogSeasonStats { get => logSeasonStats; set => logSeasonStats = value; }

        /// <summary>
        /// Gets the total games played.
        /// </summary>
        /// <value>int</value>
        public int TotalGamesPlayed { get => totalGamesPlayed; }

        /// <summary>
        /// Gets the total games to play.
        /// </summary>
        /// <value>int</value>
        public int TotalGamesToPlay { get => totalGamesToPlay; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/> is silent mode.
        /// </summary>
        /// <value><c>true</c> if is silent mode; otherwise, <c>false</c>.</value>
        public bool IsSilentMode { get => isSilentMode; }

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
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.RoundRobin"/>.</returns>
        public override string ToString()
        {
            return txt;
        }

        /// <summary>
        /// Reports the progress.
        /// </summary>
        public void ReportProgress()
        {
            OnRoundRobinProgressHandled(this.totalGamesPlayed);
        }

        /// <summary>
        /// Reports the series progress.
        /// </summary>
        /// <param name="e">ProgressReporterEventArgs</param>
        public void ReportSeriesProgress(ProgressReporterEventArgs e)
        {
            try
            {
                Console.Write(TextUtilities.ProgressBar($"Played game {e.GamesPlayed} of {e.NumGames} in series {e.NameOfEvent}", e.GamesPlayed, e.NumGames, 10, '.'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

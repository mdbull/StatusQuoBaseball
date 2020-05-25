using System;
using Bullock.TextMenu;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Menu;
using StatusQuoBaseball.Base.RankingSorters;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;
using StatusQuoBaseball.Loaders.DatabaseLoaders;
using StatusQuoBaseball.Database;

namespace StatusQuoBaseball
{
    /// <summary>
    /// Main class.
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The conn.
        /// </summary>
        public static readonly string conn = Constants.SQLITE3_CONNECTION_STRING;

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">string[]</param>
        public static void Main(string[] args)
        {
            //TODO: Implement DH logic
            //TODO: Implement double round robin
            //TODO: Refactor TeamGroupTree into Composite-Leaf pattern
            //TODO: Implement full season (162 games)

            ConfigurationManager.Init(Constants.CONFIG_FILE_PATH, Constants.CONFIG_FILE_DELIMITER);
            StoredProcedureManager.Init(ConfigurationManager.GetConfigurationValue("STORED_PROCEDURES_DIRECTORY"));
            VenueManager.Init(ConfigurationManager.GetConfigurationValue("STADIUM_FILE_DIRECTORY"), true);
            SABRMetricsManager.Init(ConfigurationManager.GetConfigurationValue("SABRMETRICS_DIRECTORY"), true);

            ConsoleMenu menu = new ConsoleMenu(ConfigurationManager.GetConfigurationValue("TITLE"), true);
            MenuChoice chooseTeam = new MenuChoice(ViewTeamInformation.Display, "View Team", true);
            MenuChoice chooseLeague = new MenuChoice(ViewLeagueInformation.Display, "View League", true);
            MenuChoice playRoundRobin = new MenuChoice(PlayRoundRobin.SelectYear, "Play Round Robin!", true);
            MenuChoice playSeries = new MenuChoice(PlaySeries.SetUpSeries, "Play Series", true);
            MenuChoice playWorldSeries = new MenuChoice(PlayChampionshipSeries.SelectWorldSeries, "Replay Championship Series", true);
            MenuChoice cleanGamesFolder = new MenuChoice(CleanGamesFolder.LoadCleanGamesFolder, "Clean Games Folder", true);
            MenuChoice exit = new MenuChoice(ProgramExit.Exit, "Exit", true);
            menu.AddItem(chooseTeam);
            menu.AddItem(chooseLeague);
            menu.AddItem(playRoundRobin);
            menu.AddItem(playSeries);
            menu.AddItem(playWorldSeries);
            menu.AddItem(cleanGamesFolder);
            menu.AddItem(exit);
            menu.Run();
        }
    }
}


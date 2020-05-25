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

namespace StatusQuoBaseball.Menu
{
    /// <summary>
    /// Play round robin.
    /// </summary>
    public static class PlayRoundRobin
    {
        /// <summary>
        /// Loads the round robin.
        /// </summary>
        public static void LoadRoundRobin(ConsoleMenu mainMenu)
        {
            ConsoleMenu playRoundRobinMenu = new ConsoleMenu("Play Round Robin", true);
            MenuChoice promptForRoundRobinYear = new MenuChoice(SelectYear, "Select Year", true);
            playRoundRobinMenu.AddItem(promptForRoundRobinYear);
            mainMenu.AddItem(playRoundRobinMenu);
        }

        /// <summary>
        /// Selects the year.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void SelectYear(Runnable r)
        {
            Console.WriteLine("What is the year of the Round Robin?");
            string year = Console.ReadLine();
            int theYear = DateTime.Now.Year - 1;
            try
            {
                theYear = Int32.Parse(year);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in input.\nUsing default year ({theYear})...");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                string directoryPath = System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")} Round Robin {theYear}/");
                Db database = new Db(Constants.SQLITE3_CONNECTION_STRING);
                Console.WriteLine("Loading team group trees...");
                TeamGroupTree americanLeague = DatabaseGroupLoader.LoadRoot("AL", theYear, database);
                americanLeague.ParentDirectoryPath = directoryPath;
                americanLeague.IsSilentMode = true;
                americanLeague.Interval = 50;
                Console.WriteLine($"Loaded {americanLeague} from database...");

                TeamGroupTree nationalLeague = DatabaseGroupLoader.LoadRoot("NL", theYear, database);
                nationalLeague.ParentDirectoryPath = directoryPath;
                nationalLeague.IsSilentMode = true;
                nationalLeague.Interval = 50;
                Console.WriteLine($"Loaded {nationalLeague} from database...");

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Creating directory {directoryPath}");
                }

                Console.WriteLine($"Playing {americanLeague} round robin...");
                americanLeague.Execute();

                Console.WriteLine($"Playing {nationalLeague} round robin...");
                nationalLeague.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}

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
    /// Play world series.
    /// </summary>
    public static class PlayWorldSeries
    {

        /// <summary>
        /// Loads the view team inforamtion.
        /// </summary>
        /// <param name="mainMenu">ConsoleMenu</param>
        public static void LoadPlayWorldSeries(ConsoleMenu mainMenu)
        {
            ConsoleMenu playWorldSeriesMenu = new ConsoleMenu("Play World Series Menu", true);
            MenuChoice promptForWorldSeriesYear = new MenuChoice(SelectWorldSeries, "Display Team Information", true);
            playWorldSeriesMenu.AddItem(promptForWorldSeriesYear);
            mainMenu.AddItem(playWorldSeriesMenu);
        }

        /// <summary>
        /// Selects the world series based on the year provided.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void SelectWorldSeries(Runnable r)
        {
            Console.WriteLine("What is the year of the World Series?");
            string year = Console.ReadLine();
            int y;
            Team roadTeam, homeTeam;
            try
            {
                bool playSeries = true;
                Db database = new Db(MainClass.conn);
                y = Int32.Parse(year);
                Tuple<string, string> teamKeys = DatabaseWorldSeriesLoader.GetWorldSeriesTeams(y, database);
                roadTeam = DatabaseTeamLoader.LoadTeamByKey(teamKeys.Item1, y, database);

                if (roadTeam != null)
                {
                    Console.WriteLine($"Found team '{roadTeam}' in the database.");
                    roadTeam.CapitalizeNames = true;
                    roadTeam.ShowExtendedToString = false;
                }
                else
                {
                    playSeries = false;
                }
                homeTeam = DatabaseTeamLoader.LoadTeamByKey(teamKeys.Item2, y, database);
                if (homeTeam != null)
                {
                    Console.WriteLine($"Found team '{homeTeam}' in the database.");
                    homeTeam.CapitalizeNames = true;
                    homeTeam.ShowExtendedToString = false;
                }
                else
                {
                    playSeries = false;
                }
                if (playSeries)
                {
                    Series worldSeries = new Series($"World Series {y}", roadTeam, homeTeam, 7, false, true, true, true);
                    worldSeries.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in input");
                Console.WriteLine(ex.Message);
            }

        }
    }
}

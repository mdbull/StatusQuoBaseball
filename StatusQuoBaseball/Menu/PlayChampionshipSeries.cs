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
    public static class PlayChampionshipSeries
    {

        /// <summary>
        /// Loads the view team inforamtion.
        /// </summary>
        /// <param name="mainMenu">ConsoleMenu</param>
        public static void LoadChampionshipSeries(ConsoleMenu mainMenu)
        {
            ConsoleMenu playWorldSeriesMenu = new ConsoleMenu("Play Championship Series Menu", true);
            MenuChoice promptForWorldSeriesYear = new MenuChoice(SelectWorldSeries, "Display Team Information", true);
            playWorldSeriesMenu.AddItem(promptForWorldSeriesYear);
            mainMenu.AddItem(playWorldSeriesMenu);
        }

        /// <summary>
        /// Gets the team keys by round.
        /// </summary>
        /// <returns>Tuple(string,string)</returns>
        /// <param name="round">string</param>
        /// <param name="result">SQLQueryResult</param>
        private static Tuple<string,string> GetTeamKeysByRound(string round, SQLQueryResult result)
        {
            Tuple<string, string> keys=null;
            foreach(System.Data.DataRow row in result.DataTable.Rows)
            {
                if(row["round"].ToString()==round)
                {
                    keys = new Tuple<string, string>(row["teamIDWinner"].ToString(), row["teamIDLoser"].ToString());
                }
            }
            return keys;
        }

        /// <summary>
        /// Selects the world series based on the year provided.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void SelectWorldSeries(Runnable r)
        {
            Console.WriteLine("What year was the series?");
            string year = Console.ReadLine();
            int y = Int32.Parse(year);
            string round = string.Empty;
            Db database = new Db(MainClass.conn);
            SQLQueryResult result = DatabaseChampionshipSeriesLoader.GetSeriesInfo(y, database);
            if(result.DataTable.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder("Which round would you like to play:\n");

                foreach(System.Data.DataRow row in result.DataTable.Rows)
                {
                    sb.AppendLine($"*{row["round"].ToString()}");
                }
                Console.WriteLine(sb);
                round= Console.ReadLine();
                Team roadTeam, homeTeam;

                bool playSeries = true;

                y = Int32.Parse(year);
                Tuple<string, string> teamKeys = GetTeamKeysByRound(round, result);

                roadTeam = DatabaseTeamLoader.LoadTeamFromTeamID(teamKeys.Item1, y, database);
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
                //homeTeam = DatabaseTeamLoader.LoadTeamByKey(teamKeys.Item2, y, database);
                homeTeam = DatabaseTeamLoader.LoadTeamFromTeamID(teamKeys.Item2, y, database);
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
                    Series worldSeries = new Series($"{round} {y}", roadTeam, homeTeam, 7,false, false, true, true);
                    worldSeries.ParentDirectoryPath = System.IO.Path.Combine($"{ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY")}");
                    worldSeries.Execute();
                }
            }
            else
            {
                Console.WriteLine($"There was no postseason in {year}.");
            }
        }
    }
}

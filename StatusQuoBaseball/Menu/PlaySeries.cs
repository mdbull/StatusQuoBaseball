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
    public static class PlaySeries
    {

        /// <summary>
        /// Loads the view team inforamtion.
        /// </summary>
        /// <param name="mainMenu">ConsoleMenu</param>
        public static void LoadPlaySeries(ConsoleMenu mainMenu)
        {
            ConsoleMenu playSeriesMenu = new ConsoleMenu("Play Series Menu", true);
            MenuChoice setupTeams = new MenuChoice(SetUpSeries, "Set up Series", true);
            playSeriesMenu.AddItem(setupTeams);
            mainMenu.AddItem(playSeriesMenu);
        }

        /// <summary>
        /// Selects the world series based on the year provided.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void SetUpSeries(Runnable r)
        {
            int choice;
            bool playFullSeries=true;
            Team roadTeam, homeTeam;
            Console.WriteLine("How many games would you like to play?");
            choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                Console.WriteLine("Do you want to play the full series?");
                playFullSeries = Convert.ToBoolean(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            roadTeam = ChooseTeam("Please choose the road team.");
            Console.WriteLine($"Found team '{roadTeam}' in the database.");
            homeTeam = ChooseTeam("Please choose the home team.");
            Console.WriteLine($"Found team '{homeTeam}' in the database.");
            PlayTheSeries($"{roadTeam} vs. {homeTeam}", roadTeam, homeTeam, choice,playFullSeries);
        }

        /// <summary>
        ///Plays a series (e.g, World Series)
        /// </summary>
        /// <param name="seriesName">string</param>
        /// <param name="roadTeam">Team</param>
        /// <param name="homeTeam">Team</param>
        /// <param name="numGames">int</param>
        /// <param name="playFullSeries">bool</param>
        /// <param name="silentMode">bool</param>
        public static void PlayTheSeries(string seriesName, Team roadTeam, Team homeTeam, int numGames, bool playFullSeries = false, bool silentMode=true)
        {
            Series series = new Series(seriesName, roadTeam, homeTeam, numGames, playFullSeries, silentMode);
            series.Execute();
        }

        /// <summary>
        /// Chooses the team.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="msg">string</param>
        private static Team ChooseTeam(string msg)
        {
            Console.WriteLine($"{msg} [e.g, New York,Yankees,2001]");
            string[] teamNameParts = Console.ReadLine().Split(',');
            return LoadTeam(teamNameParts[0], teamNameParts[1], Convert.ToInt32(teamNameParts[2]),false,true);
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="mascot">string</param>
        /// <param name="year">int</param>
        /// <param name="showExtendedToString">bool</param>
        /// <param name="capitalizeNames">If set to <c>true</c> capitalize names.</param>
        private static Team LoadTeam(string teamName, string mascot, int year, bool showExtendedToString=false, bool capitalizeNames = true)
        {
            Team team = null;
            try
            {
                Db database = new Db(MainClass.conn);
                team = DatabaseTeamLoader.LoadTeam(teamName, mascot, year, database);
                team.CapitalizeNames = capitalizeNames;
                team.ShowExtendedToString = showExtendedToString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to load team '{teamName}'");
                Console.WriteLine(ex.Message);
            }
            return team;

        }
    }
}

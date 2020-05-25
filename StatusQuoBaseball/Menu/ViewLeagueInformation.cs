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
    /// View team information.
    /// </summary>
    public static class ViewLeagueInformation
    {
        /// <summary>
        /// Loads the view league inforamtion.
        /// </summary>
        /// <param name="mainMenu">ConsoleMenu</param>
        public static void LoadViewLeagueInforamtion(ConsoleMenu mainMenu)
        {
            ConsoleMenu viewTeamInformationMenu = new ConsoleMenu("View League Information", true);
            MenuChoice displayLeagueInformation = new MenuChoice(Display, "Display League Information", true);
            viewTeamInformationMenu.AddItem(displayLeagueInformation);
            mainMenu.AddItem(viewTeamInformationMenu);
        }

        /// <summary>
        /// Display the specified r.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void Display(Runnable r)
        {
            int level = 0;

            Console.WriteLine($"Please enter a league and year [e.g, AL 2001]");
            string[] choice = Console.ReadLine().Split(' ');
            Db database = new Db(MainClass.conn);
            TeamGroupTree league = DatabaseGroupLoader.LoadRoot(choice[0], Convert.ToInt32(choice[1]), database);
            Console.WriteLine($"{league.Name} ({league.GetTotalItemCount<Team>()})");
            foreach(TeamGroup group in league)
            {
                if(league.Count > 1)
                    DisplayLevel(level+1, $"{group.Name} ({group.GetTotalItemCount<Team>()})");
                foreach(Team team in group)
                {
                    DisplayLevel(level+2, $"{team.Name} ({team.Roster.Players.Length})");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays the level of the league tree.
        /// </summary>
        /// <param name="level">int</param>
        /// <param name="text">Text.</param>
        private static void DisplayLevel(int level, string text)
        {
            Console.WriteLine($"{new string('\t', level)}{text}");
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <param name="teamName">string</param>
        /// <param name="mascot">string</param>
        /// <param name="year">int</param>
        /// <param name="capitalizeNames">If set to <c>true</c> capitalize names.</param>
        //private static Team LoadTeam(string teamName, string mascot, int year, bool capitalizeNames = true)
        //{
        //    Team team = null;
        //    try
        //    {
        //        Db database = new Db(MainClass.conn);
        //        team = DatabaseTeamLoader.LoadTeam(teamName, mascot, year, database);
        //        team.CapitalizeNames = capitalizeNames;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Unable to load team '{teamName}'");
        //        Console.WriteLine(ex.Message);
        //    }
        //    return team;

        //}
    }
}

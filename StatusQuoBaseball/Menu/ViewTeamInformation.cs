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
    public static class ViewTeamInformation
    {
        private static ConsoleMenu theMenu;
        private static ConsoleMenu viewTeamInformationMenu;
        private static MenuChoice displayTeamInformation;
        private static ConsoleMenu teamChoices;

        private static Dictionary<string, string> keys;
        private static int year;

        /// <summary>
        /// Loads the view team inforamtion.
        /// </summary>
        /// <param name="mainMenu">ConsoleMenu</param>
        public static void LoadViewTeamInforamtion(ConsoleMenu mainMenu)
        {
            theMenu = mainMenu;
            viewTeamInformationMenu= new ConsoleMenu("View Team Information", true);
            displayTeamInformation = new MenuChoice(Display, "Display Team Information", true);
            viewTeamInformationMenu.AddItem(displayTeamInformation);
            theMenu.AddItem(viewTeamInformationMenu);
        }

        /// <summary>
        /// Display the specified r.
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void Display(Runnable r)
        {

            Console.WriteLine($"Please enter a team city and year [Ex. New 2001, 'New York' 2001");
            string[] searchTerm = Console.ReadLine().Split(' ');
            year = Convert.ToInt32(searchTerm[1]);
            Team team = LoadTeam(searchTerm[0]);
            TeamInfoDisplayer displayer = new TeamInfoDisplayer(team);
            Console.WriteLine(displayer.GetTeamInformation());
            displayer.Log();
        }

        /// <summary>
        /// Chooses the team.
        /// </summary>
        /// <param name="r">Runnable</param>
        private static void ChooseTeam(Runnable r)
        {
            Console.WriteLine("Please enter the number of the team you wish to view.");
            int choice = Convert.ToInt32(Console.ReadLine());
            string key = new List<string>(keys.Keys)[choice-1];

            try
            {
                Team team = Team.LoadTeamFromDatabase(key, year, true);
                TeamInfoDisplayer displayer = new TeamInfoDisplayer(team);
                Console.WriteLine(displayer.GetTeamInformation());
                displayer.Log();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Loads the team.
        /// </summary>
        /// <param name="searchTerm">string</param>
        /// <param name="secondPass">bool</param>
        /// <param name="capitalizeNames">If set to <c>true</c> capitalize names.</param>
        private static Team LoadTeam(string searchTerm,bool secondPass=false, bool capitalizeNames = true)
        {
            Team team = null;
            Db database=null;
            try
            {
                database = new Db(MainClass.conn);
                team = DatabaseTeamLoader.LoadTeamFromTeamID(searchTerm, year, database);
                if (team != null)
                {
                    team.CapitalizeNames = capitalizeNames;
                    return team;
                }
            }
            catch (Exception ex)
            {
                //Eat this one
                ex.Message.ToString();
                //Console.WriteLine($"Unable to load team with search term '{searchTerm}'");
                //Console.WriteLine(ex.Message);
            }
            //First check to see if we get multiple teams
            if (!secondPass)
            {
                keys = DatabaseTeamLoader.GetMultipleKeys(searchTerm, year, database);
                Console.WriteLine($"Found {keys.Count} results for search term '{searchTerm} {year}.'");
                teamChoices = new ConsoleMenu("Teams...", true);

                foreach (string key in keys.Keys)
                {
                    Console.WriteLine(keys[key]);
                    MenuChoice teamChoice = new MenuChoice(ChooseTeam, keys[key], true);
                    teamChoices.AddItem(teamChoice);
                }
                teamChoices.Parent = displayTeamInformation;
                teamChoices.Run();
            }
            else if (keys.Count == 2)
            {
                team = DatabaseTeamLoader.LoadTeamFromFranchiseID(searchTerm, year, database);
                team.CapitalizeNames = capitalizeNames;
            }
            else if (keys.Count == 1)
            {
                team = DatabaseTeamLoader.LoadTeamFromFranchiseID(searchTerm, year, database);
                team.CapitalizeNames = capitalizeNames;
            }
            return team;

        }
    }
}

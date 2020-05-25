using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Loaders
{ 
    /// <summary>
    /// Team loader.
    /// </summary>
    public static class TeamLoader
    {
        /// <summary>
        /// Loads the roster of players from a file.
        /// </summary>
        /// <returns>Team</returns>
        /// <param name="directory">string</param>
        public static Team LoadTeam(string directory)
        {
            Team team = null;
            Player[] roster = null;
            Coach coach = null;

            if (Directory.Exists(directory))
            {
                //Load roster
                roster = LoadTeamFromFile(directory);

                //Load manager/coach
                coach = LoadCoachFromFile(directory);

                //Load pitching stats
                LoadPitchingStats(ref roster, directory);

                //Load batting stats
                LoadBattingStats(ref roster, directory);

                //Load fielding stats
                LoadFieldingStats(ref roster, directory);

                //Load uniforms
                LoadUniforms(ref roster, directory);

                string[] teamNameParts = GetTeamNameFromDirectory(directory);
                team = new Team(teamNameParts[0], teamNameParts[1], null);
                team.Roster = new Roster(team,roster);
                if (coach != null)
                    team.Coach = coach;

            }
            else
            {
                throw new IOException($"{directory} does not exist.");
            }
            return team;
        }

        /// <summary>
        /// Loads the coach from file.
        /// </summary>
        /// <returns>Coach</returns>
        /// <param name="directory">string</param>
        private static Coach LoadCoachFromFile(string directory)
        {
            Coach ret = null;
            InMemoryConfigurationFile coachInfoFile = null;
            string coachInfoFilePath = TextUtilities.FormFilePathName(directory, "Coach", ".dat");

            if (File.Exists(coachInfoFilePath))
            {
                try
                {
                    coachInfoFile = ConfigurationManager.GetInMemoryConfigFile(coachInfoFilePath);

                    //Player-relevant fields
                    string lName = coachInfoFile["lastName"].ToString();
                    string fName = coachInfoFile["firstName"].ToString();
                    string position = coachInfoFile["position"].ToString();
                    Height height = new Height(coachInfoFile["height"].ToString());
                    Weight weight = new Weight(Convert.ToInt32(coachInfoFile["weight"]));
                    Birthday bDay = new Birthday(coachInfoFile["birthday"].ToString());

                    ret = new Coach(Guid.NewGuid().ToString(), lName, fName, "",position,Race.Unknown,Handedness.Unknown,Handedness.Unknown, height, weight,bDay);

                    //Managerial Tendencies form Coaching Stats
                    CoachingStats cStats = new CoachingStats(coachInfoFile);
                    if (cStats != null)
                        ret.CoachingStats = cStats;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return ret;
        }

        /// <summary>
        /// Loads the batting stats.
        /// </summary>
        /// <param name="roster">Player[]</param>
        /// <param name="directory">string</param>
        private static void LoadBattingStats(ref Player [] roster, string directory)
        {
            BattingStats[] bStats = BattingStats.LoadBattingStats(TextUtilities.FormFilePathName(directory, "Batting", ".dat"));
            foreach (Player player in roster)
            {
                foreach (BattingStats bStat in bStats)
                {
                    if (player.FullName.Equals(bStat.Name))
                    {
                        player.BattingStats = bStat;
                        player.BattingStatistics = new BattingStatisticsContainer(player);
                        player.SeasonStatistics = new SeasonStatisticsContainer(player);
                    }
                }
            }
        }

        /// <summary>
        /// Loads the pitching stats.
        /// </summary>
        /// <param name="roster">Player[]</param>
        /// <param name="directory">string</param>
        private static void LoadPitchingStats(ref Player[] roster, string directory)
        {
            PitchingStats[] pStats = PitchingStats.LoadPitchingStats(TextUtilities.FormFilePathName(directory, "Pitching", ".dat"));
            foreach (Player player in roster)
            {
                foreach (PitchingStats pStat in pStats)
                {
                    if (player.FullName.Equals(pStat.Name))
                    {
                        player.PitchingStats = pStat;
                        player.PitchingStatistics = new PitchingStatisticsContainer(player);
                    }
                }
            }
        }

        /// <summary>
        /// Loads the fielding stats.
        /// </summary>
        /// <param name="roster">Player[]</param>
        /// <param name="directory">string</param>
        private static void LoadFieldingStats(ref Player[] roster, string directory)
        {
            FieldingStats[] fStats = FieldingStats.LoadFieldingStats(TextUtilities.FormFilePathName(directory, "Fielding", ".dat"));
            foreach (Player player in roster)
            {
                foreach (FieldingStats fStat in fStats)
                {
                    if (player.FullName.Equals(fStat.Name))
                    {
                        player.FieldingStats = fStat;
                        player.FieldingStatistics = new FieldingStatisticsContainer(player);
                    }
                }
            }
        }

        /// <summary>
        /// Loads the uniforms.
        /// </summary>
        /// <param name="roster">Roster.</param>
        /// <param name="directory">Directory.</param>
        private static void LoadUniforms(ref Player[] roster, string directory)
        {
            Uniform[] uniforms = UniformsLoader.LoadUniformsFromFile(TextUtilities.FormFilePathName(directory, "Uniforms", ".dat"));
            foreach (Player player in roster)
            {
                foreach (Uniform uni in uniforms)
                {
                    if (player.FullName.Equals(uni.Name))
                    {
                        player.Number = uni.Number;
                        player.Uniform = uni;//keep this just in case I add more details
                    }
                }
            }
        }


        /// <summary>
        /// Gets the team name from directory.
        /// </summary>
        /// <returns>string[]</returns>
        /// <param name="directory">string</param>
        public static string [] GetTeamNameFromDirectory(string directory)
        {
            string [] name = new DirectoryInfo(directory).Name.Split(' ');
            name[0]= name[0].Replace("_", " ");
            name[1]=name[1].Replace("_", " ");
            return name;
        }

        /// <summary>
        /// Gets the full team name from directory.
        /// </summary>
        /// <returns>The full team name from directory.</returns>
        /// <param name="directory">Directory.</param>
        public static string GetFullTeamNameFromDirectory(string directory)
        {
            string[] name = new DirectoryInfo(directory).Name.Split(' ');
            name[0] = name[0].Replace("_", " ");
            name[1] = name[1].Replace("_", " ");
            return String.Join(" ",name[0],name[1]);
        }

        /// <summary>
        /// Loads the team from file.
        /// </summary>
        /// <returns>The team from file.</returns>
        /// <param name="directory">Directory.</param>
        private static Player[] LoadTeamFromFile(string directory)
        {
            string filePath = TextUtilities.FormFilePathName(directory, "Roster", ".dat");
            Dictionary<int, Dictionary<string, object>> data = new Dictionary<int, Dictionary<string, object>>();

            //1. read file
            if (File.Exists(filePath))
            {
                int count = 0;
                StreamReader handle = new StreamReader(filePath);
                //read header row first and load keys into dictionary
                string[] headerLine = handle.ReadLine().Split(Convert.ToChar(Int32.Parse(Configuration.ConfigurationManager.GetConfigurationValue("DELIMETER"))));
                while (!handle.EndOfStream)
                {
                    string[] dataLine = handle.ReadLine().Split(Convert.ToChar(Int32.Parse(Configuration.ConfigurationManager.GetConfigurationValue("DELIMETER"))));
                    data.Add(++count, new Dictionary<string, object>());
                    for (int i = 0; i < dataLine.Length; i++)
                    {
                        if (headerLine[i].Length > 0)
                        {
                            data[count].Add(headerLine[i], dataLine[i]);
                        }
                    }
                }
                return LoadTeamFromFile(data);
            }
            
            return null;
        }

        /// <summary>
        /// Loads the team from file.
        /// </summary>
        /// <returns>The team from file.</returns>
        /// <param name="data">Dictionary</param>
        private static Player[] LoadTeamFromFile(Dictionary<int, Dictionary<string, object>> data)
        {
            List<Player> players = new List<Player>();
            Dictionary<int, Dictionary<string, object>> theData = data;
            Dictionary<int, Dictionary<string, object>>.Enumerator cursor1 = theData.GetEnumerator();
            while (cursor1.MoveNext())
            {
                Dictionary<string, object> playerInfo = cursor1.Current.Value;
                Dictionary<string, object>.Enumerator cursor2 = playerInfo.GetEnumerator();
                while (cursor2.MoveNext())
                {
                    (var fname, var lname) = Person.GetNameParts((string)playerInfo["Name"]);
                    //Tuple<string, string> nameParts = Person.GetNameParts((string)playerInfo["Name"]);

                    try
                    {
                        //Name Age FLG COG B   T   Ht  Wt  DoB Yrs G   GS  Batting Defense P   C   1B  2B  3B  SS  LF  CF  RF  OF  DH  PH  PR  WAR Salary  
                        //Brian Anderson 29  us US   L L   6' 1"   190 Apr 26, 1972    9   33  22  31  29  29  0   0   0   0   0   0   0   0   0   0   1   3   -1.1    $4,125,000  
                        //Race race = RaceFactory.GetRaceFromText(playerInfo["COG"].ToString());
                        Handedness bats = ConvertTextToHandedness.ConvertFromText(playerInfo["B"].ToString());
                        Handedness throws = ConvertTextToHandedness.ConvertFromText(playerInfo["T"].ToString());
                        Height height = new Height(playerInfo["Ht"].ToString());
                        Weight weight = new Weight(Convert.ToInt32(playerInfo["Wt"]));
                        Birthday dob = new Birthday((string)playerInfo["DoB"]);
                        int appearanceFrequency = Constants.GetValueFromDouble(Convert.ToDouble(playerInfo["GS"]), Convert.ToDouble(playerInfo["G"]));
                        int gamesPitched = Convert.ToInt32(playerInfo["P"]);
                        int gamesCaught = Convert.ToInt32(playerInfo["C"]);
                        int games1B = Convert.ToInt32(playerInfo["1B"]);
                        int games2B = Convert.ToInt32(playerInfo["2B"]);
                        int games3B = Convert.ToInt32(playerInfo["3B"]);
                        int gamesSS = Convert.ToInt32(playerInfo["SS"]);
                        int gamesLF = Convert.ToInt32(playerInfo["LF"]);
                        int gamesCF = Convert.ToInt32(playerInfo["CF"]);
                        int gamesRF = Convert.ToInt32(playerInfo["RF"]);
                        int gamesDH = Convert.ToInt32(playerInfo["DH"]);

                        //use Linq
                        int[] values = { gamesPitched, gamesCaught, games1B, games2B, games3B, gamesSS, gamesLF, gamesCF, gamesRF, gamesDH };
                        int maxValue = values.Max();

                        int naturalPositionIndex = values.ToList().IndexOf(maxValue);
                        string naturalPosition = Positions.PositionNames[naturalPositionIndex];

                        Player thePlayer = new Player(Guid.NewGuid().ToString(),lname, fname, String.Empty, naturalPosition, Race.Unknown, throws, bats, height, weight, dob);
                        players.Add(thePlayer);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            return players.ToArray();
        }

    }

}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Base.RankingSorters;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{
    ///<summary>
    /// Rankings.
    /// </summary>
    public class Rankings<T> : Entity
    {
        private Player[] players;
        private readonly string categoryHeader;
        private readonly string categoryName;

        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        /// <value>string</value>
        public string CategoryName => categoryName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Rankings`1"/> class.
        /// </summary>
        /// <param name="players">Player[]</param>
        /// <param name="categoryHeader">string</param>
        /// <param name="categoryName">string</param>
        public Rankings(Player[] players,string categoryHeader, string categoryName)
        {
            this.players = players;
            this.categoryHeader = categoryHeader;
            this.categoryName = categoryName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Rankings"/> class.
        /// </summary>
        /// <param name="root">TeamGroupTree</param>
        /// <param name="categoryHeader">string</param>
        /// <param name="categoryName">string</param>
        public Rankings(TeamGroupTree root, string categoryHeader, string categoryName)
        {
            this.players = GetIndividualPlayersFromLeague(root);
            this.categoryHeader = categoryHeader;
            this.categoryName = categoryName;
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            var strings = from p in this.players
                          select $"{p.FullName}, {p.Team.Name}";
            string[] playerNames = strings.ToArray();
            int longestNameLength = TextUtilities.GetLengthOfLongestString(playerNames);

            const char SPACE = ' ';
            const int FILL_LENGTH = 6;

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("{0}", new string(SPACE, longestNameLength + 2));
            ret.AppendFormat($"{TextUtilities.FillString($"{categoryHeader}", SPACE, FILL_LENGTH)}\n");

            foreach (var player in players)
            {
                T val = ExtendedPropertyMethods.GetPropValue<T>(player, this.categoryName);
                ret.AppendFormat($"{TextUtilities.FillString($"{player.FullName}, {player.Team.Name}", SPACE, (uint)longestNameLength + 2)}");
                if(val is double)
                    ret.AppendFormat($"{TextUtilities.FillString($"{Convert.ToDouble(val).ToString("0.000")}", SPACE, FILL_LENGTH)}\n");
                else
                    ret.AppendFormat($"{TextUtilities.FillString($"{val.ToString()}", SPACE, FILL_LENGTH)}\n");
            }

            this.toString = ret.ToString();
        }

        /// <summary>
        /// Sort the specified sorter. Returns top N players based on the RankingSorter provided.
        /// </summary>
        /// <returns>Player[]</returns>
        /// <param name="sorter">RankingSorter</param>
        /// <param name="n">int</param>
        public Player[] Sort(RankingSorter sorter, int n = 0)
        {
            Array.Sort<Player>(players, sorter);
            if (n > 0)
            {  
                var takeNResult = from p in players
                                  select p;
                this.players = takeNResult.Take(n).ToArray();
            }
            BuildToString();
            return players;
        }

        /// <summary>
        /// Gets the individual players from league.
        /// </summary>
        /// <param name="league">TeamGroupTree</param>
        /// <returns>Player[]</returns>
        private Player[] GetIndividualPlayersFromLeague(TeamGroupTree league)
        {
            List<Player> allPlayers = new List<Player>();
            for (int i = 0; i < league.Count; i++)
            {
                TeamGroup group = league[i];
                for (int j = 0; j < group.Count; j++)
                {
                    Team team = group[j];
                    allPlayers.AddRange(group[j].Roster.Players);
                }
            }
            return allPlayers.ToArray();
        }

        /// <summary>
        /// Gets the individual players from an array of teams.
        /// </summary>
        /// <returns>Player[]</returns>
        /// <param name="teams">Team</param>
        private Player[] GetIndividualPlayersFromTeams(Team [] teams)
        {
            List<Player> allPlayers = new List<Player>();

            for (int j = 0; j < teams.Length; j++)
            {
                Team team = teams[j];
                allPlayers.AddRange(teams[j].Roster.Players);
            }
            
            return allPlayers.ToArray();
        }

        /// <summary>
        /// Gets the ranked players.
        /// </summary>
        /// <value>Player[]</value>
        public Player[] RankedPlayers
        {
            get => players;
        }

        /// <summary>
        /// Gets the category header.
        /// </summary>
        /// <value>string</value>
        public string CategoryHeader => categoryHeader;

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Rankings`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Rankings`1"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }
    }
}

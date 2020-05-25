using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Team group.
    /// </summary>
    public class TeamGroup : EntityList<Team>, IExecutable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamGroup"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        /// <param name="items">List</param>
        public TeamGroup(string id, string name, IEnumerable<Team> items) : base(id, name, items)
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.TeamGroup"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">name</param>
        public TeamGroup(string id, string name) : base(id, name)
        {

        }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroup"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroup"/>.</returns>
        protected override void BuildToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name}");
            foreach (Team team in this)
            {
                sb.AppendLine($"\t{team}");
            }
            this.toString = sb.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroup"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.TeamGroup"/>.</returns>
        public override string ToString()
        {
            if (toString.Length == 0)
                BuildToString();
            return this.toString;
        }

        /// <summary>
        /// Gets all players from all teams in the team group.
        /// </summary>
        /// <returns>Player[]</returns>
        public Player [] GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (Team team in this)
            {
                players.AddRange(team.Roster.Players);
            }
            return players.ToArray();
        }


    }

}

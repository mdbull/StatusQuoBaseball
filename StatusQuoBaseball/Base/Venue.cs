using System;
using System.Linq;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Venue.
    /// </summary>
    [Serializable]
    public class Venue : Entity
    {
        /// <summary>
        /// Represents a generic venue or stadium.
        /// <remarks>Returned if a stadium for a team is not found in a database or file.</remarks>
        /// </summary>
        public static readonly Venue GenericVenue = new Venue("GenericVenue", 40000, "Generic Stadium", "Anytown, USA");
        private readonly int capacity;
        private readonly string name;
        private readonly string location;
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Venue"/> class.
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="id">string</param>
        /// <param name="capacity">int</param>
        /// <param name="name">string</param>
        /// <param name="location">string</param>
        public Venue(Game game, string id, int capacity, string name, string location) : base(id)
        {
            this.game = game;
            this.id = id;
            this.capacity = capacity;
            this.name = name;
            this.location = location;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Venue"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="capacity">int</param>
        /// <param name="name">string</param>
        /// <param name="location">string</param>
        public Venue(string id, int capacity, string name, string location) : base(id)
        {
            this.id = id;
            this.capacity = capacity;
            this.name = name;
            this.location = location;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            this.toString = String.Format("{0}, located in {1}.", this.name, this.location);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Venue"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Venue"/>.</returns>
        public override string ToString()
        {
            return toString;
        }

        /// <summary>
        /// Gets the name of the venue.
        /// </summary>
        /// <value>string</value>
        public string Name => name;

        /// <summary>
        /// Gets the location of the venue.
        /// </summary>
        /// <value>string</value>
        public string Location => location;

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>int</value>
        public int Capacity => capacity;

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <value>Game</value>
        public Game Game{get => game;  set => game=value;}


    }
}

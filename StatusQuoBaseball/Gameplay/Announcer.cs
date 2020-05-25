using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Announcer.
    /// </summary>
    public sealed class Announcer:Entity
    {
        private bool silent;
        private string name = String.Empty;
        private Logger logger;
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Announcer"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        /// <param name="game">Game</param>
        public Announcer(string id, string name, Game game) : base(id)
        {
            this.name = name;
            this.game = game;
            BuildToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Announcer"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        /// <param name="logger">Logger</param>
        public Announcer(string id, string name, Logger logger) : base(id)
        {
            this.name = name;
            this.logger = logger; //The logger will write to a log when it is destroyed at the end of the game
            BuildToString();
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            this.toString = this.name;
        }

        /// <summary>
        /// Announces to console. If a logger was included at initialization, the msg will be logged as well.
        /// </summary>
        /// <param name="msg">string</param>
        public void AnnounceToConsole(string msg)
        {
            if(!this.silent)
                Console.WriteLine(msg);
            if (logger != null)
                logger.LogMessage(msg);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Announcer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Announcer"/>.</returns>
        public override string ToString()
        {
            return toString;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>Game</value>
        public Game Game { get => game; set => game = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Gameplay.Announcer"/> is silent.
        /// If set to " true," game commentary will only be logged (if a logger is attached).
        /// </summary>
        /// <value><c>true</c> if silent otherwise, <c>false</c>.</value>
        public bool Silent { get => silent; set => silent = value; }
    }
}

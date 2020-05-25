using System;
using StatusQuoBaseball.Gameplay;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Statistics container.
    /// </summary>
    public abstract class StatisticsContainer:ICloneable
    {
        /// <summary>
        /// The person.
        /// </summary>
        protected Person person;

        /// <summary>
        /// The game.
        /// </summary>
        protected Game game;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.StatisticsContainer"/> class.
        /// </summary>
        /// <param name="person">Person</param>
        protected StatisticsContainer(Person person)
        {
            this.person = person;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.StatisticsContainer"/> class.
        /// </summary>
        /// <param name="person">Person</param>
        /// <param name="game">Game</param>
        protected StatisticsContainer(Person person, Game game)
        {
            this.person = person;
            this.game = game;
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>The person.</value>
        public Person Person { get => person; set => person = value; }

        /// <summary>
        /// Gets or sets the game associated with this statistics container
        /// </summary>
        /// <value>The game.</value>
        public Game Game { get => this.game; set => this.game = value;  }



        /// <summary>
        /// Logs the stat.
        /// </summary>
        public abstract void LogStat(GamePlayResult result, int toIncrement);

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public abstract void ClearStats();

        /// <summary>
        /// Clone this instance. This is necessary to save a copy of each game's statistics in season mode.
        /// </summary>
        /// <returns>object</returns>
        public abstract object Clone();
    }
}

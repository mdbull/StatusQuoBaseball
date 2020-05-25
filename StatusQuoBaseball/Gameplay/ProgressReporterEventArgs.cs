using System;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Steal attempt event arguments.
    /// </summary>
    public class ProgressReporterEventArgs : EventArgs
    {
        private readonly double progress;
        private readonly int gamesPlayed;
        private readonly int numGames;
        private readonly string nameOfEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.StealAttemptEventArgs"/> class.
        /// </summary>
        /// <param name="numGames">int</param>
        /// <param name="gamesPlayed">int</param>
        /// <param name="nameOfEvent">string</param>
        public ProgressReporterEventArgs(int gamesPlayed, int numGames, string nameOfEvent="")
        {
            this.gamesPlayed = gamesPlayed;
            this.numGames = numGames;
            this.nameOfEvent = nameOfEvent;
            this.progress = this.gamesPlayed / this.numGames;
        }

        /// <summary>
        /// Gets the progress of the RoundRobin.
        /// </summary>
        /// <value>double</value>
        public double Progress => Progress;

        /// <summary>
        /// Gets the games played.
        /// </summary>
        /// <value>int</value>
        public int GamesPlayed => gamesPlayed;

        /// <summary>
        /// Gets the number games.
        /// </summary>
        /// <value>int</value>
        public int NumGames => numGames;

        /// <summary>
        /// Gets the name of event.
        /// </summary>
        /// <value>string</value>
        public string NameOfEvent => nameOfEvent;
    }

}

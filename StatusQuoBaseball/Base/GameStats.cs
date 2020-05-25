using System;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Game stats.
    /// </summary>
    [Serializable]
    public abstract class GameStats: ICloneable
    {
        /// <summary>
        /// The range.
        /// </summary>
        protected string range = String.Empty;

        /// <summary>
        /// To string.
        /// </summary>
        protected string toString = String.Empty;

        /// <summary>
        /// The stamina.
        /// </summary>
        protected int stamina;

        /// <summary>
        /// The player.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.GameStats"/> class.
        /// </summary>
        protected GameStats()
        {
        }

        /// <summary>
        /// Ranges to string. This class and FieldingStats will throw a NotImplementedException.
        /// </summary>
        protected abstract void RangeToString();
      

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected abstract void BuildToString();

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>string</value>
        public string Range { get => range; }

        /// <summary>
        /// Gets or sets the stamina.
        /// </summary>
        /// <value>int</value>
        public int Stamina { get => stamina; set => stamina = value; }

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>Player</value>
        protected Player Player { get => player; set => player = value; }
    }
}

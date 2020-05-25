using System;
namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Strikeout type.
    /// </summary>
    [Serializable]
    public enum StrikeoutType
    {
        /// <summary>
        /// The swinging.
        /// </summary>
        Swinging = 1,

        /// <summary>
        /// The looking.
        /// </summary>
        Looking,

        /// <summary>
        /// The foul tip.
        /// </summary>
        FoulTip,

        /// <summary>
        /// The unknown.
        /// </summary>
        Unknown
    }
}

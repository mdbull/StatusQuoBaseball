﻿using System;
namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Batting results.
    /// </summary>
    [Serializable]
    public enum BattingResults
    {
        /// <summary>
        /// Represents a HBP.
        /// </summary>
        HBP,

        /// <summary>
        /// Represents a BB.
        /// </summary>
        BB,

        /// <summary>
        /// Represents a K.
        /// </summary>
        K,

        /// <summary>
        /// Represents a groundout.
        /// </summary>
        GO,

        /// <summary>
        /// Represents a flyout.
        /// </summary>
        FO,

        /// <summary>
        /// Represents a single.
        /// </summary>
        Single,

        /// <summary>
        /// Represents a double.
        /// </summary>
        Double,

        /// <summary>
        /// Represents a triple.
        /// </summary>
        Triple,

        /// <summary>
        /// Represents a hr.
        /// </summary>
        HR
    }
}

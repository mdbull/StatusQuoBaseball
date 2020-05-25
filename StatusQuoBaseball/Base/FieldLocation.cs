using System;
namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Field locations.
    /// </summary>
    [Serializable]
    public enum FieldLocation
    {
        /// <summary>
        /// The pitcher.
        /// </summary>
        Pitcher = 1,

        /// <summary>
        /// The catcher.
        /// </summary>
        Catcher,

        /// <summary>
        /// The first base.
        /// </summary>
        FirstBase,

        /// <summary>
        /// The second base.
        /// </summary>
        SecondBase,

        /// <summary>
        /// The third base.
        /// </summary>
        ThirdBase,

        /// <summary>
        /// The shortstop.
        /// </summary>
        Shortstop,

        /// <summary>
        /// The left field.
        /// </summary>
        LeftField,

        /// <summary>
        /// The center field.
        /// </summary>
        CenterField,

        /// <summary>
        /// The right field.
        /// </summary>
        RightField,

        /// <summary>
        /// The unknown.
        /// </summary>
        Unknown
    }
}

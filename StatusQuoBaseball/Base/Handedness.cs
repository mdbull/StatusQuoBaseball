using System;
namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Handedness.
    /// </summary>
    [Serializable]
    public enum Handedness
    {
        /// <summary>
        /// Right handedness
        /// </summary>
        Right,

        /// <summary>
        /// Left handedness.
        /// </summary>
        Left,

        /// <summary>
        /// Switch hitters.
        /// </summary>
        Switch,

        /// <summary>
        /// Unknown handedness.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Convert text to handedness.
    /// </summary>
    public static class ConvertTextToHandedness
    {
        /// <summary>
        /// Converts from text.
        /// </summary>
        /// <returns>The from text.</returns>
        /// <param name="text">string</param>
        public static Handedness ConvertFromText(string text)
        {
            if (text.Length == 0)
                return Handedness.Right;
            string h = text.ToUpper();
            if(h[0].Equals('R'))
            {
                return Handedness.Right;
            }
            else if (h[0].Equals('L'))
            {
                return Handedness.Left;
            }
            else if (h[0].Equals('B') || h[0].Equals('S'))
            {
                return Handedness.Switch;
            }
            else
            {
                return Handedness.Unknown;
            }
        }
    }
}

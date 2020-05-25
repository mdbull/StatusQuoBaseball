using System;
namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Use this class to clear bases.
    /// </summary>
    public class NullPlayer:Player
    {
        /// <summary>
        /// Represents a null or empty player.
        /// </summary>
        public static readonly NullPlayer EmptyPlayer = new NullPlayer();

        private NullPlayer():base(String.Empty,String.Empty,String.Empty,String.Empty,String.Empty,Race.Unknown,Handedness.Unknown,Handedness.Unknown,new Height(0), new Weight(0),new Birthday(1975,10,26))
        {
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            this.toString = "Null Player";
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.NullPlayer"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.NullPlayer"/>.</returns>
        public override string ToString()
        {
            return toString;
        }
    }
}

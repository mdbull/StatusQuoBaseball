using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace StatusQuoBaseball.Base.RankingSorters
{
   
    /// <summary>
    /// Sort by wins descending.
    /// </summary>
    public sealed class SortPitchingBySaves: RankingSorter
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public override int Compare(Player x, Player y)
        {
            if (x.SeasonStatistics.SeasonPitchingStatistics.Saves < y.SeasonStatistics.SeasonPitchingStatistics.Saves)
                return 1;
            if (x.SeasonStatistics.SeasonPitchingStatistics.Saves > y.SeasonStatistics.SeasonPitchingStatistics.Saves)
                return -1;
            return 0;
        }
    }
}

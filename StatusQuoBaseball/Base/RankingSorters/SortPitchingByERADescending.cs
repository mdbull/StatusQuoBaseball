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
    public sealed class SortPitchingByERADescending: RankingSorter
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public override int Compare(Player x, Player y)
        {
            if (x.SeasonStatistics.SeasonPitchingStatistics.InningsPitched > 50 && y.SeasonStatistics.SeasonPitchingStatistics.InningsPitched > 50)
            {
                if (x.SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage > y.SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage)
                    return 1;
                if (x.SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage < y.SeasonStatistics.SeasonPitchingStatistics.EarnedRunAverage)
                    return -1;
            }
            return 1;
        }
    }
}

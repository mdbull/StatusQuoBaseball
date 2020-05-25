using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace StatusQuoBaseball.Base.RankingSorters
{
   
    /// <summary>
    /// Sort batting average ascending.
    /// </summary>
    public sealed class SortBattingByHits: RankingSorter
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public override int Compare(Player x, Player y)
        {
            if (x.SeasonStatistics.SeasonBattingStatistics.Hits < y.SeasonStatistics.SeasonBattingStatistics.Hits)
                return 1;
            if (x.SeasonStatistics.SeasonBattingStatistics.Hits > y.SeasonStatistics.SeasonBattingStatistics.Hits)
                return -1;
            return 0;
        }
    }
}

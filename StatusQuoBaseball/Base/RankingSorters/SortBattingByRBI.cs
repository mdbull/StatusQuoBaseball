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
    public sealed class SortBattingByRBI: RankingSorter
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public override int Compare(Player x, Player y)
        {
            if (x.SeasonStatistics.SeasonBattingStatistics.RBI < y.SeasonStatistics.SeasonBattingStatistics.RBI)
                return 1;
            if (x.SeasonStatistics.SeasonBattingStatistics.RBI > y.SeasonStatistics.SeasonBattingStatistics.RBI)
                return -1;
            return 0;
        }
    }
}

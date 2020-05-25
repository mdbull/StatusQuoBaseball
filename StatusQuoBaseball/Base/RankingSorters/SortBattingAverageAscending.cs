using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace StatusQuoBaseball.Base.RankingSorters
{
    /// <summary>
    /// Ranking sorter.
    /// </summary>
    public abstract class RankingSorter : IComparer<Player>
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public abstract int Compare(Player x, Player y);
      
    }
    /// <summary>
    /// Sort batting average ascending.
    /// </summary>
    public sealed class SortBattingAverageAscending: RankingSorter
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="x">Player</param>
        /// <param name="y">Player</param>
        public override int Compare(Player x, Player y)
        {
            if (x.SeasonStatistics.SeasonBattingStatistics.BattingAverage > y.SeasonStatistics.SeasonBattingStatistics.BattingAverage)
                return 1;
            if (x.SeasonStatistics.SeasonBattingStatistics.BattingAverage < y.SeasonStatistics.SeasonBattingStatistics.BattingAverage)
                return -1;
            return 0;
        }
    }
}

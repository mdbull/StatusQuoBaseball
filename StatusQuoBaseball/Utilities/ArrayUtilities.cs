using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Array utilities.
    /// </summary>
    public static class ArrayUtilities<T>
    {


        /// <summary>
        /// Checks if an array contains T item.
        /// </summary>
        /// <returns><c>true</c>, if contains was arrayed, <c>false</c> otherwise.</returns>
        /// <param name="search">T</param>
        /// <param name="array">T</param>
        public static bool ArrayContains(T search, T [] array)
        {
            foreach(T item in array)
            {
                if (EqualityComparer<T>.Default.Equals(item, default(T)))
                {
                    return false;
                }
                if (item.Equals(search))
                    return true;
            }
            return false;
        }

    }
}

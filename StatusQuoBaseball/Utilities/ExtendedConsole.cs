using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using TypeSupport.Extensions;
using StatusQuoBaseball;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Extended console.
    /// </summary>
    public static class ExtendedConsole
    {


        /// <summary>
        /// Prints the IE numerable.
        /// </summary>
        /// <param name="list">IEnumerable</param>
        /// <typeparam name="T">T</typeparam>
        public static void PrintIEnumerable<T>(IEnumerable<T> list)
        {
            List<string> newList = new List<string>();
            newList.Add("[");

            int i = 0;
            int count = ((List<T>)list).Count;
            foreach (T item in list)
            {
                var extendedType = typeof(T).GetExtendedType();

                if (extendedType.IsEnumerable && (typeof(T) != typeof(String)))
                {
                    PrintIEnumerable<T>((IEnumerable<T>)item);
                }
                else
                {
                    newList.Add(PrintType(item));
                    if (i < count - 1)
                        newList.Add(", ");
                }

                i++;
            }
            newList.Add("]\n");
            newList.ForEach(Console.Write);
        }

        /// <summary>
        /// Prints the type.
        /// </summary>
        /// <param name="item">T</param>
        /// <typeparam name="T">T</typeparam>
        private static string PrintType<T>(T item)
        {
            if (item is String)
            {
                return $"\"{item}\"";
            }
            else if (item is Char)
            {
                return $"'{item}'";
            }
            else
            {
                return $"{item}";
            }
        }
    }
}


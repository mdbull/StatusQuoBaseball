using System;
using System.Collections.Generic;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Extension class methods.
    /// </summary>
    public static class ExtensionClassMethods
    {
        /// <summary>
        /// ForEach extension method for Dictionary<typeparamref name="TKey"/>,<typeparamref name="TValue"/>
        /// </summary>
        /// <param name="dictionary">Dictionary.</param>
        /// <param name="invoke">Invoke.</param>
        /// <typeparam name="TKey">The 1st type parameter.</typeparam>
        /// <typeparam name="TValue">The 2nd type parameter.</typeparam>
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> invoke)
        {
            foreach (var kvp in dictionary)
                invoke(kvp.Key, kvp.Value);
        }
    }
}

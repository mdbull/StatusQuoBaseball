using System;
using Newtonsoft.Json;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Dumper.
    /// </summary>
    public static class Dumper
    {
        /// <summary>
        /// Dump the specified object to console.
        /// </summary>
        /// <param name="obj">object</param>
        public static void Dump(this object obj)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj)); // your logger
        }
    }

}

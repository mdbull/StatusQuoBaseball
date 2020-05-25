using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Bullock.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Configuration
{
    /// <summary>
    /// In memory configuration file.
    /// </summary>
    public class InMemoryConfigurationFile : Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Configuration.InMemoryConfigurationFile"/> class.
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public InMemoryConfigurationFile(IDictionary<string, object> dictionary) : base(dictionary)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Configuration.InMemoryConfigurationFile"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Configuration.InMemoryConfigurationFile"/>.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

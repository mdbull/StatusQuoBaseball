using System;

namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Represents an interface for any object that can be loaded from a file or database.
    /// </summary>
    public interface ILoadable
    {
        /// <summary>
        /// Load this instance.
        /// </summary>
        /// <returns>object</returns>
        object Load();
    }
}

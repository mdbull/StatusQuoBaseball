namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Helper class to load an object from a file or database.
    /// </summary>
    public abstract class ObjectLoader: ILoadable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Loaders.ObjectLoader"/> class.
        /// </summary>
        protected ObjectLoader()
        {

        }

        /// <summary>
        /// Load this instance.
        /// </summary>
        /// <returns>object</returns>
        public abstract object Load();
    }
}

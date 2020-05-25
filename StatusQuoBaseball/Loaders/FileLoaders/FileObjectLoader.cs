namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Helper class to load objects from files. Implements ILoadable.
    /// </summary>
    public abstract class FileObjectLoader : ObjectLoader
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        protected string fileName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Loaders.FileObjectLoader"/> class.
        /// </summary>
        /// <param name="fileName">string</param>
        protected FileObjectLoader(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>string</value>
        public string FileName { get => fileName; }

       
    }
}

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Entity.
    /// </summary>
    [Serializable]
    public abstract class Entity:ICloneable
    {
        /// <summary>
        /// Id.
        /// </summary>
        protected string id = string.Empty;

        /// <summary>
        /// Common string for all Entity-derived classes.
        /// <remarks>Used to cache common to string actions.</remarks>
        /// </summary>
        protected string toString = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Entity"/> class.
        /// </summary>
        protected Entity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Entity"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        protected Entity(string id)
        {
            this.id = id;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected virtual void BuildToString()
        {
            this.toString = String.Format($"Entity ID={this.id}");
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Serialize this instance.
        /// </summary>
        /// <returns>MemoryStream</returns>
        public virtual MemoryStream Serialize()
        {
            return SerializationMethods.SerializeToStream(this);
        }

        /// <summary>
        /// Deserialize the specified memoryStream.
        /// </summary>
        /// <returns>Entity</returns>
        /// <param name="memoryStream">MemoryStream</param>
        public static Entity Deserialize(MemoryStream memoryStream)
        {
            return (Entity)SerializationMethods.DeserializeFromStream(memoryStream);
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <returns>long</returns>
        /// <param name="filepath">string</param>
        public long SerializeToFile(string filepath)
        {
            return SerializationMethods.SerializeToFile(this, filepath);
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get => id; set => id = value; }
    }
}

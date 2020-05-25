using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Serialization methods for Serializable classes.
    /// </summary>
    public static class SerializationMethods
    {
        /// <summary>
        /// Serializes object to a MemoryStream.
        /// </summary>
        /// <returns>MemoryStream</returns>
        /// <param name="o">object</param>
        public static MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }

        /// <summary>
        /// Deserializes an object from a MemoryStream.
        /// </summary>
        /// <remarks>This function will not close the MemoryStream object passed in.</remarks>
        /// <returns>MemoryStream</returns>
        /// <param name="stream">object</param>
        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return o;
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <returns>long</returns>
        /// <param name="obj">object</param>
        /// <param name="filePath">string</param>
        public static long SerializeToFile(object obj, string filePath)
        {
            long bytesWritten = 0;
            filePath = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
            Directory.CreateDirectory(filePath.Substring(0, filePath.LastIndexOf('/')));
            MemoryStream theStream = SerializeToStream(obj);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            theStream.WriteTo(fs);
            bytesWritten = fs.Length;
            fs.Close();
            theStream.Close();
            return bytesWritten;
        }
    }
}

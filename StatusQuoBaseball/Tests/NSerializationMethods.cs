using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NSerializationMethods.
    /// </summary>
    [TestFixture]
    public class NSerializationMethods
    {
        private Birthday birthday;
        private Deathday deathday;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            birthday = new Birthday(1964, 7, 24);
            deathday = new Deathday(1988, 1, 1);
        }

        /// <summary>
        /// Tests the serialize to file.
        /// </summary>
        [Test]
        public void TestSerializeToFile()
        {
            long bytesWritten = SerializationMethods.SerializeToFile(birthday,"./Serialized/birthday.bday");
            long bytesWrittenDD = SerializationMethods.SerializeToFile(deathday, "./Serialized/deathday.dday");
            Assert.IsTrue(bytesWritten == 258);
            Assert.IsTrue(bytesWrittenDD == 399);
        }

    }
}

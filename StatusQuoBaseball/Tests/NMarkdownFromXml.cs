using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NMarkdownFromXml.
    /// </summary>
    [TestFixture]
    public class NMarkdownFromXml
    {
        MarkdownFromXMLGenerator generator;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [SetUp]
        public void Init()
        {
            generator = new MarkdownFromXMLGenerator();
        }

        /// <summary>
        /// Test this instance.
        /// </summary>
        [Test]
        public void Test()
        {
            string XML_FILE_PATH = "./StatusQuoBaseball.xml";
            string md = generator.ToMarkdown(XML_FILE_PATH);
            Console.WriteLine(md);
            Assert.IsTrue(md.Length > 0);
            int charWritten = generator.ToMarkdownFile(XML_FILE_PATH);
            Console.WriteLine(charWritten);
            Assert.IsTrue(charWritten > 0);
            Assert.IsTrue(File.Exists("./StatusQuoBaseball.md"));
        }
    }
}

using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NUniform.
    /// </summary>
    [TestFixture]
    public class NUniform
    {
        /// <summary>
        /// Tests the load arizona uniforms from file.
        /// </summary>
        [Test]
        public void TestLoadArizonaUniformsFromFile()
        {
            int expectedLines = 48;
            string path = @"./Data/BaseballReference/Arizona Diamondbacks_(2001)/Arizona Diamondbacks_(2001) Uniforms.dat";
            Assert.IsTrue(File.Exists(path));
            try
            {
                Uniform[] uniforms = UniformsLoader.LoadUniformsFromFile(path);
                Assert.IsTrue(uniforms.Length == expectedLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Tests the load seattle uniforms from file.
        /// </summary>
        [Test]
        public void TestLoadSeattleUniformsFromFile()
        {
            int expectedLines = 53;
            string path = @"./Data/BaseballReference/Seattle Mariners_(1993)/Seattle Mariners_(1993) Uniforms.dat";
            Assert.IsTrue(File.Exists(path));
            try
            {
                Uniform[] uniforms = UniformsLoader.LoadUniformsFromFile(path);
                Assert.IsTrue(uniforms.Length == expectedLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Tests the load new york uniforms from file.
        /// </summary>
        [Test]
        public void TestLoadNewYorkUniformsFromFile()
        {
            int expectedLines = 49;
            string path = @"./Data/BaseballReference/New_York Yankees_(2001)/New_York Yankees_(2001) Uniforms.dat";
            Assert.IsTrue(File.Exists(path));
            try
            {
                Uniform[] uniforms = UniformsLoader.LoadUniformsFromFile(path);
                Assert.IsTrue(uniforms.Length == expectedLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

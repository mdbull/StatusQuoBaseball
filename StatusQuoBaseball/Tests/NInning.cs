using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Gameplay;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NI nning.
    /// </summary>
    [TestFixture]
    public class NInning
    {
        private List<Inning> innings = new List<Inning>();

        /// <summary>
        /// Tests the inning names.
        /// </summary>
        [Test]
        public void TestInningNames()
        { 
            for(int i=0; i < 9; i++)
            {
                innings.Add(new Inning(i + 1,null));
            }
            innings.ForEach(Console.WriteLine);
        }
    }
}

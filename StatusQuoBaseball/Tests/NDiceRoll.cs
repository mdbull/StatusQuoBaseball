using NUnit.Framework;
using System;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    /// <summary>
    /// NDiceRoll.
    /// </summary>
    [TestFixture]
    public class NDiceRoll
    {
        /// <summary>
        /// Tests the single dice roll.
        /// </summary>
        [Test]
        public void TestSingleDiceRoll()
        {
            Assert.IsTrue(Dice.Roll(11, 88) > 0);
        }

        /// <summary>
        /// Tests the multiple dice roll.
        /// </summary>
        [Test]
        public void TestMultipleDiceRoll()
        {
            int result = Dice.Roll(1, 6, 3);
            Assert.IsTrue(result >= 3 && result <= 18);
        }

        /// <summary>
        /// Test2d10s the dice roll.
        /// </summary>
        [Test]
        public void Test2d10DiceRoll()
        {
            Assert.IsTrue(Dice.Roll2d10() > 0);
            for (int i = 0; i < 20; i++)
                Console.WriteLine(Dice.Roll2d10());
        }


    }
}

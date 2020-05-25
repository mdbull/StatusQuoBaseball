using NUnit.Framework;
using System;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Tests
{
    [TestFixture()]
    public class NPitcherVersusBatter
    {
        private const int AT_BATS = 300;

        Player ryan = new Player(Guid.NewGuid().ToString(),"Ryan", "Nolan", "34", Positions.PositionNames[0], Race.White, Handedness.Right, Handedness.Right, new Height(74), new Weight(190), new Birthday(1947, 1, 31));

        private PitchingStats ps = new PitchingStats(75, 1, 3, 20, 50, 55, 65, 75, 85, 87, 100);

        Player p = new Player(Guid.NewGuid().ToString(),"Bonds", "Barry", "25", Positions.PositionNames[6], Race.Black, Handedness.Left, Handedness.Left, new Height(74), new Weight(225), new Birthday(1964, 7, 24));

        private BattingStats bs = new BattingStats(10, 88, 1, 20, 25, 35, 45, 60, 75, 80, 100);

        [Test()]
        public void TestPitcherVersusBatterOutcomes()
        {

            ryan.PitchingStats = ps;

            p.BattingStats = bs;

            ryan.PitchingStats.CurrentControl -= p.BattingStats.ControlModifier;

            Assert.IsTrue(ryan.PitchingStats.Control == 75);
            Assert.IsTrue(ryan.PitchingStats.CurrentControl == 65);

            Dictionary<PitchResults, int> frequencyPitcherControl = new Dictionary<PitchResults, int>();
            Dictionary<BattingResults, int> frequencyBatterControl = new Dictionary<BattingResults, int>();

            int pitcherControl = 0;

            int hits = 0;

            for (int i = 0; i < AT_BATS; i++)
            {
                int roll = Dice.Roll2d10();
                if (roll <= ryan.PitchingStats.Control)
                {
                    pitcherControl++;
                    roll = Dice.Roll2d10();
                    PitchResults key = ryan.PitchingStats.PitchResults[roll - 1];
                    if (!frequencyPitcherControl.ContainsKey(key))
                        frequencyPitcherControl.Add(key, 1);
                    else
                        frequencyPitcherControl[key] += 1;
                    if (BattingStats.IsHit(key) == true)
                        hits++;
                }
                else
                {

                    roll = Dice.Roll2d10();
                    BattingResults key2 = p.BattingStats.BattingResults[roll - 1];
                    if (!frequencyBatterControl.ContainsKey(key2))
                        frequencyBatterControl.Add(key2, 1);
                    else
                        frequencyBatterControl[key2] += 1;
                    if (BattingStats.IsHit(key2) == true)
                        hits++;
                }
            }

            Dictionary<PitchResults, int>.Enumerator cursor = frequencyPitcherControl.GetEnumerator();
            Console.WriteLine("The pitcher remained control {0} out of {1} at bats [{2:P}]", pitcherControl, AT_BATS, ((double)pitcherControl / (double)AT_BATS));
            while (cursor.MoveNext())
                Console.WriteLine(cursor.Current.ToString());

            Console.WriteLine("Results when the batter retained control");
            Dictionary<BattingResults, int>.Enumerator cursor2 = frequencyBatterControl.GetEnumerator();
            while (cursor2.MoveNext())
                Console.WriteLine(cursor2.Current.ToString());

            Console.WriteLine("The batter had a batting average of {0:.000}", ((double)hits/(double)AT_BATS));

        }
    }
}

using System;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Dice class.
    /// </summary>
    public static class Dice
    {
        private static Random rgenerator = new Random();

        /// <summary>
        /// Initializes the <see cref="T:StatusQuoBaseball.Utilities.Dice"/> class.
        /// </summary>
        static Dice()
        {
            
        }

        /// <summary>
        /// Roll the dice, N times.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="min">int</param>
        /// <param name="max">int</param>
        /// <param name="dice">int</param>
        public static int Roll(int min, int max, int dice=1)
        {
            int total = 0;
            for (int i=0; i < dice; i++)
            {
                total += rgenerator.Next(min, max);
            }
            return total;
        }

        /// <summary>
        /// Roll2d10 this instance.
        /// </summary>
        /// <returns>The roll2d10.</returns>
        public static int Roll2d10()
        {
            int redDie = Roll(0, 9);
            int clearDie = Roll(0, 9);

            if ((redDie == 0) && (clearDie !=0))
            {
                return clearDie;
            }
            else if (redDie > 0)
            {
                string val = String.Format("{0}{1}", redDie, clearDie);
                return Int32.Parse(val);
            }
            else
            {
                return 100;
            }
        }
    }


}

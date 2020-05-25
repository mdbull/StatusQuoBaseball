using System;
namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Ordinal number generator.
    /// </summary>
    public static class OrdinalNumberGenerator
    {
        /// <summary>
        /// Initializes the <see cref="T:StatusQuoBaseball.Utilities.OrdinalNumberGenerator"/> class.
        /// </summary>
        /// <param name="number">Number.</param>
        public static string Generate(int number)
        {
            string temp = number.ToString();
            char lastDigit = temp[temp.Length - 1];
            switch (lastDigit)
            {
                case '1':
                    temp = String.Format($"{number}st");
                    break;
                case '2':
                    temp = String.Format($"{number}nd");
                    break;
                case '3':
                    temp = String.Format($"{number}rd");
                    break;
                default:
                    temp = String.Format($"{number}th");
                    break;
            }

            return temp;
        }
    }
}

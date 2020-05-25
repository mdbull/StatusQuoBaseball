using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Text fill justification.
    /// </summary>
    [Serializable]
    public enum TextFillJustification
    {
        /// <summary>
        /// Left Justification
        /// </summary>
        Left,

        /// <summary>
        /// Center Justification
        /// </summary>
        Center,

        /// <summary>
        /// Right Justification
        /// </summary>
        Right
    }

    /// <summary>
    /// Text.
    /// </summary>
    public static class TextUtilities
    {
        /// <summary>
        /// Gets the indices of char in a string.
        /// </summary>
        /// <returns>int[]</returns>
        /// <param name="theString">string</param>
        /// <param name="theChar">char</param>
        public static int [] GetIndicesOfChar(string theString, char theChar)
        {
            List<int> indices = new List<int>();

            for(int i=0; i < theString.Length; i++)
            {
                if (theString[i] == theChar)
                    indices.Add(i);
            }

            return indices.ToArray();
        }

        /// <summary>
        /// Forms the name of the file path.
        /// </summary>
        /// <returns>The file path name.</returns>
        /// <param name="directory">Directory.</param>
        /// <param name="info">Info.</param>
        /// <param name="extension">Extension.</param>
        public static string FormFilePathName(string directory, string info, string extension)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            return String.Format($"{directory}{directoryInfo.Name} {info}{extension}");
        }


        /// <summary>
        /// Text-based progress bar
        /// </summary>
        /// <returns>string</returns>
        /// <param name="iteration">int</param>
        /// <param name="loops">int</param>
        /// <param name="filler">char</param>
        /// <param name="symbol">char</param>
        public static string ProgressBar(int iteration, int loops,char filler=' ', char symbol='|')
        {
            try
            {
                string space = new string(symbol, iteration);
                string bar = FillString(space, filler, (uint)loops);
                return $"{bar} ({(iteration / loops).ToString("P")})\r";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
            return "Progress Bar error\r";
        }

        /// <summary>
        /// Text-based progress bar.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="msg">string</param>
        /// <param name="iteration">int</param>
        /// <param name="loops">int</param>
        /// <param name="interval">int</param>
        /// <param name="filler">char</param>
        /// <param name="symbol">char</param>
        public static string ProgressBar(string msg, int iteration, int loops, int interval=1, char filler =' ', char symbol = '|')
        {
            try
            {
                string space = new string(symbol, iteration / interval);
                string bar = FillString(space, filler, (uint)loops / (uint)interval);
                return $"{msg} {bar} ({(iteration / loops).ToString("P")})\r";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
            return "Progress Bar error\r";
        }

        /// <summary>
        /// Gets the length of longest string.
        /// </summary>
        /// <returns>The length of longest string.</returns>
        /// <param name="strings">int</param>
        public static int GetLengthOfLongestString(params string [] strings)
        {
            int longest = 0;
            foreach(string s in strings)
            {
                if (s.Length > longest)
                    longest = s.Length;
            }
            return longest;
        }

        /// <summary>
        /// Fills the string.
        /// </summary>
        /// <returns>string</returns>
        /// <param name="s">string</param>
        /// <param name="filler">string</param>
        /// <param name="totalLength">uint</param>
        /// <param name="justification">TextFillJustification.</param>
        public static string FillString(string s, char filler, uint totalLength, TextFillJustification justification = TextFillJustification.Left)
        {
            int fillerLength = (int)(totalLength - s.Length);
            string fillerText = new String(filler, fillerLength);
            StringBuilder ret = new StringBuilder();

            try
            {
                switch (justification)
                {
                    case TextFillJustification.Left:
                        ret.AppendFormat($"{s}{fillerText}");
                        break;
                    case TextFillJustification.Center:
                        int quarterPoint = (int)totalLength / 4;
                        if ((totalLength % 4) == 0)
                        {
                            ret.AppendFormat($"{new string(filler, fillerLength / 2)}");
                            ret.Append(s);
                            ret.AppendFormat($"{new string(filler, fillerLength / 2)}");
                        }
                        else
                        {
                            ret.AppendFormat($"{new string(filler, quarterPoint)}");
                            ret.Append(s);
                            ret.AppendFormat($"{new string(filler, quarterPoint - 1)}");
                        }
                        break;
                    case TextFillJustification.Right:
                        ret.AppendFormat($"{fillerText}{s}");
                        break;
                    default:
                        ret.Append(s);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret.ToString();
        }
    }
}

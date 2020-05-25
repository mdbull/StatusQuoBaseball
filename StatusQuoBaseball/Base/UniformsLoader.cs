using System;
using System.IO;
using System.Collections.Generic;
using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Uniforms loader.
    /// </summary>
    public static class UniformsLoader
    {
        /// <summary>
        /// Loads the fielding stats.
        /// </summary>
        /// <returns>Uniform[]</returns>
        /// <param name="filePath">string</param>
        public static Uniform[] LoadUniformsFromFile(string filePath)
        {
            List<Uniform> ret = new List<Uniform>();
            Dictionary<int, Uniform> data = new Dictionary<int, Uniform>();
            //1. read file
            if (File.Exists(filePath))
            {
                int i = 0;
                StreamReader handle = new StreamReader(filePath);

                string[] numberLine = handle.ReadLine().Split(' ');
                Uniform uni = null;
                bool reachedNextNumber = false;
                bool firstLoop = true;
                int number = 0;
                List<string> name = new List<string>();
                while (i < numberLine.Length)
                {
                    reachedNextNumber = false;
                    while (!reachedNextNumber)
                    {
                        if (i < numberLine.Length)
                        {
                            string val = numberLine[i];
                            int result = 0;
                            if (Int32.TryParse(val, out result))
                            {

                                //we have a number, load it then check next token
                                if (firstLoop)
                                {
                                    firstLoop = false;
                                }
                                else
                                {
                                    try
                                    {
                                        if (name.Count > 2)
                                        {
                                            List<Uniform> unis = new List<Uniform>();
                                            if (name.Count % 2 == 0)
                                            {
                                                //even number of name tokens, split at every 2 elements
                                                for (int j = 0; j < name.Count; j += 2)
                                                {
                                                    (var fname, var lname) = Person.GetNameParts(String.Concat(name[j], " ", name[j + 1]), "_");
                                                    unis.Add(new Uniform(fname, lname, number.ToString()));
                                                }
                                                ret.AddRange(unis);
                                            }
                                        }
                                        else
                                        {
                                            (var fname, var lname) = Person.GetNameParts(String.Concat(name[0], " ", name[1]), "_");
                                            //Tuple<string, string> tempName = Person.GetNameParts(String.Concat(name[0], " ", name[1]), "_");
                                            uni = new Uniform(fname, lname, number.ToString());
                                            ret.Add(uni);
                                        }
                                        reachedNextNumber = true;
                                        name.Clear();

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                                number = Int32.Parse(val);


                            }
                            else
                            {
                                name.Add(numberLine[i]);
                                reachedNextNumber = false;

                            }
                            i++;
                        }
                        else
                        {
                            (var fname, var lname) = Person.GetNameParts(String.Concat(name[0], " ", name[1]), "_");
                            uni = new Uniform(fname, fname, number.ToString());
                            name.Clear();
                            ret.Add(uni);
                            reachedNextNumber = true;
                        }
                    }
                }
                handle.Dispose();
                return ret.ToArray();
            }

            return null;
        }


    }
}

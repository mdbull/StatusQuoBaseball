using System;
using System.IO;
using System.Collections.Generic;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// In memory CSV File.
    /// </summary>
    public class InMemoryCSVFile
    {
        private string filePath = String.Empty;
        private bool hasHeaderRow;
        private List<string[]> lines;
        private int maxColumns;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.InMemoryCSVFile"/> class.
        /// </summary>
        protected InMemoryCSVFile(string filePath, int maxColumns, bool hasHeaderRow, List<string[]> lines)
        {
            this.lines = lines;
            this.filePath = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
            this.maxColumns = maxColumns;
            this.hasHeaderRow = hasHeaderRow;
        }

        /// <summary>
        /// Reads the CSV File.
        /// </summary>
        /// <returns>InMemoryCSVFile</returns>
        /// <param name="filePath">string</param>
        /// <param name="delimiter">char</param>
        /// <param name="hasHeaderRow">bool</param>
        public static InMemoryCSVFile ReadCSVFile(string filePath, bool hasHeaderRow = false,char delimiter=',')
        {
         
            int maxColumnLength = 0;
            List<string[]> ret = new List<string[]>();
            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader fs = new StreamReader(filePath);
                    if (hasHeaderRow)
                        ret.Add(fs.ReadLine().Split(delimiter));
                    while(!fs.EndOfStream)
                    {
                        string [] line = fs.ReadLine().Split(delimiter);
                        if (line.Length > maxColumnLength)
                            maxColumnLength = line.Length;
                        if(line.Length>1)//skip over blank lines
                            ret.Add(line);
                    }

                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                throw new IOException($"File '{filePath}' was not found. Unable to load CSV File.");
            }
            InMemoryCSVFile csvFile =  new InMemoryCSVFile(filePath, maxColumnLength, hasHeaderRow, ret);
            return csvFile;
        }


        /// <summary>
        /// Gets the CSV file path.
        /// </summary>
        /// <value>string</value>
        public string FilePath { get => filePath;}

        /// <summary>
        /// Gets the line count.
        /// </summary>
        /// <value>The line count.</value>
        public int LineCount
        {
            get { return lines.Count; }
        }

        /// <summary>
        /// Gets the line.
        /// </summary>
        /// <returns>string[]</returns>
        /// <param name="lineIndex">int</param>
        public string[] this[int lineIndex]
        {
            get { return lines[lineIndex]; }
        }

        /// <summary>
        /// Gets the header row. Will return an empty array if no header row.
        /// </summary>
        /// <value>string[]</value>
        public string[] HeaderRow
        {
            get
            {
                if(hasHeaderRow)
                {
                    return lines[0];
                }
                return new string[maxColumns];
            }
        }

        /// <summary>
        /// Gets the max columns.
        /// </summary>
        /// <value>The max columns.</value>
        public int MaxColumns { get => maxColumns; }

        /// <summary>
        /// Gets the file path1.
        /// </summary>
        /// <value>The file path1.</value>
        public string FilePath1 { get => filePath;  }
    }

}

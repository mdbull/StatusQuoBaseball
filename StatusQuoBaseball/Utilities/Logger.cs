using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Gameplay;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Loggable class that will use a logger to write info to file.
    /// </summary>
    public interface ILoggable
    {
        /// <summary>
        /// Log this instance.
        /// </summary>
        void Log();
    }

    /// <summary>
    /// Logger.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// The file extension.
        /// </summary>
        public static readonly string FILE_EXTENSION = ".game"; //This will be retrieved from a config file

        private string filePath = String.Empty;
        private StringBuilder sb = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.Logger"/> class.
        /// </summary>
        /// <param name="filePath">string</param>
        public Logger(string filePath)
        {
            this.filePath = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
        }

        /// <summary>
        /// Writes to log.
        /// </summary>
        /// <returns>The to log.</returns>
        /// <param name="msg">Message.</param>
        public void LogMessage(string msg)
        {
            this.sb.AppendLine(msg);

        }

        /// <summary>
        /// Write information to file.
        /// </summary>
        /// <returns>The to log.</returns>
        public int WriteToFile()
        {
            //string dir = Configuration.ConfigurationManager.GetConfigurationValue("GAME_FILE_DIRECTORY");
            Directory.CreateDirectory(this.filePath.Substring(0,this.filePath.LastIndexOf('/')));

            FileStream fs = new FileStream(this.filePath, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);
            try
            {
                streamWriter.Write(this.sb);
            }
            catch(IOException ex)
            {
                throw ex;
            }
            finally
            {
                streamWriter.Dispose();
                fs.Dispose();
            }
            return this.sb.Length;

        }

        public void OpenFileInEditor()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/usr/bin/gedit", Arguments = $"'{this.filePath}'", };
                Process proc = new Process() { StartInfo = startInfo, };
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to open file '{this.filePath}'");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>string</value>
        public string FilePath { get => filePath;}

    }
}

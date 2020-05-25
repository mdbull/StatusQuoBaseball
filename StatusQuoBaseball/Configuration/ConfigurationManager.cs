using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Bullock.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Configuration
{

    /// <summary>
    /// Configuration manager exception.
    /// </summary>
    public class ConfigurationManagerException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:StatusQuoBaseball.Configuration.ConfigurationManagerException"/> class.
        /// </summary>
        /// <param name="msg">string</param>
        /// <param name="innerException">Exception</param>
        public ConfigurationManagerException(string msg, Exception innerException):base(msg,innerException)
        {
          
        }
    }

    /// <summary>
    /// Configuration reader and Manager
    /// </summary>
    public class ConfigurationManager
    {

        private static Dictionary<string, string> configurationFile = new Dictionary<string, string>();
        private static Dictionary<string, Dictionary<string, string>> configurationFiles = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Configuration.ConfigurationManager"/> class.
        /// </summary>
        private ConfigurationManager()
        {

        }

        /// <summary>
        /// Initializes the ConfigReader with a single config file.
        /// </summary>
        /// <param name="configFilePath">string</param>
        /// <param name="delimiter">char</param>
        /// <param name="commentChar">char</param>
        public static void Init(string configFilePath, char delimiter, char commentChar='#')
        {
            configFilePath = Path.Combine(configFilePath.Split(Path.DirectorySeparatorChar));
            configurationFile.Clear();
            configurationFiles.Clear();
            StreamReader fs = null;
            string line = String.Empty;
            string[] configLine = null;
            try
            {
                fs = new StreamReader(configFilePath);
                while (fs.Peek() != -1)
                {
                    //check for comment line
                    line = fs.ReadLine();
                    if (!line.Contains(commentChar))
                    {
                        configLine = line.Split(delimiter);

                        configurationFile.Add(configLine[0], configLine[1]);
                    }
                }
                configurationFiles.Add(configFilePath, configurationFile);
            }
            catch (Exception ex)
            {
                throw new ConfigurationManagerException($"Unable to open file '{configFilePath}'. File does not exist.",ex);
            }
        }

        /// <summary>
        /// Initializes the configuration manager with multiple config files.
        /// </summary>
        /// <param name="configFilePath">string[]</param>
        /// <param name="delimiter">char</param>
        /// <param name="secondDelimeter">char</param>
        public static void Init(string [] configFilePath, char delimiter, char secondDelimeter = ',')
        {
            secondDelimeter.ToString();
            configurationFile.Clear();
            configurationFiles.Clear();
            StreamReader fs = null;
            string line = String.Empty;
            string[] configLine = null;

            foreach (var item in configFilePath)
            {
                configurationFiles.Add(item, new Dictionary<string, string>());
                try
                {
                    fs = new StreamReader(item);
                    while (fs.Peek() != -1)
                    {
                        //check for comment line
                        line = fs.ReadLine();
                        if (!line.Contains(Constants.CONFIG_FILE_COMMENT_CHAR))
                        {
                            configLine = line.Split(delimiter);

                            configurationFiles[item].Add(configLine[0], configLine[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(new ConfigurationManagerException($"Unable to open file '{configFilePath}'. File does not exist.", ex));
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// Can be used to return info from files that are in k=v format, without maintaining information in the ConfigurationManager.
        /// </summary>
        /// <returns>InMemoryConfigurationFile</returns>
        /// <param name="filePath">string</param>
        /// <param name="delimiter">char</param>
        public static InMemoryConfigurationFile GetInMemoryConfigFile(string filePath, char delimiter='=')
        {
            Dictionary<string, object> fileLines = new Dictionary<string, object>();
            StreamReader fs = null;
            string line = String.Empty;
            string[] configLine = null;
            try
            {
                fs = new StreamReader(filePath);
                while (fs.Peek() != -1)
                {
                    //check for comment line
                    line = fs.ReadLine();
                    if (!line.Contains(Constants.CONFIG_FILE_COMMENT_CHAR))
                    {
                        configLine = line.Split(delimiter);

                        fileLines.Add(configLine[0], configLine[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationManagerException($"Unable to open file '{filePath}'. File does not exist.", ex);
            }
            finally
            {
                fs.Close();
            }
            return new InMemoryConfigurationFile(fileLines);
        }

        /// <summary>
        /// Gets the value for the key in a configuration manager with only one config file.
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        public static string GetConfigurationValue(string key)
        {
            if (configurationFiles.Count > 0)
            {
                if (configurationFiles.ElementAt(0).Value.ContainsKey(key))
                    return configurationFile[key];
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the configuration value when the configuration manager has multiple config files.
        /// </summary>
        /// <returns>The configuration value.</returns>
        /// <param name="fileName">string</param>
        /// <param name="key">string</param>
        public static string GetConfigurationValue(string fileName, string key)
        {
            if (configurationFiles[fileName].ContainsKey(key))
                return configurationFiles[fileName][key];
            return string.Empty;
        }

        /// <summary>
        /// Gets the number of config files being managed.
        /// </summary>
        /// <value>The count.</value>
        public static int Count
        {
            get => configurationFiles.Count;
        }

        /// <summary>
        /// Gets the number of lines in a particular config file.
        /// </summary>
        /// <returns>The config file size.</returns>
        /// <param name="fileName">File name.</param>
        public static int GetConfigFileSize(string fileName)
        {
            return configurationFiles[fileName].Count;
        }

    }
}

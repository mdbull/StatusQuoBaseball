using System;
using System.Diagnostics;
using Bullock.TextMenu;

namespace StatusQuoBaseball.Menu
{
    /// <summary>
    /// Program exit.
    /// </summary>
    public static class ProgramExit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r">Runnable</param>
        public static void Exit(Runnable r)
        {
            Console.WriteLine("Exiting Status Quo Baseball. Goodbye!");
            Environment.Exit(0);
        }

    }

    /// <summary>
    /// Clean games folder.
    /// </summary>
    public static class CleanGamesFolder
    {
        /// <summary>
        /// Loads the clean games folder.
        /// </summary>
        public static void LoadCleanGamesFolder(Runnable r)
        {
            Console.WriteLine("Cleaning 'Games' folder...");
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/rm", Arguments = "-r ./Games", };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }

       

    }
}

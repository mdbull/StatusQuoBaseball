using System;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Loads venues from a CSV file.
    /// At the moment, the CSV file is more complete than the Lahman database.
    /// </summary>
    public static class VenueManager
    {
        private static Dictionary<string, Venue> venues;


        /// <summary>
        /// Loads all venues from a file.
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="hasHeaderRows">bool</param>
        public static void Init(string filePath, bool hasHeaderRows)
        {
            LoadVenuesFromFile(filePath, hasHeaderRows);
        }
        
        /// <summary>
        /// Loads all venues from file.
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="hasHeaderRow">If set to <c>true</c> has header row.</param>
        private static void LoadVenuesFromFile(string filePath, bool hasHeaderRow = false)
        {
            Dictionary<string, Venue> ret = new Dictionary<string, Venue>();
            InMemoryCSVFile venueCSV = InMemoryCSVFile.ReadCSVFile(filePath);

            for (int i = hasHeaderRow ? 1 : 0; i < venueCSV.LineCount; i++)
            {

                string id = venueCSV[i][4];//Team name is id
                int capacity = Convert.ToInt32(venueCSV[i][1]);
                string name = venueCSV[i][0];
                string[] location = venueCSV[i][2].Split('|');
                Venue theVenue = new Venue(id, capacity, name, $"{location[0]}, {location[1]}");
                ret.Add(id, theVenue);
            }
            venues = ret;
        }

        /// <summary>
        /// Gets the venue.
        /// </summary>
        /// <returns>Venue</returns>
        /// <param name="teamName">Team name.</param>
        public static Venue GetVenue(string teamName)
        {
            if (venues.ContainsKey(teamName))
                return venues[teamName];
            return new Venue($"{teamName}stad", Dice.Roll(30000, 40000), $"{teamName} Stadium", $"{teamName} City");
        }



        /// <summary>
        /// Gets the venue count.
        /// </summary>
        /// <value>int</value>
        public static int VenueCount
        {
            get { return venues.Count; }
        }
    }
}

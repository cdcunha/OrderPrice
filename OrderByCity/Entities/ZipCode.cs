using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrice.Entities
{
    /// <summary>
    /// Zip code class
    /// </summary>
    public class ZipCode
    {
        /// <summary>
        /// Zip code major
        /// </summary>
        public int CodeMajor { get; set; }

        /// <summary>
        /// Zip code minor
        /// </summary>
        public int CodeMinor { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Receive CSV line and convert to ZipCode object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <returns>ZipCode object</returns>
        public static ZipCode FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            ZipCode zipCode = new ZipCode
            {
                CodeMajor = Convert.ToInt32(values[0]),
                CodeMinor = Convert.ToInt32(values[1]),
                City = values[2].ToString()
            };
            
            return zipCode;
        }
    }
}

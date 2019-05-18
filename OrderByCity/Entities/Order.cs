using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderPrice.Entities
{
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID
        /// </summary>
        public string Id { get; set; }

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
        /// Receive CSV line and convert to Order object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <param name="zipCodes">ZipCode list</param>
        /// <returns>Order object</returns>
        public static Order FromCsv(string csvLine, List<ZipCode> zipCodes)
        {
            string[] values = csvLine.Split(',');

            int codeMajor = Convert.ToInt32(values[1]);
            int codeMinor = Convert.ToInt32(values[2]);
            string city = zipCodes.Where(e => e.CodeMajor == codeMajor && e.CodeMinor == codeMinor)
                .Select(s => s.City)
                .FirstOrDefault() ?? "CITY NOT FOUND";

            Order zipCode = new Order
            {
                Id = values[0],
                CodeMajor = codeMajor,
                CodeMinor = codeMinor,
                City = city
            };

            return zipCode;
        }
    }
}

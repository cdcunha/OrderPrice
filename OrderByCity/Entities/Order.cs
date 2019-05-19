using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByCity.Entities
{
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Zip code major
        /// </summary>
        public int CodeMajor { get; private set; }

        /// <summary>
        /// Zip code minor
        /// </summary>
        public int CodeMinor { get; private set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Receive CSV line and convert to Order object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <param name="zipCodes">ZipCode list</param>
        /// <returns>Order object</returns>
        public static Order FromCsv(string csvLine, List<ZipCode> zipCodes)
        {
            //Get columns of CSV line
            string[] values = csvLine.Split(',');

            //Get zip code values
            int codeMajor = Convert.ToInt32(values[1]);
            int codeMinor = Convert.ToInt32(values[2]);

            //Get city by zip code. If not found, set city to "CITY NOT FOUND"
            string city = zipCodes.Where(e => e.CodeMajor == codeMajor && e.CodeMinor == codeMinor)
                .Select(s => s.City)
                .FirstOrDefault() ?? "CITY NOT FOUND";

            //Convert line to object
            Order zipCode = new Order
            {
                Id = values[0],
                CodeMajor = codeMajor,
                CodeMinor = codeMinor,
                City = city
            };

            return zipCode;
        }

        /// <summary>
        /// Check if CSV line is valid
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <returns></returns>
        public static bool IsCsvValid(string csvLine)
        {
            try
            {
                //Get columns of CSV line
                string[] values = csvLine.Split(',');

                //If the line doesn't have 3 columns the line is invalid
                if (values.Length != 3)
                {
                    return false;
                }
                else
                {
                    //If the second column is integer type, the line is valid
                    int.Parse(values[1]);

                    //If the third column is integer type, the line is valid
                    int.Parse(values[2]);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

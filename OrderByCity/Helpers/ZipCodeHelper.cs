using OrderPrice.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderPrice.Helpers
{
    public static class ZipCodeHelper
    {
        /// <summary>
        /// Get zip code list from CSV file
        /// </summary>
        /// <param name="fullFileName">CSV file full name</param>
        /// <returns>ZipCod List</returns>
        public static List<ZipCode> GetZipCodes(string fullFileName)
        {
            var zipCodes = new List<ZipCode>();

            if (!string.IsNullOrWhiteSpace(fullFileName))
            {
                zipCodes = File.ReadAllLines(fullFileName)
                    .Skip(1)
                    .Select(e => ZipCode.FromCsv(e))
                    .ToList();
            }

            return zipCodes;
        }
    }
}

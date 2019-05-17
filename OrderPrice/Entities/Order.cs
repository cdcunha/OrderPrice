using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderPrice.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public int CodeMajor { get; set; }
        public int CodeMinor { get; set; }
        public string City { get; set; }

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

using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrice.Entities
{
    public class ZipCode
    {
        public int CodeMajor { get; set; }
        public int CodeMinor { get; set; }
        public string City { get; set; }

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

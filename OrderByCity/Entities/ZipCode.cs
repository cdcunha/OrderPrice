using System;

namespace OrderByCity.Entities
{
    /// <summary>
    /// Zip code class
    /// </summary>
    public class ZipCode
    {
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
        /// Receive CSV line and convert to ZipCode object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <returns>ZipCode object</returns>
        public static ZipCode FromCsv(string csvLine)
        {
            //Get columns of CSV line
            string[] values = csvLine.Split(',');

            //Convert line to object
            ZipCode zipCode = new ZipCode
            {
                CodeMajor = Convert.ToInt32(values[0]),
                CodeMinor = Convert.ToInt32(values[1]),
                City = values[2].ToString()
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

                //If the line doesn't have 3 columns, the line is invalid
                if (values.Length != 3)
                {
                    return false;
                }
                else
                {
                    //If the firs column is integer type, the line is valid
                    int.Parse(values[0]);

                    //If the second column is integer type, the line is valid
                    int.Parse(values[1]);
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

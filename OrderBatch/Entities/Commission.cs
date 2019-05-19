using System;

namespace OrderBatch.Entities
{
    /// <summary>
    /// Commision Class
    /// </summary>
    public class Commission
    {
        /// <summary>
        /// Boutique ID
        /// </summary>
        public string BoutiqueId { get; private set; }

        /// <summary>
        /// Order ID
        /// </summary>
        public string OrderId { get; private set; }

        public decimal CommisionRate => 0.10m;

        /// <summary>
        /// Total Order price
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Commision 10%
        /// </summary>
        /// <remarks>For the highest value of the day will not be subject to commission</remarks>
        public decimal Commision { get; set; }

        public Commission(string boutiqueId, string orderId, decimal totalPrice)
        {
            BoutiqueId = boutiqueId;
            OrderId = orderId;
            TotalPrice = totalPrice;

            //Get 10% of commision 
            Commision = TotalPrice * CommisionRate;
        }

        /// <summary>
        /// Receive CSV line and convert to Commision object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <returns>Commision object</returns>
        public static Commission FromCsv(string csvLine)
        {
            //Get columns of CSV line
            string[] values = csvLine.Split(',');

            //Convert line to object
            Commission commission = new Commission(values[0], values[1], Convert.ToDecimal(values[2], new System.Globalization.CultureInfo("en-US")));
            return commission;
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

                //If the line doesn't have 3 columns is invalid
                if (values.Length != 3)
                {
                    return false;
                }
                else
                {
                    //If the third column is decimal type, is valid
                    decimal.Parse(values[2]);
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

using System;

namespace OrderPrice.Entities
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Value-Added Tax (VAT)
        /// </summary>
        public decimal Vat => 0.23m;

        /// <summary>
        /// Product total amount including VAT
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Create Product object
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="stock">Product quantity</param>
        /// <param name="price">Product price</param>
        public Product(string id, int stock, decimal price)
        {
            Id = id;
            Quantity = stock;
            Price = price;

            //Check if quantity is greater zero
            if (stock > 0)
            {
                //Check if price is greater zero
                if (price > 0)
                {
                    //Get product value
                    decimal productTotal = Quantity * Price;

                    //Get VAT
                    decimal vatValue = productTotal * Vat;

                    //Sum product value and VAT
                    TotalAmount = productTotal + vatValue;
                }
                else
                {
                    TotalAmount = 0;
                }
            }
            else
            {
                //Set -1 if product is out of stock
                TotalAmount = -1m;
            }
        }

        /// <summary>
        /// Receive CSV line and convert to Product object
        /// </summary>
        /// <param name="csvLine">CSV line</param>
        /// <returns>Product object</returns>
        public static Product FromCsv(string csvLine)
        {
            //Get columns of CSV line
            string[] values = csvLine.Split(',');

            //Convert line to object
            Product product = new Product(values[0], Convert.ToInt32(values[1]), Convert.ToDecimal(values[2], new System.Globalization.CultureInfo("en-US")));

            return product;
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

                    //If the third column is decimal type, the line is valid
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

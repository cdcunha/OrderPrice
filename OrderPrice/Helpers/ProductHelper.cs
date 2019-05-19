using OrderPrice.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderByCity.Helpers
{
    /// <summary>
    /// Product helper class
    /// </summary>
    public static class ProductHelper
    {
        /// <summary>
        /// Get total orders
        /// </summary>
        /// <param name="products">Product list</param>
        public static decimal GetOrdersTotal(List<Product> products)
        {
            //Check if there is some product out of stock
            if (products.Where(e => e.TotalAmount == -1).Count() > 0)
            {
                throw new System.Exception("Code 1 - There is a product out of stock");
            }

            //Sum the total amount of product list and return it
            return products.Sum(e => e.TotalAmount);
        }
    }
}

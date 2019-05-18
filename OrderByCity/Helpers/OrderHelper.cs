using OrderPrice.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderPrice.Helpers
{
    public static class OrderHelper
    {
        /// <summary>
        /// Get Order list from CSV file
        /// </summary>
        /// <param name="fullFileName">CSV file full name</param>
        /// <param name="zipCodes">ZipCode list</param>
        /// <returns>Order list</returns>
        public static List<Order> GetOrders(string fullFileName, List<ZipCode> zipCodes)
        {
            var orders = new List<Order>();

            if (!string.IsNullOrWhiteSpace(fullFileName))
            {
                orders = File.ReadAllLines(fullFileName)
                        .Select(e => Order.FromCsv(e, zipCodes))
                        .ToList();
            }
            return orders;
        }

        /// <summary>
        /// Group order list by city and write lines in console
        /// </summary>
        /// <param name="orders">Order list</param>
        public static void GroupByCityAndWriteLineInConsole(List<Order> orders)
        {
            orders.GroupBy(g => g.City).ToList().ForEach(grp =>
            {
                Console.WriteLine($"{grp.Key},{grp.Count()}");
            });
        }
    }
}

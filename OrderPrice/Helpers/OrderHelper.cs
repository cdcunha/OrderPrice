using OrderPrice.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderPrice.Helpers
{
    public static class OrderHelper
    {
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

        public static void GroupByCityAndWriteLine(List<Order> orders)
        {
            orders.GroupBy(g => g.City).ToList().ForEach(grp =>
            {
                Console.WriteLine($"{grp.Key},{grp.Count()}");
            });
        }
    }
}

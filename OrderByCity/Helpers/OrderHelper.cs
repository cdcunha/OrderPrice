using OrderByCity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderByCity.Helpers
{
    public static class OrderHelper
    {   
        /// <summary>
        /// Get order list by city
        /// </summary>
        /// <param name="orders">Order list</param>
        /// <returns>List of quantity orders by City</returns>
        public static List<string> GetOrdersByCity(List<Order> orders)
        {
            List<string> ordersByCity = new List<string>();

            //Group orders by City 
            orders.GroupBy(g => g.City).ToList().ForEach(grp =>
            {
                //Add City and quantity orders to list
                ordersByCity.Add($"{grp.Key},{grp.Count()}");
            });

            //return list of quantity orders by City
            return ordersByCity;
        }
    }
}

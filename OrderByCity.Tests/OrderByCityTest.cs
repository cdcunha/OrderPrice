using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderByCity.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace OrderByCity.Tests
{
    [TestClass]
    public class OrderByCityTest
    {
        [TestMethod]
        public void TestGetOrdersByCity()
        {
            string[] zipCodesContent = new string[]
            {
                "num_cod_postal,ext_cod_postal,desig_postal",
                "1800,086,LISBOA",
                "1800,057,LISBOA",
                "1800,401,LISBOA",
                "4000,164,PORTO",
                "4000,326,PORTO"
            };

            string[] ordersContent = new string[]
            {
                "O1,1800,086",
                "O2,1800,057",
                "O3,1800,401",
                "O4,4000,164",
                "O5,4000,326"
            };

            var fileHelper = new FileHelper(zipCodesContent, ordersContent);
            var zipCodes = fileHelper.GetZipCodes();
            var orders = fileHelper.GetOrders(zipCodes);

            List<string> result = new List<string>{ "LISBOA,3", "PORTO,2" };

            Assert.IsTrue(result.SequenceEqual(OrderHelper.GetOrdersByCity(orders).ToArray()));
        }
    }
}

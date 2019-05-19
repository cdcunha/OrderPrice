using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderByCity.Helpers;
using OrderPrice.Helpers;

namespace OrderByCity.Test
{
    [TestClass]
    public class OrderPriceTest
    {
        [TestMethod]
        public void TestGetOrdersTotal()
        {
            string[] orders = new string[] 
            {
                "P4,6,250.00",
                "P10,5,175.00",
                "P12,1,1000.00"
            };
            var fileHelper = new FileHelper(orders);
            var products = fileHelper.GetProducts();

            Assert.AreEqual(4151.25.ToString("n2"), ProductHelper.GetOrdersTotal(products).ToString("n2"));
        }

        [TestMethod]
        public void TestGetOrdersTotalOutOfStock()
        {
            string[] orders = new string[]
            {
                "P4,6,250.00",
                "P10,5,175.00",
                "P12,0,1000.00"
            };
            var fileHelper = new FileHelper(orders);
            var products = fileHelper.GetProducts();

            try
            {
                ProductHelper.GetOrdersTotal(products).ToString("n2");
            }
            catch(System.Exception e)
            {
                Assert.AreEqual("Code 1 - There is a product out of stock", e.Message);
            }
        }
    }
}

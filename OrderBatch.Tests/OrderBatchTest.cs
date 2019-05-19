using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderBatch.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace OrderBatch.Tests
{
    [TestClass]
    public class OrderBatchTest
    {
        [TestMethod]
        public void TestGetCommissionsByBoutique()
        {
            string[] orders = new string[]
            {
                "B10,O1000,100.00",
                "B11,O1001,100.00",
                "B10,O1002,200.00",
                "B10,O1003,300.00"
            };
            var fileHelper = new FileHelper(orders);
            var commissions = fileHelper.GetCommissions();

            List<string> result = new List<string> { "B10,30", "B11,10" };
            Assert.IsTrue(result.SequenceEqual(CommissionHelper.GetCommissionsByBoutique(commissions).ToArray()));
        }
    }
}

using OrderByCity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderByCity.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Zip codes content file
        /// </summary>
        public string[] ZipCodesFile { get; private set; }

        /// <summary>
        /// Orders content file
        /// </summary>
        public string[] OrdersFile { get; private set; }

        /// <summary>
        /// Use only to Unity Tests
        /// </summary>
        /// <param name="orders"></param>
        public FileHelper(string[] zipCodes, string[] orders)
        {
            ZipCodesFile = zipCodes;
            OrdersFile = orders;
            
        }

        /// <summary>
        /// FileHelper Constructor
        /// </summary>
        /// <param name="zipCodesFileName">Zip Codes full file name</param>
        /// <param name="ordersFileName">Orders full file name</param>
        public FileHelper(string zipCodesFileName, string ordersFileName)
        {
            //Check if file exists
            bool hasZipCodesFile = File.Exists(zipCodesFileName);

            //Check if file exists
            bool hasOrdersFile = File.Exists(ordersFileName);

            if (hasZipCodesFile && hasOrdersFile)
            {
                //Get file content
                ZipCodesFile = File.ReadAllLines(zipCodesFileName);

                //Get file content
                OrdersFile = File.ReadAllLines(ordersFileName);

                //Check if content is empty
                if ((ZipCodesFile.Length == 0 || ZipCodesFile.Length == 1) && OrdersFile.Length == 0)
                    throw new Exception($"File are empties: '{zipCodesFileName}' and '{ordersFileName}'");

                //Check if content is empty
                if (ZipCodesFile.Length == 0 || ZipCodesFile.Length == 1)
                    throw new Exception($"Zip Codes file is empty: '{zipCodesFileName}'");

                //Check if content is empty
                if (OrdersFile.Length == 0)
                    throw new Exception($"Orders file is empty: '{ordersFileName}'");

                //Check if content of file is valid
                bool isValidOrderFile = IsValidOrderFile();
                bool isValidZipCodeFile = IsValidZipCodeFile();

                if (!isValidOrderFile && !isValidOrderFile)
                    throw new Exception($"File are not valids: '{zipCodesFileName}' and '{ordersFileName}'");

                if (!isValidZipCodeFile)
                    throw new Exception($"Zip Codes file is not valid: '{zipCodesFileName}'");

                if (!isValidOrderFile)
                    throw new Exception($"Orders file is not valid: '{ordersFileName}'");
            }
            else
            {
                if (!hasZipCodesFile && !hasOrdersFile)
                    throw new FileNotFoundException($"Files not exists: '{zipCodesFileName}' and '{ordersFileName}'");

                if (!hasZipCodesFile)
                    throw new FileNotFoundException($"File not exists: '{zipCodesFileName}'");

                if (!hasOrdersFile)
                    throw new FileNotFoundException($"File not exists: '{ordersFileName}'");
            }
        }
        /// <summary>
        /// Get Order list from CSV file
        /// </summary>
        /// <param name="zipCodes">ZipCode list</param>
        /// <returns>Order list</returns>
        public List<Order> GetOrders(List<ZipCode> zipCodes)
        {
            var orders = new List<Order>();
            orders = OrdersFile.Select(e => Order.FromCsv(e, zipCodes)).ToList();
            return orders;
        }

        /// <summary>
        /// Get Zip Code list from CSV file
        /// </summary>
        /// <returns>Zip Code list</returns>
        public List<ZipCode> GetZipCodes()
        {
            var zipCodes = new List<ZipCode>();
            zipCodes = ZipCodesFile.Skip(1).Select(e => ZipCode.FromCsv(e)).ToList();
            return zipCodes;
        }

        /// <summary>
        /// Check if Order file is valid
        /// </summary>
        /// <returns></returns>
        private bool IsValidOrderFile()
        {
            var validLines = OrdersFile.Take(1).Select(e => Order.IsCsvValid(e)).ToList();
            return validLines.Where(e => !e).Count() == 0;

        }

        /// <summary>
        /// Check if Zip Code file is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValidZipCodeFile()
        {   
            var validLines = ZipCodesFile.Skip(1).Take(1).Select(e => ZipCode.IsCsvValid(e)).ToList();
            return validLines.Where(e => !e).Count() == 0;
        }
    }
}

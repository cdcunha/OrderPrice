using OrderPrice.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderPrice.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// File helper class
        /// </summary>
        public string[] OrdersFile { get; private set; }

        /// <summary>
        /// Use only to Unity Tests
        /// </summary>
        /// <param name="orders"></param>
        public FileHelper(string[] orders)
        {
            OrdersFile = orders;
        }

        /// <summary>
        /// Creates FileHelper object 
        /// </summary>
        /// <param name="fileName">File name</param>
        public FileHelper(string fileName)
        {
            //Check if file exists
            if (File.Exists(fileName))
            {
                //Get file content
                OrdersFile = File.ReadAllLines(fileName);

                //Check if content is empty
                if (OrdersFile.Length == 0)
                    throw new Exception($"Orders file is empty: '{fileName}'");

                //Check if content of file is valid
                if (!IsValidOrderFile())
                    throw new Exception($"Orders file is not valid: '{fileName}'");
            }
            else
            {
                throw new FileNotFoundException($"File not exists: '{fileName}'");
            }

        }
        /// <summary>
        /// Read CSV file and convert to Product list 
        /// </summary>
        /// <returns>Product list</returns>
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            products = OrdersFile.Select(e => Product.FromCsv(e)).ToList();
            return products;
        }

        /// <summary>
        /// Check if Order file is valid
        /// </summary>
        /// <returns></returns>
        private bool IsValidOrderFile()
        {
            var validLines = OrdersFile.Take(1).Select(e => Product.IsCsvValid(e)).ToList();
            return validLines.Where(e => !e).Count() == 0;

        }
    }
}

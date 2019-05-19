using OrderBatch.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderBatch.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Orders content file
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
        /// <param name="fileName"></param>
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
        /// Read CSV file and convert to Commission list 
        /// </summary>
        /// <returns>Commission list</returns>
        public List<Commission> GetCommissions()
        {
            var commissions = new List<Commission>();

            //Convert line by line to list of commisions
            commissions = OrdersFile.Select(e => Commission.FromCsv(e)).ToList();

            return commissions;
        }

        /// <summary>
        /// Check if Commission file is valid
        /// </summary>
        /// <returns></returns>
        private bool IsValidOrderFile()
        {
            //Take only the first line if is valid
            var validLines = OrdersFile.Take(1).Select(e => Commission.IsCsvValid(e)).ToList();
            return validLines.Where(e => !e).Count() == 0;

        }
    }
}

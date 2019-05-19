using OrderByCity.Helpers;
using System;

namespace OrderByCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            //Check if arguments was provided
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]))
            {   
                Console.WriteLine("You must run with the following program arguments:");
                Console.WriteLine("1) '<Path_to_zip_codes_file>': path to the file that contains the zip codes");
                Console.WriteLine("2) '<Path_to_orders_file>': path to the file that contains the orders");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("1) To run from source code: 'dotnet run codigos_postais.csv orders.csv'");
                Console.WriteLine("2) To run from dll........: 'dotnet OrderByCity.dll codigos_postais.csv orders.csv'");
            }
            else
            {
                try
                {
                    //Check arguments and get files content
                    var fileHelper = new FileHelper(args[0], args[1]);

                    //Get file content and convert to list of zip codes
                    var zipCodes = fileHelper.GetZipCodes();

                    //Get file content and convert to list of orders
                    var orders = fileHelper.GetOrders(zipCodes);

                    //Write to console the orders total grouped by city
                    OrderHelper.GetOrdersByCity(orders).ForEach(e => Console.WriteLine(e));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Process aborted");
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}

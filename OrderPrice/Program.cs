using OrderByCity.Helpers;
using OrderPrice.Helpers;
using System;

namespace OrderByCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            //Check if argument was provided
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("You must run with the following program arguments:");
                Console.WriteLine("1) '<<Path_to_orders_file>>': path to the file to be processed");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("1) To run from source code: 'dotnet run orders.csv'");
                Console.WriteLine("2) To run from dll........: 'dotnet OrderPrice.dll orders.csv'");
            }
            else
            {
                try
                {
                    //Check argument and get file content
                    var fileHelper = new FileHelper(args[0]);

                    //Get file content and convert to list of products
                    var products = fileHelper.GetProducts();

                    //Write to console the orders total
                    Console.WriteLine($"Total: {ProductHelper.GetOrdersTotal(products).ToString("n2")}");
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

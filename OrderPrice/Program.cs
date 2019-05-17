using OrderPrice.Helpers;
using System;
using System.Linq;

namespace OrderPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]))
            {
                Console.WriteLine("You must run with the following program arguments:");
                Console.WriteLine("OrderPrice.dll <Path_to_zip_codes_file> <Path_to_orders_file>");
                Console.WriteLine("1) '<Path_to_zip_codes_file>': path to the file that contains the zip codes");
                Console.WriteLine("2) '<Path_to_orders_file>': path to the file that contains the orders");
                Console.WriteLine();
                Console.WriteLine("Example: 'dotnet run OrderPrice.dll codigos_postais.csv orders.csv'");
            }
            else
            {
                var zipCodes = ZipCodeHelper.GetZipCodes(args[0]);

                var orders = OrderHelper.GetOrders(args[1], zipCodes);

                OrderHelper.GroupByCityAndWriteLine(orders);
            }
        }
    }
}

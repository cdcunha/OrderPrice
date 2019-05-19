using OrderBatch.Helpers;
using System;

namespace OrderBatch
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
                Console.WriteLine("1) '<Path_to_orders_file>': path to the file to be processed");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("1) To run from source code: 'dotnet run orders.csv'");
                Console.WriteLine("2) To run from dll........: 'dotnet OrderBatch.dll orders.csv'");
            }
            else
            {
                try
                {
                    //Check argument and get file content
                    var fileHelper = new FileHelper(args[0]);

                    //Get file content and convert to list of commissions
                    var commissions = fileHelper.GetCommissions();

                    //Write to console the commission total grouped by boutique 
                    CommissionHelper.GetCommissionsByBoutique(commissions).ForEach(e => Console.WriteLine(e));
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

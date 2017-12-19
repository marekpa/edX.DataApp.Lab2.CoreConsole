using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Lab2.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ContosoContext())
            {
                Console.WriteLine("Connection Successful");
                Console.WriteLine(Environment.NewLine);
                CultureInfo.CurrentCulture = new CultureInfo("en-US");

                Console.WriteLine($"{"Product",10}\t{"Price",10}\t{"Cost",10}\t{"Profit",10}");
                Console.WriteLine("------------------------------------------------------------");
                var products = context.Products;
                //var products = context.Products.Where(p => (p.ListPrice - p.StandardCost) > 1000).OrderBy(p => p.ProductNumber);
                //var products = context.Products.Where(p => p.ProductNumber.Equals("FR-M21B-40")).OrderBy(p => p.ProductNumber);
                foreach (var item in products)
                {
                    Console.WriteLine($"{item.ProductNumber,10}\t{item.ListPrice,10:C}\t{item.StandardCost,10:C}\t{(item.ListPrice - item.StandardCost),10:C}", new CultureInfo("us-US"));
                }
                Console.WriteLine("------------------------------------------------------------");
            }
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}

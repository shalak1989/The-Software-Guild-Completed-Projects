using EFCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Northwind();

            foreach (var c in ctx.Customers)
            {
                Console.WriteLine(c.CompanyName);
            }

            var jasons = ctx.Customers.First(x => x.CustomerID == "JGBIS");
            jasons.Country = "Mexico";
            ctx.SaveChanges();

            Console.ReadKey();
        }
    }
}

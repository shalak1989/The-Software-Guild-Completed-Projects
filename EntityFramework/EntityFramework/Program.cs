using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkModelFirst;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities dbContext = new NorthwindEntities();

            var simonsOrders = dbContext.Customers.FirstOrDefault(x => x.CompanyName == "Simons bistro").Orders;

            //foreach (var c in simonsOrders)
            //{
            //    Console.WriteLine(c.OrderDate);
            //}

            var newCustomer = new Customer()
            {   
                CustomerID = "JGBIST",
                CompanyName = "Jasons bistro",
                City = "Louisville",
                Country = "USA",
                ContactName = "Jason",
                PostalCode = "40235"
            };
            try
            {
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            Console.ReadLine();
            
        }
    }
}

using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            //PrintOutOfStock();
            AllNumberC6();


            Console.ReadLine();
        }
        //#1
        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock == 0);

            var queryResult = from p in products
                              where p.UnitsInStock == 0
                              select p;

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        //#2
        private static void CostMoreThan3()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitPrice > 3 && p.UnitsInStock > 0);

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName);
            }
        }
        //#3

        private static void WashingtonCustomers()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(c => c.Region == "WA");

            foreach (var c in results)
            {
                Console.WriteLine(c.CompanyName);

                foreach (var O in c.Orders)
                {
                    Console.WriteLine("  " + O.OrderID);
                }
            }

        }

        //4
        private static void ProductSequence()
        {
            var products = DataLoader.LoadProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        private class NewType
        {
            public string ProductName { get; set; }
            public decimal NewPrice { get; set; }
        }

        //5
        private static void ProductsPricePlus25()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Select(p => new { p.ProductName, NewPrice = p.UnitPrice * 1.25M});

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName + p.NewPrice);
            }
        }
        //6
        private static void upperCaseNames()
        {
            var products = DataLoader.LoadProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName.ToUpper());
            }
        }
        //7
        private static void evenNumbersInStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock % 2 == 0 && p.UnitsInStock != 0);


            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName + " " + p.UnitsInStock + " Units");
            }
        }
        //8
        static void unitPriceRenamed()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName + " " + p.Category + " " + p.Price);
            }
        }
        //9
        static void numberPairs()
        {
            var numbersB = DataLoader.NumbersB;

            var numbersC = DataLoader.NumbersC;

            var results = from b in numbersB
                          from c in numbersC
                          select new { b, c };

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
        //10
        static void customerOrderTotal()
        {
            var customers = DataLoader.LoadCustomers();

            var result = customers.SelectMany(c => c.Orders, (c, o) => new { c.CustomerID, o.OrderID,
                o.Total }).Where(o => o.Total < 500);

            foreach (var c in result)
            {
                Console.WriteLine(c.CustomerID + " " +  c.OrderID + " "  + c.Total);
            }
        }
        //11
        static void queryNumbersA()
        {
            var numbersA = DataLoader.NumbersA;

            var result = numbersA.Select(n => n);
                         
            foreach (var n in result.Take(3))
            {
                Console.WriteLine(n.ToString());
            }
        }
        //12
        static void firstThreeWashington()
        {
            var orders = DataLoader.LoadCustomers();

            var result = orders.Where(o => o.Region == "WA");

            foreach (var c in result)
            {
                Console.WriteLine(c.CustomerID);
                foreach (var o in c.Orders.Take(3))
                {
                    Console.WriteLine(o.OrderID);
                }
            }
            

        }
        //13
        static void SkipThreeNumbersA()
        {
            var numbersA = DataLoader.NumbersA;

            var result = numbersA.Select(n => n);

            foreach (var n in result.Skip(3))
            {
                Console.WriteLine(n.ToString());
            }
        }
        //14
        static void SkipTwoOrders()
        {
            var customers = DataLoader.LoadCustomers();

            var result = customers.Where(c => c.Region == "WA");        

            foreach (var c in result)
            {
                Console.WriteLine(c.CustomerID);
                foreach (var o in c.Orders.Skip(2))
                {
                    Console.WriteLine("  " + o.OrderID);
                }
            }

        }
        //15
        static void AllNumberC6()
        {
            var numberC = DataLoader.NumbersC;

            var result = numberC.TakeWhile(c => c <= 6);

            foreach (var c in result)
            {
                Console.WriteLine(c);
            }
        }

    }   
}

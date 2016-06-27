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
            CategoryAndProductCount();


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

            var results = products.Select(p => new { p.ProductName, NewPrice = p.UnitPrice * 1.25M });

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

            var result = customers.SelectMany(c => c.Orders, (c, o) => new
            {
                c.CustomerID,
                o.OrderID,
                o.Total
            }).Where(o => o.Total < 500);

            foreach (var c in result)
            {
                Console.WriteLine(c.CustomerID + " " + c.OrderID + " " + c.Total);
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
        //16
        static void LessThanArrayNumberC()
        {
            var numberC = DataLoader.NumbersC;

            var result = numberC.TakeWhile((c, i) => c > i);

            foreach (var c in result)
            {
                Console.WriteLine(c);
            }
        }
        
        static void NumbersCBy3()//17. Return elements from NumbersC starting from the first element divisible by 3.
        {
            var numberC = DataLoader.NumbersC;

            var result = numberC.Where(c => c % 3 == 0);

            foreach (var c in result)
            {
                Console.WriteLine(c);
            }

        }
        
        static void ProductsAlphabetically()//18. Order products alphabetically by name.
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderBy(p => p.ProductName);

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName);
            }
        }
        
        static void UnitsInStockDescending()//19. Order products by UnitsInStock descending.
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderByDescending(p => p.ProductName);

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName);
            }
        }
        
        static void LowToHighCategory()//20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var p in results)
            {
                Console.WriteLine(p.Category + " " + p.UnitPrice);
            }
        }
        
        static void ReverseNumbersC()//21. Reverse NumbersC.
        {
            var numbersC = DataLoader.NumbersC;

            var results = numbersC.Reverse();

            foreach (var n in results)
            {
                Console.WriteLine(n);
            }
        }
      
        static void NumbersCGroupedByRemainder()//22. Display the elements of NumbersC grouped by their remainder when divided by 5.
        {
            var numberC = DataLoader.NumbersC;

            var results = numberC.GroupBy(p => p % 5);

            foreach (var n in results)
            {
                Console.WriteLine(n.Key);
                foreach (var item in n)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }
        
        static void DisplayByCategory()//23. Display products by Category.
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderBy(p => p.Category);

            foreach (var p in results)
            {
                Console.WriteLine(p.ProductName + "\t" + p.Category);
            }
        }
        
        static void GroupCustomerOrderYearMonth()//24. Group customer orders by year, then by month.
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Select(p => new { customer = p, OrdersByYear = p.Orders.GroupBy(x => x.OrderDate.Year)});

            foreach (var p in results)
            {
                Console.WriteLine("Customer Name: " + p.customer.CompanyName);
                foreach (var ordersGroupedByYear in p.OrdersByYear)
                {
                    Console.WriteLine("\t Year: {0}", ordersGroupedByYear.Key);
                    foreach (var ordersGroupedByMonth in ordersGroupedByYear.GroupBy(x => x.OrderDate.Month))//Not a date for the group, there is a date on the individual members of the group...
                    {
                        Console.WriteLine("\t\t Month: {0}", ordersGroupedByMonth.Key);
                        foreach (var order in ordersGroupedByMonth.OrderBy(ord => ord.OrderDate.Month))
                        
                            Console.WriteLine("\t\t\t OrderID: {0}", order.OrderID);                 
                        }
                    }
                     
                }
            }              
        
        static void UniqueProductCategoryNames()//25. Create a list of unique product category names.
        {
            var products = DataLoader.LoadProducts();

            var results = products.Select(p => p.Category).Distinct();

            foreach (var p in results)
            {
                Console.WriteLine(p);
            }
        }
        
        static void UniqueValueAB()//26. Get a list of unique values from NumbersA and NumbersB.
        {
            var numbersA = DataLoader.NumbersA;
            var numbersB = DataLoader.NumbersB;

            var result = numbersA.ToList();
            var result2 = numbersB.ToList();

            result.AddRange(numbersB);
            var finalResult = result.Distinct();

            foreach (var r in finalResult)
            {
                Console.WriteLine(r.ToString());
            }

        }
        
        static void SharedBAndA()//27. Get a list of the shared values from NumbersA and NumbersB.
        {
            var numbersA = DataLoader.NumbersA;

            var numbersB = DataLoader.NumbersB;

            var result = from a in numbersA
                         from b in numbersB
                         where a == b
                         select a;

            var result2 = numbersA.Where(a => numbersB.Contains(a));

           // var resultMethod

            foreach (var a in result)
            {
                Console.WriteLine(a.ToString());
            }

        }

        static void NumbersANotInNumbersB()//28. Get a list of values in NumbersA that are not also in NumbersB.
        {
            var numbersA = DataLoader.NumbersA;

            var numbersB = DataLoader.NumbersB;

            var result2 = numbersA.Where(a => !numbersB.Contains(a));

            foreach (var a in result2)
            {
                Console.WriteLine(a.ToString());
            }
        }
                  
        static void FirstProductId12()//29. Select only the first product with ProductID = 12 (not a list).
        {
            var products = DataLoader.LoadProducts();

            var result = from a in products
                         where a.ProductID == 12
                         select a.ProductName;

            var result2 = products.First(a => a.ProductID == 12);

            
            Console.WriteLine(result2.ProductName);
            
                         
        }
        
        static void ProductId789()//30. Write code to check if ProductID 789 exists.
        {
            var products = DataLoader.LoadProducts();

            var results = products.Exists(p => p.ProductID == 789);
            
            Console.WriteLine(results);
            
        }
        
        static void CategoryOutOfStock()//31. Get a list of categories that have at least one product out of stock.
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock == 0);

            foreach (var p in results)
            {
                Console.WriteLine(p.Category);
            }
        }
        
        static void NumberBLessThan9()//32. Determine if NumbersB contains only numbers less than 9.
        {
            var numbersB = DataLoader.NumbersB;

            if (numbersB.Any(b => b >= 9))
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
        
        static void GroupedListCategoryInStock()//33. Get a grouped a list of products only for categories that have all of their products in stock.
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category);
            //As long as first extension method returns an IEnumerable you can chain

            foreach (var p in results)
            {
                //could also not do a writeline and return item.Category + item.UnitsInStock below
                foreach (var item in p)
                {
                    Console.WriteLine(item.Category + "\t" + item.ProductName);
                    
                }
            }
        }
        
        static void OddsNumberA()//34. Count the number of odds in NumbersA.
        {
            var numbersA = DataLoader.NumbersA;

            var results = numbersA.Where(a => a % 2 != 0);

            foreach (var a in results)
            {
                Console.WriteLine(a.ToString());
            }
        }
        
        static void CustomerIdAndOrderCount()//35. Display a list of CustomerIDs and only the count of their orders.
        {
            var customers = DataLoader.LoadCustomers();

            var result = customers.Select(c => c.CustomerID);
                //customers.Select(c => new { c.CustomerID, Count= c.Orders.Count() })


            foreach (var c in customers)
            {
                Console.WriteLine(c.CustomerID);
                Console.WriteLine(c.Orders.Count());
            }
        }

        static void CategoryAndProductCount()//36. Display a list of categories and the count of their products.
        {
            var products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category).Select(p => new { pCategory = p.Key, pCount = p.Count() });

            foreach (var p in results)
            {
                Console.WriteLine(p);
            }
        }

        static void TotalUnitsInStockEachCategory()//37. Display the total units in stock for each category.
        {
            var products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category);
            
            foreach (var p in results)
            {
                Console.WriteLine(p.Key + p.Sum(b => b.UnitsInStock));
            }
        }

        static void LowestPricedProductInEachCategory()//38. Display the lowest priced product in each category.
        {
            var products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category);

            foreach (var p in results)
            {
                Console.WriteLine(p.Key + p.Min(c => c.UnitPrice));
            }
        }
        
        static void HighestPricedProductInEachCategory()//39. Display the highest priced product in each category.
        {
            var products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category);

            foreach (var p in results)
            {
                Console.WriteLine(p.Key + p.Max(c => c.UnitPrice));
            }

        }
        
        static void AveragePriceProductEachCategory() //40. Show the average price of product for each category.
        {
            var products = DataLoader.LoadProducts();

            var results = products.GroupBy(p => p.Category);

            foreach (var p in results)
            {
                Console.WriteLine(p.Key + p.Average(c => c.UnitPrice));
            }
            
        }
        
        
        


    }
}
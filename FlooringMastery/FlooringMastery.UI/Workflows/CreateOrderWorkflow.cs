using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Workflows
{
    public class CreateOrderWorkflow
    {
        ProductRepository products = new ProductRepository();
        OrderManager mgr = new OrderManager();
        bool isValidInput;
        Order newOrder = new Order();

        public void Execute()
        {
            
            Console.WriteLine("Enter the Customer Name for this order: ");
            newOrder.CustomerName = Console.ReadLine();

            do
            {
                isValidInput = false;
                Console.WriteLine("Choose the state for this order (use state abbreviations to choose): ");
                Console.WriteLine(" 1. Ohio (OH)\n 2. Pennsylvania (PA)\n 3. Michigan(MI)\n 4. Indiana (IN)\n");
                var orderState = Console.ReadLine();
               

                if (orderState.ToUpper() == "OH" || orderState.ToUpper() == "PA" || orderState.ToUpper() == "MI" || newOrder.State.ToUpper() == "IN")
                {
                    newOrder.State = orderState;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please choose from the states listed");
                }
                

            } while (isValidInput == false);

            do
            {
                var productlist = products.GetAllProducts();
                isValidInput = false;

                Console.WriteLine("Choose your Product Type ( use the product name): \n");

                Console.WriteLine("1. Product Type: " + productlist.ElementAt(0).ProductType + "\n" +
                    " CostPerSquareFoot: $" + productlist.ElementAt(0).CostPerSquareFoot + "\n" +
                    " LaborCostPerSquareFoot: $" + productlist.ElementAt(0).LaborCostPerSquareFoot + "\n");

                Console.WriteLine("2. Product Type: " + productlist.ElementAt(1).ProductType + "\n" +
                  " CostPerSquareFoot: $" + productlist.ElementAt(1).CostPerSquareFoot + "\n" +
                  " LaborCostPerSquareFoot: $" + productlist.ElementAt(1).LaborCostPerSquareFoot + "\n");

                Console.WriteLine("3. Product Type: " + productlist.ElementAt(2).ProductType + "\n" +
                  " CostPerSquareFoot: $" + productlist.ElementAt(2).CostPerSquareFoot + "\n" +
                  " LaborCostPerSquareFoot: $" + productlist.ElementAt(2).LaborCostPerSquareFoot + "\n");

                Console.WriteLine("4. Product Type: " + productlist.ElementAt(3).ProductType + "\n" +
                  " CostPerSquareFoot: $" + productlist.ElementAt(3).CostPerSquareFoot + "\n" +
                  " LaborCostPerSquareFoot: $" + productlist.ElementAt(3).LaborCostPerSquareFoot + "\n");

                newOrder.ProductType = Console.ReadLine();

                if (newOrder.ProductType != "Carpet" && newOrder.ProductType != "Laminate" &&
            newOrder.ProductType != "Tile" && newOrder.ProductType != "Wood")
                {
                    Console.WriteLine("Invalid product type, please choose one of the product types listed.\n");
                }
                else
                {
                    isValidInput = true;
                }
            } while (isValidInput == false);

            do
            {
                isValidInput = false;
                Console.WriteLine("Enter in the area for your order: ");
                var input = Console.ReadLine();
                decimal area;

                if (decimal.TryParse(input, out area) == true)
                {
                    newOrder.Area = area;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! enter a number for the area");
                }

            } while (isValidInput == false);
            mgr.Create(newOrder);
        }
    }
}


//public int OrderNumber { get; set; } - GET THIS IN ACCOUNT MANAGER
//public string CustomerName { get; set; }
//public string State { get; set; }
//public decimal TaxRate { get; set; } - CALCULATE THIS IN ACCOUNT MANAGER
//public string ProductType { get; set; }
//public decimal Area { get; set; }
//public decimal CostPerSquareFoot { get; set; } - USE THIS IN ACCOUNT MANAGER
//public decimal MaterialCost { get; set; }- USE THIS IN ACCOUNT MANAGER
//public decimal LaborCost { get; set; } - USE THIS IN ACCOUNT MANAGER
//public decimal tax { get; set; } - USE THIS IN ACCOUNT MANAGER
//public decimal total { get; set; }- USE THIS IN ACCOUNT MANAGER
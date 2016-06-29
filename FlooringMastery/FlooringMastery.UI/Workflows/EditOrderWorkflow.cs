using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        OrderManager mgr = new OrderManager();
        ProductRepository products = new ProductRepository();
        bool isValidInput;
        string orderDateToEdit;
        int ordNum;
        Order currentOrder;
        public void Execute()
        {

            do
            {
                isValidInput = false;
                Console.WriteLine("Enter the date for the order you want to edit, format it in MMDDYYYY format.");
                Console.WriteLine("If the month is before October use MDDYYYY format: ");
                orderDateToEdit = Console.ReadLine();

                string fileExistChecker = string.Format(@"Datafiles\Orders_{0}.txt", orderDateToEdit);

                bool doesExist = File.Exists(fileExistChecker);

                if (doesExist == false)
                {
                    Console.WriteLine("That order date does not exist!");
                }
                else
                {
                    Console.Clear();
                    isValidInput = true;
                }
            } while (isValidInput == false);

            OrderRepository orders = new OrderRepository(orderDateToEdit);

            var ordersDisplay = orders.GetAllOrders();

            do
            {
                isValidInput = false;
                Console.WriteLine("Enter the order number of the order you want to edit: ");
                string orderItemToEdit = Console.ReadLine();
                int.TryParse(orderItemToEdit, out ordNum);

                if (int.TryParse(orderItemToEdit, out ordNum) == false)
                {
                    Console.WriteLine("Your entry was not a number");
                }

                if (int.TryParse(orderItemToEdit, out ordNum) == true)
                {
                    var orderNumberExists = ordersDisplay.Find(o => o.OrderNumber == ordNum);

                    if (orderNumberExists == null)
                    {
                        Console.WriteLine("That order number does not exist!");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }

            } while (isValidInput == false);
            currentOrder = ordersDisplay.First(x => x.OrderNumber == ordNum);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Order Number: {0}", currentOrder.OrderNumber);
            Console.WriteLine("Order Name: {0}", currentOrder.CustomerName);
            Console.WriteLine("3. State: {0}", currentOrder.State);
            Console.WriteLine("4. Tax Rate: {0}%", currentOrder.TaxRate);
            Console.WriteLine("5. Product Type: {0}", currentOrder.ProductType);
            Console.WriteLine("Area: {0}", currentOrder.Area);
            Console.WriteLine("CostPerSquareFoot: ${0}", currentOrder.CostPerSquareFoot);
            Console.WriteLine("Material Cost: ${0}", currentOrder.MaterialCost);
            Console.WriteLine("Labor Cost: ${0}", currentOrder.LaborCost);
            Console.WriteLine("Tax: ${0}", currentOrder.tax);
            Console.WriteLine("Total: ${0}", currentOrder.total);
            Console.WriteLine("-------------------------");

            Console.WriteLine("Are you sure you want to edit this order?\n" +
            "Press any key to edit the order or press Q to go back to the main Menu.");
            string userInput = Console.ReadLine();
            MainMenu returnToMenu = new MainMenu();

            if (userInput.ToUpper() == "Q")
            {
                returnToMenu.Execute();
            }
            ///// START THE EDITING

            
            OrderManager mgr = new OrderManager();
            ExecuteEdit();
            mgr.EditOrder(currentOrder, orderDateToEdit);
        }
          
        private void ExecuteEdit()
        {
            Console.WriteLine("Enter the Customer Name for this order: ");
            currentOrder.CustomerName = Console.ReadLine();

            do
            {
                isValidInput = false;
                Console.WriteLine("Choose the state for this order (use state abbreviations to choose): ");
                Console.WriteLine(" 1. Ohio (OH)\n 2. Pennsylvania (PA)\n 3. Michigan(MI)\n 4. Indiana (IN)\n");
                currentOrder.State = Console.ReadLine();

                if (currentOrder.State.ToUpper() == "OH" || currentOrder.State.ToUpper() == "PA" || currentOrder.State.ToUpper() == "MI" || currentOrder.State.ToUpper() == "IN")
                {
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

                currentOrder.ProductType = Console.ReadLine();

                if (currentOrder.ProductType != "Carpet" && currentOrder.ProductType != "Laminate" &&
            currentOrder.ProductType != "Tile" && currentOrder.ProductType != "Wood")
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
                    currentOrder.Area = area;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! enter a number for the area");
                }

            } while (isValidInput == false);
        }
            


   }
 }


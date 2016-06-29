using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.BLL;
using FlooringMastery.Data;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        bool isValidInput;
        string orderDate;

        public void Execute()
        {
            
            ValidOrderDate();

            OrderRepository repo = new OrderRepository(orderDate);

            var orderList = repo.GetAllOrders();

            for (int i = 0; i < orderList.Count; i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Order Number: {0}", orderList.ElementAt(i).OrderNumber);
                Console.WriteLine("Order Name: {0}", orderList.ElementAt(i).CustomerName);
                Console.WriteLine("State: {0}", orderList.ElementAt(i).State);
                Console.WriteLine("Tax Rate: {0}%", orderList.ElementAt(i).TaxRate);
                Console.WriteLine("Product Type: {0}", orderList.ElementAt(i).ProductType);
                Console.WriteLine("Area: {0}", orderList.ElementAt(i).Area);
                Console.WriteLine("CostPerSquareFoot: ${0}", orderList.ElementAt(i).CostPerSquareFoot);
                Console.WriteLine("Material Cost: ${0}", orderList.ElementAt(i).MaterialCost);
                Console.WriteLine("Labor Cost: ${0}", orderList.ElementAt(i).LaborCost);
                Console.WriteLine("Tax: ${0}", orderList.ElementAt(i).tax);
                Console.WriteLine("Total: ${0}", orderList.ElementAt(i).total);
                Console.WriteLine("-------------------------");
            }
            Console.ReadLine();
            
        }

        private void ValidOrderDate()
        {
            do
            {
                isValidInput = false;
                Console.WriteLine("Enter the date for the orders you wish to display.");
                Console.WriteLine("format the date in MMDDYYYY format, if the month is before October use MDDYYYY format: ");
                orderDate = Console.ReadLine();

                string fileExistChecker = string.Format(@"Datafiles\Orders_{0}.txt", orderDate);

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
        }
    }
}















    //do
    //        {
    //            edittingDone = "N";
    //            Console.WriteLine("-------------------------");
    //            Console.WriteLine("Order Number: " + ordersDisplay.ElementAt);
    //            Console.WriteLine("Customer Name: " + order.CustomerName);
    //            Console.WriteLine("Order Total: $" + order.total);
    //            Console.WriteLine("-------------------------");
    //        } while (edittingDone.ToUpper() == "N");

   








   
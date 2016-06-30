using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.Data;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager mgr = new OrderManager();
            bool isValidInput;
            string orderDateToDelete;
            int ordNum;

            do
            {
                isValidInput = false;
                Console.WriteLine("Enter a date for the order you want to remove, format it in MMDDYYYY format, if the month is before October use MDDYYYY format: ");
                orderDateToDelete = Console.ReadLine();

                string fileExistChecker = string.Format(@"Datafiles\Orders_{0}.txt", orderDateToDelete);

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

            OrderRepository orders = new OrderRepository();

            var ordersDisplay = orders.GetAllOrders(orderDateToDelete);

            foreach (var order in ordersDisplay)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Order Number: " + order.OrderNumber);
                Console.WriteLine("Customer Name: " + order.CustomerName);
                Console.WriteLine("Order Total: $" + order.total);
                Console.WriteLine("-------------------------");

            }

            do
            {
                isValidInput = false;
                Console.WriteLine("Enter the order number that you wish to delete from this date: ");
                string orderNumberToDelete = Console.ReadLine();
                int.TryParse(orderNumberToDelete, out ordNum);

                if (int.TryParse(orderNumberToDelete, out ordNum) == false)
                {
                    Console.WriteLine("Your entry was not a number");
                }

                if (int.TryParse(orderNumberToDelete, out ordNum) == true)
                {
                    var orderNumberExists = ordersDisplay.Find(o => o.OrderNumber == ordNum);

                    if( orderNumberExists == null)
                    {
                        Console.WriteLine("That order number does not exist!");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                } 

            } while (isValidInput == false);
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Order Number: " + ordersDisplay.ElementAt(ordNum - 1).OrderNumber);
            Console.WriteLine("Customer Name: " + ordersDisplay.ElementAt(ordNum - 1).CustomerName);
            Console.WriteLine("Order Total: " + ordersDisplay.ElementAt(ordNum - 1).total);
            Console.WriteLine("-------------------------\n");

            Console.WriteLine("Are you sure you want to delete this order?\n" +
                "Press any key to delete the order or press Q to go back to the main Menu.");
            string userInput = Console.ReadLine();
            MainMenu returnToMenu = new MainMenu();

            if (userInput.ToUpper() == "Q")
            {
                returnToMenu.Execute();
            }
            mgr.DeleteOrder(ordNum, orderDateToDelete);
        }
    }
}

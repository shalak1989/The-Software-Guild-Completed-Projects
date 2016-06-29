using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            bool isValidInput;
            do
            {
                isValidInput = false;
                Console.WriteLine("====================================================================\n");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("(Q) to quit \n");
                Console.WriteLine("====================================================================");
                
                Console.WriteLine("\n\nEnter Choice: ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                    break;
                if (input != "1" && input != "2" && input  != "3" && input != "4")

                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    ProcessChoice(input);
                    isValidInput = true;
                }
                

            } while (isValidInput == false);

        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var displayOrders = new DisplayOrdersWorkflow();
                    displayOrders.Execute();
                    break;
                case "2":
                    var addOrder = new CreateOrderWorkflow();
                    addOrder.Execute();
                    break;
                case "3":
                    var editOrder = new EditOrderWorkflow();
                    editOrder.Execute();
                    break;
                case "4":
                    var removeOrder = new RemoveOrderWorkflow();
                    removeOrder.Execute();
                    break;

            }
        }

    }
}

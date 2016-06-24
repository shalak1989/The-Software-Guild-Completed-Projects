using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SG CORP BANK");
                Console.WriteLine("============================");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Lookup Account");
                Console.WriteLine("\n(Q) to Quit");

                Console.WriteLine("\n\nEnter Choice: ");
                string input = Console.ReadLine();

                if (input.Substring(0, 1).ToUpper() == "Q")
                    break;

                ProcessChoice(input);

            } while (true);
            
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var createAccount = new CreateAccountWorkflow();
                    createAccount.Execute();
                    break;
                case "2":
                    var deleteAccount = new DeleteAccountWorkflow();
                    deleteAccount.Execute();
                    break;
                case "3":
                    var lookup = new LookupWorkflow();
                    lookup.Execute();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.BLL;

namespace SGBank.UI.Workflows
{
    class DeleteAccountWorkflow
    {
        public void Execute()
        {   //Need to get all accounts, get the input from the user, delete the account they input

            Account accountToDelete = new Account();

            string accNumberInput;
            int accNumber;
            bool isValidInput;
            do
            {
                Console.WriteLine("Enter the account number that you want to delete: ");
                accNumberInput = Console.ReadLine();

                isValidInput = int.TryParse(accNumberInput, out accNumber);
            } while (!isValidInput);

            var manager = new AccountManager();
            accountToDelete.AccountNumber = accNumber;
            var response = manager.Delete(accountToDelete);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Closed Account Number: {0}", response.Data.AccountNumber);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An error occurred.  {0}", response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}

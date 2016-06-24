using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{   
    
    public class CreateAccountWorkflow
    {
        public void Execute()
        {   //Need to get account number, get opening balance, and set the First/Last Name)

            Account newAccount = new Account(); 
            decimal amount = GetInitialDepositAmount();

            Console.WriteLine("Enter the first name for the new account: ");
            newAccount.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name for the new account: ");
            newAccount.LastName = Console.ReadLine();

            var manager = new AccountManager();

            var response = manager.Create(newAccount, amount);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Opened Account Number: {0} with an opening balance of {1}.", response.Data.AccountNumber, response.Data.Balance);
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

        private decimal GetInitialDepositAmount()
        {
            do
            {
                Console.Write("Enter an opening balance amount: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                Console.WriteLine("That was not a valid amount. Please try again.");
                Console.ReadKey();
            } while (true);
        }

    }
}

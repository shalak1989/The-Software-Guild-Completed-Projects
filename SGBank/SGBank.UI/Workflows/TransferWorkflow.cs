using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class TransferWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetTransferAmount();

            int receivingAcc = GetReceivingAccountNumber();
            
            var manager = new AccountManager();

            var receivingAccount = manager.GetAccount(receivingAcc);//could have passed in an int, after changing acccount manager transfer parameters

            var response = manager.Transfer(account, amount, receivingAccount.Data);
            
        
            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Transferred {0:c} from account {1} to account {2}.\n", 
                response.Data.DepositAmount, response.Data.AccountNumber, response.Data.ReceivingAccountNumber);
                Console.WriteLine("New balance of account {0} is {1:c}. \n", response.Data.AccountNumber, response.Data.NewBalance);
                Console.WriteLine("New balance of account {0} is {1:c}.", response.Data.ReceivingAccountNumber, response.Data.ReceivingAccountNewBalance);
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

        private decimal GetTransferAmount()
        {
            do
            {
                Console.Write("Enter the amount you want to transfer: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                Console.WriteLine("That was not a valid amount. Please try again.");
                Console.ReadKey();
            } while (true);
        }
        private int GetReceivingAccountNumber()
        {
            bool isValidAccount = false;
            int num;

            do
            {
                AccountManager validateAccount = new AccountManager();
                
                Console.WriteLine("Enter the account number that you wish to transfer to: ");
                var receivingAccountInput = Console.ReadLine();

                if (int.TryParse(receivingAccountInput, out num))
                {

                    var accountChecker = validateAccount.GetAccount(num);
                    if (accountChecker == null)
                    {
                        Console.WriteLine("Invalid account");
                    }
                }

                isValidAccount = true;

                return num;

            } while (isValidAccount == false);       


        }
    }
}


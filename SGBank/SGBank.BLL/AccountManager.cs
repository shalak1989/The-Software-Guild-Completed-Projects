using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountManager
    {
        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = new AccountRepository();
            var response = new Response<Account>();

            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = account;
                }
            }
            catch (Exception ex)
            {
                // log the exception
                response.Success = false;
                response.Message = "There was an error.  Please try again later.";
            }

            return response;
        }

        public object Create(int v, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Response<DepositReciept> Deposit(Account account, decimal amount)//do a delete and a transfer in a very similar way
        {
            
            var response = new Response<DepositReciept>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must deposit a positive value.";
                }
                else
                {
                    account.Balance += amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new DepositReciept();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<WithdrawReceipt> Withdraw(Account account, decimal amount)//do a delete and a transfer in a very similar way
        {

            var response = new Response<WithdrawReceipt>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must withdraw a positive value.";
                }
                else
                {
                    account.Balance = account.Balance - amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new WithdrawReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<TransferReceipt>Transfer(Account account, decimal amount, Account receivingAccount)//do a delete and a transfer in a very similar way
        {

            var response = new Response<TransferReceipt>();
            response.Data = new TransferReceipt();
            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must transfer a positive value.";
                }
                else
                {
                    account.Balance = account.Balance - amount; //Withdrawl
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;//end withdrawl

                    receivingAccount.Balance = receivingAccount.Balance + amount;//begin deposit into receiving account
                    repo.UpdateAccount(receivingAccount);
                    response.Success = true;//end deposit into receiving account

                    response.Data = new TransferReceipt();

                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;

                    response.Data.ReceivingAccountNumber = receivingAccount.AccountNumber;
                    response.Data.RecievingAccountDepositAmount = amount;
                    response.Data.ReceivingAccountNewBalance = receivingAccount.Balance;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<CreateAccountReceipt>Create(Account account, decimal amount)
        {
            var response = new Response<CreateAccountReceipt>();
            response.Data = new CreateAccountReceipt();
            var repo = new AccountRepository();

            var accountList = repo.GetAllAccounts();
            var accCount = accountList.Max(p => p.AccountNumber);
            account.AccountNumber = accCount + 1;

            repo.CreateAccount(account);

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must open the account with a positive value.";
                }
                else
                {
                    
                    account.Balance = amount; //Opening account balance
                    
                    response.Success = true;

                    response.Data.FirstName = account.FirstName;
                    response.Data.LastName = account.LastName;
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.Balance = amount;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<DeleteAccountReceipt> Delete(Account account)
        {
            var response = new Response<DeleteAccountReceipt>();
            response.Data = new DeleteAccountReceipt();
            var repo = new AccountRepository();

            var accountList = repo.GetAllAccounts();
  
            repo.DeleteAccount(account);

            try
            {
                if (!accountList.Any(p => p.AccountNumber == account.AccountNumber))
                {
                    response.Success = false;
                    response.Message = "That account does not exist!";
                }
                else
                {                   

                    response.Success = true;

                    response.Data.AccountNumber = account.AccountNumber;                   

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }









    }
}

            
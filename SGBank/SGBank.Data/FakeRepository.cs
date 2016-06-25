using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class FakeRepository : IAccountRepository
    {
        public void CreateAccount(Account accountToCreate)
        {
            _listOfAccounts.Add(accountToCreate);
        }

        public void DeleteAccount(Account accountToDelete)
        {
            _listOfAccounts.Remove(accountToDelete);
        }

        public List<Account> GetAllAccounts()
        {
            return _listOfAccounts;
        }

        public Account LoadAccount(int accountNumber)
        {
            return _listOfAccounts.ElementAt(accountNumber);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var accounts = GetAllAccounts();

            //var existingAccount = accounts.First(p => p.AccountNumber == accountToUpdate.AccountNumber).AccountNumber = 

            
        }

        //--------------------------------------------------------- Begin Fake Data
        private List<Account> _listOfAccounts = new List<Account>()
        {
            new Account {AccountNumber = 1, FirstName = "Trog", LastName = "Dor", Balance = 1000},
            new Account {AccountNumber = 2, FirstName = "Was", LastName = "A", Balance = 1000},
            new Account {AccountNumber = 3, FirstName = "Man", LastName = "He", Balance = 1000},
            new Account {AccountNumber = 4, FirstName = "Was", LastName = "A", Balance = 1000},
            new Account {AccountNumber = 5, FirstName = "Dragon", LastName = "Man", Balance = 1000},
        };

    }
}

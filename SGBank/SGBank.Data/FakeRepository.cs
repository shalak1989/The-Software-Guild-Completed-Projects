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
            return _listOfAccounts.First(p => p.AccountNumber == accountNumber);//was an elementAt
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var accounts = GetAllAccounts();

            foreach (var a in accounts.Where(p => p.AccountNumber == accountToUpdate.AccountNumber))
            {
                a.FirstName = accountToUpdate.FirstName;
                a.LastName = accountToUpdate.LastName;
                a.Balance = accountToUpdate.Balance;
            }

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

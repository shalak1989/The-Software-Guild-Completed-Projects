using System.Collections.Generic;
using SGBank.Models;

namespace SGBank.Data
{
    public interface IAccountRepository
    {
        void CreateAccount(Account accountToCreate);
        void DeleteAccount(Account accountToDelete);
        List<Account> GetAllAccounts();
        Account LoadAccount(int accountNumber);
        void UpdateAccount(Account accountToUpdate);
    }
}
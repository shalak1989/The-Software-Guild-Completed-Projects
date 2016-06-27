using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Data;
using SGBank.Models;
using Moq;

namespace SGBank.Tests
{
    [TestFixture]//write more tests
    public class AccountMangerTests
    {
        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountManager();

            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("Mary", response.Data.FirstName);
        }

        [Test]
        public void NotFoundAccountReturnsFail()
        {
            var manager = new AccountManager();

            var response = manager.GetAccount(9999);

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void CreateAccountAddsNewAccount()
        {
            var repo = new FakeRepository();
            var mgr = new AccountManager(repo);

            Account account = new Account();
            var response = mgr.Create(account, 50);

            Assert.AreEqual(account.AccountNumber, 6);//its literally saying is account.AccountNumber equal to six
        }

        [Test]
        public void DeleteAccountDeletesAccount()
        {
            var repo = new FakeRepository();
            var mgr = new AccountManager(repo);
          
           // var addToList = mgr.Create(account, 50);

            var accountslist = repo.GetAllAccounts();
            var response = mgr.Delete(accountslist.ElementAt(1));

            Assert.True(accountslist.Count == 4); //account list will have a count of 6 if the delete failed
        }

        [Test]
        public void GetAllAccounts()
        {
            var repo = new FakeRepository();
            var mgr = new AccountManager(repo);

            var accountlist = repo.GetAllAccounts();

            Assert.True(accountlist.Count == 5);
        }

        [Test]
        public void LoadSpecificAccount()
        {
            var repo = new FakeRepository();
            var mgr = new AccountManager(repo);

            var accountlist = repo.GetAllAccounts();

            var response = repo.LoadAccount(1);

            Assert.AreEqual(response.FirstName, "Was");
        }

        [Test]
        public void UpdateAccountWorks()
        {
            var repo = new FakeRepository();
            var mgr = new AccountManager(repo);

            Account account = new Account();
            var getAccount = mgr.GetAccount(1);

            getAccount.Data.Balance = 1200;

          /*  repo.UpdateAccount();

            var response = repo.UpdateAccount(account);*/


        }
        
    }
}

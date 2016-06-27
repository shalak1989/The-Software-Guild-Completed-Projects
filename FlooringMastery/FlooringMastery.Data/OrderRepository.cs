using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    public class OrderRepository
    {
        private const string FilePath = @"DataFiles\Bank.txt";

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();

                order.OrderNumber = int.Parse(columns[0]);
                order.CustomerName = columns[1];
                order.State = columns[2];
                order.TaxRate = decimal.Parse(columns[3]);
                order.ProductType = columns[4];
                order.Area = decimal.Parse(columns[5]);
                order.CostPerSquareFoot = decimal.Parse(columns[6]);
                order.MaterialCost = decimal.Parse(columns[7]);
                order.LaborCost = decimal.Parse(columns[8]);
                order.tax = decimal.Parse(columns[9]);
                order.total = decimal.Parse(columns[10]);

                orders.Add(order);
            }

            return orders;
        }

        //public Order DisplayOrder(int accountNumber)
        //{
        //    List<Account> accounts = GetAllAccounts();
        //    return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        //}

        //public void UpdateAccount(Account accountToUpdate)
        //{
        //    var accounts = GetAllAccounts();

        //    var existingAccount = accounts.First(a => a.AccountNumber == accountToUpdate.AccountNumber);
        //    existingAccount.FirstName = accountToUpdate.FirstName;
        //    existingAccount.LastName = accountToUpdate.LastName;
        //    existingAccount.Balance = accountToUpdate.Balance;

        //    OverwriteFile(accounts);
        //}
        ////add delete account method
        //private void OverwriteFile(List<Account> accounts)
        //{
        //    File.Delete(FilePath);

        //    using (var writer = File.CreateText(FilePath))
        //    {
        //        writer.WriteLine("AccountNumber,FirstName,LastName,Balance");

        //        foreach (var account in accounts)
        //        {
        //            writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName, account.Balance);
        //        }
        //    }
        //}

        //public void CreateAccount(Account accountToCreate)
        //{
        //    var accounts = GetAllAccounts();
        //    accounts.Add(accountToCreate);
        //    OverwriteFile(accounts);

        //}

        //public void DeleteAccount(Account accountToDelete)
        //{
        //    var accounts = GetAllAccounts();

        //    var deletedAccount = accounts.First(p => p.AccountNumber == accountToDelete.AccountNumber);

        //    accounts.Remove(deletedAccount);

        //    OverwriteFile(accounts);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class FakeRepository : IOrderRepository
    {
        public void CreateOrder(Order orderToCreate, string date)
        {
            string dateStorage = date;
            FakeData.Add(orderToCreate);
        }

        public string GetFilePath(string date)
        {
            return "";
        }

        public void DeleteOrder(int a, string date)
        {
            string dateStorage = date;
            var orderToDelete = FakeData.First(p => p.OrderNumber == a);

            FakeData.Remove(orderToDelete);
        }

        public void EditOrder(Order orderToUpdate, string date)
        {
            var orders = GetAllOrders(date);

            var orderToEdit = orders.First(o => o.OrderNumber == orderToUpdate.OrderNumber);

            orderToEdit.CustomerName = orderToUpdate.CustomerName;
            orderToEdit.ProductType = orderToUpdate.ProductType;

        }

        public List<Order> GetAllOrders(string date)
        {
            string taco = date;
            return FakeData;
        }

        List<Order> FakeData = new List<Order>
        {
            new Order {OrderNumber = 1, CustomerName= "James", State = "OH", TaxRate = 6.25M,
            ProductType = "Carpet", Area = 232, CostPerSquareFoot = 2.25M, MaterialCost = 522,
            LaborCost = 487.20M, tax = 63.08M, total = 1072.28M },

            new Order {OrderNumber = 2, CustomerName= "Kyle", State = "OH", TaxRate = 6.25M,
            ProductType = "Carpet", Area = 232, CostPerSquareFoot = 2.25M, MaterialCost = 522,
            LaborCost = 487.20M, tax = 63.08M, total = 1072.28M },

            new Order {OrderNumber = 3, CustomerName= "Jason", State = "OH", TaxRate = 6.25M,
            ProductType = "Carpet", Area = 232, CostPerSquareFoot = 2.25M, MaterialCost = 522,
            LaborCost = 487.20M, tax = 63.08M, total = 1072.28M },

            new Order {OrderNumber = 4, CustomerName= "Jill", State = "OH", TaxRate = 6.25M,
            ProductType = "Carpet", Area = 232, CostPerSquareFoot = 2.25M, MaterialCost = 522,
            LaborCost = 487.20M, tax = 63.08M, total = 1072.28M },

            new Order {OrderNumber = 5, CustomerName= "Jane", State = "OH", TaxRate = 6.25M,
            ProductType = "Carpet", Area = 232, CostPerSquareFoot = 2.25M, MaterialCost = 522,
            LaborCost = 487.20M, tax = 63.08M, total = 1072.28M },

        };


    }
}

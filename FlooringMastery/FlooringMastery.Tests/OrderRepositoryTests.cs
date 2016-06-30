using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMastery.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [TestCase]
        public void DisplayAllOrdersWorks()
        {
            var repo = new FakeRepository();
            
            var response = repo.GetAllOrders("taco");

            Assert.True(response.Count == 5);
        }

        [TestCase]
        public void CreateOrderWorks()
        {
            var repo = new FakeRepository();
            var mgr = new OrderManager(repo);
            var orders = repo.GetAllOrders("date");

            Order taco = new Order();

            taco.OrderNumber = 6;
            taco.CustomerName = "TestName";
            taco.State = "OH";
            taco.ProductType = "Carpet";
            taco.Area = 252;

                
            var response = mgr.Create(taco);

            Assert.True(orders.ElementAt(5).OrderNumber == 6); 
        }

        [TestCase]
        public void DeleteOrderWorks()
        {
            var repo = new FakeRepository();
            var mgr = new OrderManager(repo);
            var orders = repo.GetAllOrders("date");

            var response = mgr.DeleteOrder(1, "t");

            Assert.True(orders.Count == 4);  
        }

        [TestCase]
        public void EditOrderWorks()
        {
            var repo = new FakeRepository();
            var mgr = new OrderManager(repo);
            var orders = repo.GetAllOrders("date");

            //var response = mgr.EditOrder(1, "date");
            var orderEditting = orders.First(p => p.OrderNumber == 1);

            orderEditting.CustomerName = "TESTING";
            orderEditting.ProductType = "Wood";

            var response = mgr.EditOrder(orderEditting, "date");

            Assert.True(orders.ElementAt(0).CustomerName == "TESTING");
        }
        
    }
}

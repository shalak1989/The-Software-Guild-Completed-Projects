using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Models;
using System.Configuration;

namespace FlooringMastery.BLL
{   
    public class OrderManager
    {
        string _mode = ConfigurationManager.AppSettings["Mode"];
        IOrderRepository _repo;//guaranteeing that any _repo has all of the methods of the interface

        public OrderManager() //:this(new OrderRepository())//add a key to your config for the CONFIG switch                                                         //This code is saying IF you don't pass a specific repo it will use what comes after the this: keyword
        {                                                   // :this keyword points to IOrderRepository because OrderRepository is an IOrderRepository now due to inheritance 
            _repo = new OrderRepository();
            if (_mode.Equals("Test"))
            {
                FakeRepository fake = new FakeRepository();
                _repo = fake;
            }
            else
            {
                OrderRepository real = new OrderRepository();
                _repo = real;
            }
        }

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<Order> GetOrdersFromRepo(string date)
        {
           var orders = _repo.GetAllOrders(date);
            return orders;
        }

        public Response<CreateOrderReceipt> Create(Order order)
        {
            var response = new Response<CreateOrderReceipt>();
            var products = new ProductRepository();
            var taxes = new TaxRepository();

            var taxList = taxes.GetAllTaxes();
            var productList = products.GetAllProducts();

            response.Data = new CreateOrderReceipt();
            //var _repo = new OrderRepository();
            

            var orderList = _repo.GetAllOrders(DateTime.Now.ToShortDateString().Replace("/", ""));
            int ordCount = orderList.Count();
            if (ordCount == 0)
            {
                order.OrderNumber = 1;
            }
            else
            {
                orderList.Max(ord => ord.OrderNumber);
                order.OrderNumber = ordCount + 1;
            }

            order.TaxRate = taxList.First(x => x.State == order.State).TaxRate;// this is the same as saying where "this" is first true give me the tax rate
            order.CostPerSquareFoot = productList.First(p => p.ProductType == order.ProductType).CostPerSquareFoot;
            order.MaterialCost = order.CostPerSquareFoot * order.Area;
            order.LaborCost = (productList.First(p => p.ProductType == order.ProductType).LaborCostPerSquareFoot) * order.Area;
            order.tax = (order.MaterialCost + order.LaborCost) * (order.TaxRate / 100M);
            order.total = order.MaterialCost + order.LaborCost + order.tax;
            //
            // use state and tax to get tax rate*
            // use product to get cost per square foot*
            //use cost per square foot * area to get material costs*
            //use labor cost per square foot * area to get Labor Cost*
            // sum materials cost and labor cost
            //// multiply the summed value above by the taxrate to get the tax
            // Get total by adding summed value + tax

            

            try
            {
                if (order.total <= 0)
                {
                    response.Success = false;
                    response.Message = "Must place the order with a positive total.";
                }
                else
                {

                    _repo.CreateOrder(order, DateTime.Now.ToShortDateString().Replace("/", ""));
                    response.Success = true;

                    response.Data.OrderNumber = order.OrderNumber;
                    response.Data.CustomerName = order.CustomerName;
                    response.Data.State = order.State;
                    response.Data.TaxRate = order.TaxRate;
                    response.Data.ProductType = order.ProductType;
                    response.Data.Area = order.Area;
                    response.Data.CostPerSquareFoot = order.CostPerSquareFoot;
                    response.Data.MaterialCost = order.MaterialCost;
                    response.Data.LaborCost = order.LaborCost;
                    response.Data.tax = order.tax;
                    response.Data.total = order.total;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<DeleteOrderReceipt> DeleteOrder(int a, string t)
        {
            var response = new Response<DeleteOrderReceipt>();
            response.Data = new DeleteOrderReceipt();
            //you need to pass in the date from the user
           
            _repo.GetFilePath(t);

            var orderList = _repo.GetAllOrders(t);

            try
            {
                _repo.DeleteOrder(a, t);
                response.Success = true;
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<EditOrderReceipt> EditOrder(Order order, string date)
        {
            //Customer name, state, product type, and area have been set
            var response = new Response<EditOrderReceipt>();
            response.Data = new EditOrderReceipt();
            var products = new ProductRepository();
            var taxes = new TaxRepository();

            var taxList = taxes.GetAllTaxes();
            var productList = products.GetAllProducts();


            //var _repo = new OrderRepository();
            _repo.GetFilePath(date);

            //var orderList = _repo.GetAllOrders(date);


            order.TaxRate = taxList.First(x => x.State == order.State).TaxRate;// this is the same as saying where "this" is first true give me the tax rate
            order.CostPerSquareFoot = productList.First(p => p.ProductType == order.ProductType).CostPerSquareFoot;
            order.MaterialCost = order.CostPerSquareFoot * order.Area;
            order.LaborCost = (productList.First(p => p.ProductType == order.ProductType).LaborCostPerSquareFoot) * order.Area;
            order.tax = (order.MaterialCost + order.LaborCost) * (order.TaxRate / 100M);
            order.total = order.MaterialCost + order.LaborCost + order.tax;

            

            try
            {
                if (order.total <= 0)
                {
                    response.Success = false;
                    response.Message = "Must place the order with a positive total.";
                }
                else
                {
                    _repo.EditOrder(order, date);
                    response.Success = true;

                    response.Data.OrderNumber = order.OrderNumber;
                    response.Data.CustomerName = order.CustomerName;
                    response.Data.State = order.State;
                    response.Data.TaxRate = order.TaxRate;
                    response.Data.ProductType = order.ProductType;
                    response.Data.Area = order.Area;
                    response.Data.CostPerSquareFoot = order.CostPerSquareFoot;
                    response.Data.MaterialCost = order.MaterialCost;
                    response.Data.LaborCost = order.LaborCost;
                    response.Data.tax = order.tax;
                    response.Data.total = order.total;

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







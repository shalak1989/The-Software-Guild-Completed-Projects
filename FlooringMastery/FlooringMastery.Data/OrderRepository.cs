﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;


namespace FlooringMastery.Data
{
    public class OrderRepository : IOrderRepository
    {
        string datetime = DateTime.Now.ToShortDateString().Replace("/", "");

        public string GetFilePath(string date)
        {
            return string.Format(@"Datafiles\Orders_{0}.txt", date);
        }

        public List<Order> GetAllOrders(string date)
        {
            List<Order> orders = new List<Order>();

            if(File.Exists(GetFilePath(date)))
            {
                var reader = File.ReadAllLines(GetFilePath(date));

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
            else
            {
                return new List<Order>();
            }
       
         }

        public void EditOrder(Order orderToUpdate, string date)
        {
            var orders = GetAllOrders(date);

            var existingOrder = orders.First(order => order.OrderNumber == orderToUpdate.OrderNumber);
            existingOrder.CustomerName = orderToUpdate.CustomerName;
            existingOrder.State = orderToUpdate.State;
            existingOrder.TaxRate = orderToUpdate.TaxRate;
            existingOrder.ProductType = orderToUpdate.ProductType;
            existingOrder.Area = orderToUpdate.Area;
            existingOrder.CostPerSquareFoot = orderToUpdate.CostPerSquareFoot;
            existingOrder.MaterialCost = orderToUpdate.MaterialCost;
            existingOrder.LaborCost = orderToUpdate.LaborCost;
            existingOrder.tax = orderToUpdate.tax;
            existingOrder.total = orderToUpdate.total;

            OverwriteOrderFile(orders, date);
        }

        private void OverwriteOrderFile(List<Order> orders, string date)//DONE
        {
            File.Delete(GetFilePath(date));

            using (var writer = File.CreateText(GetFilePath(date)))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                    "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", order.OrderNumber, order.CustomerName,
                        order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.MaterialCost,
                        order.LaborCost, order.tax, order.total);
                }
            }
        }

        public void CreateOrder(Order orderToCreate, string date)//DONE
        {
            var orders = GetAllOrders(date);
            orders.Add(orderToCreate);
            OverwriteOrderFile(orders, date);
            

        }

        public void DeleteOrder(int a, string date)//DONE
        {
            var orders = GetAllOrders(date);

            var deletedOrder = orders.First(o => o.OrderNumber == a);

            orders.Remove(deletedOrder);

            OverwriteOrderFile(orders, date);
        }

    }
}

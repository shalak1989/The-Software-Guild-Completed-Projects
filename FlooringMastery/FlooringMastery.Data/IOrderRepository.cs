using System.Collections.Generic;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public interface IOrderRepository
    {
        string GetFilePath(string date);
        void CreateOrder(Order orderToCreate, string date);
        void DeleteOrder(int a, string date);
        void EditOrder(Order orderToUpdate, string date);
        List<Order> GetAllOrders(string date);
    }
}
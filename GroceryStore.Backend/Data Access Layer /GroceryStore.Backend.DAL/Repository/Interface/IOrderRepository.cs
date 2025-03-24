using GroceryStore.Backend.DAL.Entities;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<int> AddOrders(OrderEntity order);
        Task<IEnumerable<OrderEntity>> GetOrders(string userEmail);
    }
}

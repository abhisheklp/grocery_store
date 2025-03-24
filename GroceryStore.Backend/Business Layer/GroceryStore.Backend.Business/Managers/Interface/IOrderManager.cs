using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface IOrderManager
    {
        Task<int> AddOrders(OrderDTO order);
        Task<IEnumerable<OrderDTO>> GetOrders(string userEmail);
    }
}

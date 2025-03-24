using GroceryStore.Backend.DAL.Data.DbContext;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GroceryDbContext _groceryDbContext;

        public OrderRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }

        public async Task<int> AddOrders(OrderEntity order)
        {
            await _groceryDbContext.AddAsync(order);
            await _groceryDbContext.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task<IEnumerable<OrderEntity>> GetOrders(string userEmail)
        {
            var result = await _groceryDbContext.OrderTable.Where(x => x.UserEmail == userEmail).ToListAsync();
            return result;
        }
    }
}

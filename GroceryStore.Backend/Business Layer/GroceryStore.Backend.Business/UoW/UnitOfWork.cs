using GroceryStore.Backend.DAL.Data.DbContext;
using GroceryStore.Backend.DAL.Repository;
using GroceryStore.Backend.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GroceryDbContext _context;

        public UnitOfWork(GroceryDbContext context)
        {
            _context = context;
            CartRepository = new CartRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            OrderRepository = new OrderRepository(_context);
            ProductRepository = new ProductRepository(_context);
            ReviewRepository = new ReviewRepository(_context);
        }

        public ICartRepository CartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IReviewRepository ReviewRepository { get; }
    }
}

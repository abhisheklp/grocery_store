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
    public class ProductRepository : IProductRepository
    {
        private readonly GroceryDbContext _groceryDbContext;

        public ProductRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }

        public async Task<int> AddProduct(ProductEntity product)
        {
            await _groceryDbContext.AddAsync(product);
            await _groceryDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            var allProduct = await _groceryDbContext.ProductTable.ToListAsync(); 
            return allProduct;
        }

        public async Task<ProductEntity> GetProduct(int id)
        {
            var product = await _groceryDbContext.ProductTable.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategory(int categoryId)
        {
            var allProduct = await _groceryDbContext.ProductTable.Where(x => x.CategoryEntityId == categoryId).ToListAsync();
            return allProduct;
        }

        public async Task<IEnumerable<ProductEntity>> SearchProduct(string query)
        {
            var products = await _groceryDbContext.ProductTable.Where(p => p.ProductName.Contains(query) || p.ProductDescription.Contains(query)).ToListAsync();
            return products;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _groceryDbContext.ProductTable.FindAsync(id);
            if(product != null)
            {
                _groceryDbContext.ProductTable.Remove(product);
                await _groceryDbContext.SaveChangesAsync();
                return true;
            }
            return false; 
        }

        public async Task updateQuantity(int id, int decQuantity)
        {
            var product = await _groceryDbContext.ProductTable.FindAsync(id);
            product.ProductQuantity = product.ProductQuantity - decQuantity;
            await _groceryDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(ProductEntity updatedProduct)
        {
            var product = await _groceryDbContext.ProductTable.FindAsync(updatedProduct.ProductId);
            if(product != null)
            {
                product.ProductName = updatedProduct.ProductName;
                product.ProductDescription = updatedProduct.ProductDescription;
                product.ProductQuantity = updatedProduct.ProductQuantity;
                product.ProductPrice = updatedProduct.ProductPrice;
                product.ProductDiscount = updatedProduct.ProductDiscount;
                product.ProductSpecification = updatedProduct.ProductSpecification;
                product.CategoryEntityId = updatedProduct.CategoryEntityId;
                await _groceryDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

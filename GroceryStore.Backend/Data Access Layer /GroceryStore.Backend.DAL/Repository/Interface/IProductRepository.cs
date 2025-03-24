using GroceryStore.Backend.DAL.Entities;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface IProductRepository
    {
        Task<int> AddProduct(ProductEntity product);

        Task<IEnumerable<ProductEntity>> GetAllProducts();

        Task<ProductEntity> GetProduct(int id);

        Task<IEnumerable<ProductEntity>> GetProductsByCategory(int categoryId);

        Task<IEnumerable<ProductEntity>> SearchProduct(string query);

        Task<bool> DeleteProduct(int id);

        Task updateQuantity(int id, int decQuantity);

        Task<bool> UpdateProduct(ProductEntity updatedProduct);
    }
}

using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface IProductManager
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProduct(int id);
        Task<int> AddProduct(ProductDTO product);
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<ProductDTO>> SearchProduct(string query);
        Task<bool> DeleteProduct(int id);
        Task updateQuantity(int id, int decQuantity);
        Task<bool> UpdateProduct(ProductDTO updatedProduct);
    }
}

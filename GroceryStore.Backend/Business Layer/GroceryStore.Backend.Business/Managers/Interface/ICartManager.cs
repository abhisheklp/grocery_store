using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface ICartManager
    {
        Task<int> AddProductToCart(CartDTO cartItem);
        Task<IEnumerable<CartDTO>> GetCartItemsByUser(string userName);
        Task<bool> UpdateCartItemById(int id, int newQuantity);
        Task<bool> DeleteCartItemById(int id);
        Task<bool> DeleteCartItemsAfterOrder(string userName);
    }
}

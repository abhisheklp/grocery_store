using GroceryStore.Backend.DAL.Entities;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface ICartRepository
    {
        Task<int> AddProductToCart(CartEntity cartItem);
        Task<IEnumerable<CartEntity>> GetCartItemsByUser(string userName);
        Task<bool> UpdateCartItemById(int id, int newQuantity);
        Task<bool> DeleteCartItemById(int id);
        Task<bool> DeleteCartItemsAfterOrder(string userName);
    }
}

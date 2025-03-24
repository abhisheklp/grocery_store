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
    public class CartRepository : ICartRepository
    {
        private readonly GroceryDbContext _groceryDbContext;

        public CartRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }

        public async Task<int> AddProductToCart(CartEntity cartItem)
        {
            await _groceryDbContext.AddAsync(cartItem);
            await _groceryDbContext.SaveChangesAsync();
            return cartItem.CartId;
        }

        public async Task<IEnumerable<CartEntity>> GetCartItemsByUser(string userName)
        {
            var cartItems = await _groceryDbContext.CartTable.Where(x => x.UserName == userName).ToListAsync();
            return cartItems;
        }

        public async Task<bool> UpdateCartItemById(int id, int newQuantity)
        {
            var item = await _groceryDbContext.CartTable.Where(x => x.CartId == id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.ProductQuantity = newQuantity;
                await _groceryDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCartItemById(int id)
        {
            var item = await _groceryDbContext.CartTable.FindAsync(id);

            if (item != null)
            {
                _groceryDbContext.Remove(item);
                await _groceryDbContext.SaveChangesAsync();

                // Verify if the item was indeed deleted from the database
                var result = await _groceryDbContext.CartTable.FindAsync(id);
                if (result == null)
                {
                    return true; // Item was successfully deleted
                }
            }

            return false; // Item was not found or failed to delete
        }

        public async Task<bool> DeleteCartItemsAfterOrder(string userName)
        {
            var cartItems = await _groceryDbContext.CartTable.Where(x => x.UserName == userName).ToListAsync();

            if (cartItems.Count == 0)
            {
                return true; // No cart items found for the user, nothing to delete
            }

            _groceryDbContext.CartTable.RemoveRange(cartItems); // Remove all cart items in one operation
            await _groceryDbContext.SaveChangesAsync(); // Save changes asynchronously

            // Verify if the cart items were indeed deleted from the database
            var result = await _groceryDbContext.CartTable.Where(x => x.UserName == userName).ToListAsync();

            return result.Count == 0; // Return true if all cart items were deleted, false otherwise
        }


        //public async Task<bool> DeleteCartItemsAfterOrder(string userName)
        //{
        //    var cartItems = await _groceryDbContext.CartTable.Where(x => x.UserName == userName).ToListAsync();
        //    foreach (var cartItem in cartItems)
        //    {
        //        _groceryDbContext.Remove(cartItem);
        //        _groceryDbContext.SaveChanges();
        //    }
        //    var result = await _groceryDbContext.CartTable.Where(x => x.UserName == userName).ToListAsync();
        //    if (result.Count > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}

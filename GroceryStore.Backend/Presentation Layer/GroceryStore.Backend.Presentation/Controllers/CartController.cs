using AutoMapper;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Controllers
{
    [ApiController]
    [Route("cart")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IMapper _mapper;

        public CartController(IMapper mapper, ICartManager cartManager)
        {
            _mapper = mapper;
            _cartManager = cartManager;
        }

        /// <summary>
        /// Retrieves all cart items for a specific user.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>Returns the list of cart items.</returns>
        [HttpGet("{userName}")]
        public async Task<ActionResult<IEnumerable<CartModel>>> GetAllCartItems(string userName)
        {
            var response = await _cartManager.GetCartItemsByUser(userName);
            return Ok(_mapper.Map<IEnumerable<CartModel>>(response));
        }

        /// <summary>
        /// Adds a product to the user's cart.
        /// </summary>
        /// <param name="cart">The cart item to add.</param>
        /// <returns>Returns the ID of the added cart item.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> AddToCart(CartModel cart)
        {
            var dto = _mapper.Map<CartDTO>(cart);
            return Ok(await _cartManager.AddProductToCart(dto));
        }

        /// <summary>
        /// Updates the quantity of a cart item by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart item.</param>
        /// <param name="newQuantity">The new quantity to update.</param>
        /// <returns>Returns a boolean indicating whether the update was successful.</returns>
        [HttpPatch("{id}/{newQuantity}")]
        public async Task<ActionResult<bool>> UpdateCartItemById(int id, int newQuantity)
        {
            return Ok(await _cartManager.UpdateCartItemById(id, newQuantity));
        }

        /// <summary>
        /// Deletes a cart item by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart item to delete.</param>
        /// <returns>Returns a boolean indicating whether the deletion was successful.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<bool>> DeleteCartItemById(int id)
        {
            return Ok(await _cartManager.DeleteCartItemById(id));
        }

        /// <summary>
        /// Deletes all cart items for a specific user after an order is placed.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>Returns a boolean indicating whether the deletion was successful.</returns>
        [HttpDelete("user/{userName}")]
        public async Task<ActionResult<bool>> DeleteCartItemsAfterOrder(string userName)
        {
            return Ok(await _cartManager.DeleteCartItemsAfterOrder(userName));
        }
    }
}

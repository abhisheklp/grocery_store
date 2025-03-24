using AutoMapper;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductManager productManager)
        {
            _mapper = mapper;
            _productManager = productManager;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>Returns the list of all products.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var response = await _productManager.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(response));
        }

        /// <summary>
        /// Retrieves a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>Returns the product with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var response = await _productManager.GetProduct(id);
            return Ok(_mapper.Map<ProductModel>(response));
        }


        /// <summary>
        /// Retrieves products by category ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>Returns the list of products in the specified category.</returns>
        [HttpGet("category/{categoryId}")]
        public  async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByCategoryId(int categoryId)
        {
            var response = await _productManager.GetProductsByCategory(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(response));
        }

        /// <summary>
        /// Searches for products based on a query string.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>Returns the list of products matching the search query.</returns>
        [HttpGet("search/")]
        public  async Task<ActionResult<IEnumerable<ProductModel>>> SearchProduct([FromQuery] string query)
        {
            var response = await _productManager.SearchProduct(query);
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(response));
        }


        /// <summary>
        /// Updates the quantity of a product.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="decQuantity">The decreased quantity to add.</param>
        /// <returns>Returns the updated product quantity.</returns>
        [HttpPatch("{id}/{decQuantity}")]
        [Authorize]
        public async Task<ActionResult> updateQuantity(int id, int decQuantity)
        {
            await _productManager.updateQuantity(id, decQuantity);
            return Ok();
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="updatedProduct">The updated product data.</param>
        /// <returns>Returns a value indicating whether the product update was successful or not.</returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateProduct([FromForm] ProductDTO updatedProduct)
        {
            return Ok(await _productManager.UpdateProduct(updatedProduct));
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>Returns the ID of the added product.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProduct([FromForm] ProductDTO product)
        {
            return Ok(await _productManager.AddProduct(product));
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>Returns a value indicating whether the product deletion was successful or not.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            return Ok(await _productManager.DeleteProduct(id));
        }
    }
}

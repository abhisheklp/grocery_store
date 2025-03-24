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
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryManager categoryManager)
        {
            _mapper = mapper;
            _categoryManager = categoryManager;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>Returns the list of categories.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAllCategory()
        {
            var response = await _categoryManager.GetAllCategories();
            return Ok(_mapper.Map<IEnumerable<CategoryModel>>(response));
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The category to add.</param>
        /// <returns>Returns the ID of the added category.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddCategory(CategoryModel category)
        {
            var dto = _mapper.Map<CategoryDTO>(category);
            return Ok(await _categoryManager.AddCategory(dto));
        }
    }
}

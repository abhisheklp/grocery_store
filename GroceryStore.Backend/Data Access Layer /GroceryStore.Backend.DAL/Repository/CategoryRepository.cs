using GroceryStore.Backend.DAL.Data.DbContext;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace GroceryStore.Backend.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GroceryDbContext _groceryDbContext;

        public CategoryRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategory()
        {
            var allCategory = await _groceryDbContext.CategoryTable.ToListAsync();
            return allCategory;
        }

        public async Task<int> AddCategory(CategoryEntity category)
        {
            await _groceryDbContext.AddAsync(category);
            await _groceryDbContext.SaveChangesAsync();
            return category.CategoryId;
        }
    }
}

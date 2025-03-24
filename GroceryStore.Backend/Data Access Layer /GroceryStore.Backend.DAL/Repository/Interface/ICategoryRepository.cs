using GroceryStore.Backend.DAL.Entities;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategory();
        Task<int> AddCategory(CategoryEntity category);
    }
}

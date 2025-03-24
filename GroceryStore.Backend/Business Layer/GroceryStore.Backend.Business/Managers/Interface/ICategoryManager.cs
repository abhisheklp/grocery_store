using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<int> AddCategory(CategoryDTO category);
    }
}

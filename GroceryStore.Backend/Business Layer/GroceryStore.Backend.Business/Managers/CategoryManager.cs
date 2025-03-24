using AutoMapper;
using FluentValidation.Results;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Business.UoW;
using GroceryStore.Backend.Business.Validation;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var response = await _unitOfWork.CategoryRepository.GetAllCategory();
            return _mapper.Map<IEnumerable<CategoryDTO>>(response);
        }

        public async Task<int> AddCategory(CategoryDTO category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if(result.IsValid)
            {
                var entity = _mapper.Map<CategoryEntity>(category);
                var response = await _unitOfWork.CategoryRepository.AddCategory(entity);
                return response;
            }
            return -1;
        }
    }
}

using FluentValidation;
using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().MaximumLength(100);

            RuleFor(p => p.CategoryDescription).NotEmpty().MaximumLength(255);
        }
    }
}

using FluentValidation;
using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().MaximumLength(100);

            RuleFor(p => p.ProductDescription).NotEmpty().MaximumLength(255);

            RuleFor(p => p.ProductQuantity).NotEmpty();

            RuleFor(p => p.ProductPrice).NotEmpty();

            RuleFor(p => p.ProductImage).NotEmpty().Matches(@"\.(jpg|png)$").Unless(p => p.ProductImage == null);

            RuleFor(p => p.CategoryEntityId).NotEmpty();
        }
    }
}

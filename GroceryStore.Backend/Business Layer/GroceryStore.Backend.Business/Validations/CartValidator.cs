using FluentValidation;
using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.ProductEntityId).NotEmpty();

            RuleFor(c => c.ProductQuantity).NotEmpty();

            RuleFor(c => c.UserName).NotEmpty();
        }
    }
}

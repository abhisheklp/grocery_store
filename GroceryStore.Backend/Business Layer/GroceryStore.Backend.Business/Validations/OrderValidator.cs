using FluentValidation;
using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(o => o.OrderDate).NotEmpty();

            RuleFor(o => o.UserEmail).NotEmpty();

            RuleFor(o => o.ProductId).NotEmpty();

            RuleFor(o => o.OrderedItems).NotEmpty();

            RuleFor(o => o.OrderedQuantity).NotEmpty();

            RuleFor(o => o.AmountInItem).NotEmpty();

            RuleFor(o => o.OrderAmount).NotEmpty();
        }
    }
}

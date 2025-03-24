using FluentValidation;
using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation
{
    public class ReviewValidator : AbstractValidator<ReviewDTO>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.ProductEntityId).NotEmpty();

            RuleFor(r => r.ReviewText).NotEmpty().MaximumLength(200);

            RuleFor(r => r.ReviewRating).NotEmpty().InclusiveBetween(1, 5);

            RuleFor(r => r.ReviewDate).NotEmpty();

            RuleFor(r => r.UserEmail).NotEmpty();
        }
    }
}

using FluentValidation;
using GroceryStore.Backend.Business.DTO.AccountDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.Validation.AccountValidator
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email address.");

            RuleFor(l => l.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}

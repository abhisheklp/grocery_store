using FluentValidation;
using GroceryStore.Backend.Business.DTO.AccountDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GroceryStore.Backend.Business.Validation.AccountValidator
{
    public class SignupValidator : AbstractValidator<SignUpDTO>
    {
        public SignupValidator()
        {
            RuleFor(s => s.FullName).NotEmpty().WithMessage("Full Name is required.").MaximumLength(50);

            RuleFor(s => s.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email address.");

            RuleFor(s => s.PhoneNo).NotEmpty().WithMessage("Phone No. is required.").Length(10).WithMessage("Phone No. must be 10 characters long.");

            RuleFor(s => s.Password).NotEmpty().MinimumLength(8).Must(ContainSpecialCharacter).WithMessage("Password is required.");

            RuleFor(s => s.ConfirmPassword).Equal(s => s.Password).WithMessage("Passwords do not match.");

            RuleFor(s => s.IsAdmin).NotNull().WithMessage("isAdmin value is required.");
        }

        private bool ContainSpecialCharacter(string password)
        {
            // Regular expression to check for at least 1 special character, 1 number, and 1 alphabet
            string pattern = @"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[0-9])(?=.*[a-zA-Z]).*$";
            return Regex.IsMatch(password, pattern);
        }
    }
}

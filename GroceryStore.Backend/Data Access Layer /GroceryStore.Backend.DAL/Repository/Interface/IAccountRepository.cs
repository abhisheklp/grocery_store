using GroceryStore.Backend.DAL.Entities.AccountEntity;
using Microsoft.AspNetCore.Identity;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpEntity signUpData);
        Task<string> PasswordLoginAsync(LoginEntity loginData);
        Task LogOutAsync();
    }
}

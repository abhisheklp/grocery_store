using GroceryStore.Backend.Business.DTO.AccountDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface IAccountManager
    {
        Task<IdentityResult> CreateUserAsync(SignUpDTO user);
        Task<string> PasswordLoginAsync(LoginDTO user);
        Task LogOutAsync();
    }
}

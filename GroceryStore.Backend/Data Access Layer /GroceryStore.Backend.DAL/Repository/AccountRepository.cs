using GroceryStore.Backend.DAL.Entities.AccountEntity;
using GroceryStore.Backend.DAL.IdentityUserExtend;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpEntity signUpData)
        {
            var user = new ApplicationUser()
            {
                UserName = signUpData.Email,
                PhoneNumber = signUpData.PhoneNo,
                Email = signUpData.Email,
                FullName = signUpData.FullName,
                IsAdmin = signUpData.IsAdmin,
            };
            var result = await _userManager.CreateAsync(user, signUpData.Password);
            return result;
        }

        public async Task<string> PasswordLoginAsync(LoginEntity loginData)
        {
            var result = await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, isPersistent : false, false);
            if(!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginData.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

using AutoMapper;
using GroceryStore.Backend.Business.DTO.AccountDTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.DAL.IdentityUserExtend;
using GroceryStore.Backend.Presentation.Models.AccountModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Controllers
{
    [ApiController]
    [Route("authenticate")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IMapper mapper, IAccountManager accountManager, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _accountManager = accountManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="signUpData">The data for signing up a new user </param>
        /// <returns>Returns a boolean indicating the success of the sign-up operation </returns>
        [Route("signup")]
        [HttpPost]
        public async Task<ActionResult<bool>> SignUpAsync(SignUpModel signUpData)
        {
            var dto = _mapper.Map<SignUpDTO>(signUpData);
            var result = await _accountManager.CreateUserAsync(dto);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        /// <summary>
        /// Logs in a user using password-based authentication.
        /// </summary>
        /// <param name="loginData">The data for logging in a user.</param>
        /// <returns>Returns an object containing user information and authentication token if successful, otherwise returns Unauthorized.</returns>
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Object>> LoginAsync(LoginModel loginData)
        {
            var dto = _mapper.Map<LoginDTO>(loginData);
            var token = await _accountManager.PasswordLoginAsync(dto);
            if (!string.IsNullOrEmpty(token))
            {
                var user = await _userManager.FindByEmailAsync(loginData.Email);
                var userName = user.FullName;
                var userEmail = user.Email;
                var userIsAdmin = user.IsAdmin;
                return Ok(new { userEmail, userName, userIsAdmin, token });
            }
            return Unauthorized();
        }

        /// <summary>
        /// Logs out the currently authenticated user.
        /// </summary>
        /// <returns>An IActionResult representing the result of the logout operation.</returns>
        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _accountManager.LogOutAsync();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Common;
using System.Security.Claims;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private UserManager<AccountUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtTokenService jwtTokenService;

        public IdentityAccountService(UserManager<AccountUser> userManager, IHttpContextAccessor httpContextAccessor, JwtTokenService jwtTokenService)
        {
            this.jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            
        }
        public async Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modelState)
        {
            var user = new AccountUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerDto.Roles);

                return new AccountDto()
                {
                    Id = user.Id,
                    AccountName = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerDto) :
                                error.Code.Contains("Email") ? nameof(registerDto) :
                                error.Code.Contains("Username") ? nameof(registerDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }
            return null;
        }

        public async Task<AccountDto> UserLogIn(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    AccountName = user.UserName,
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7))
                };
            }

            return null;
        }
        public async Task<AccountDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new AccountDto()
            {
                Id = user.Id,
                AccountName = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7))
            };
        }

        public async Task Logout()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                await httpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            }
        }


    }
}

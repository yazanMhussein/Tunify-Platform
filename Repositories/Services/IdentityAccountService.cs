using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityAccountService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
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
                return new AccountDto
                {
                    Id = user.Id,
                    AccountName = registerDto.UserName,
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
                    AccountName = user.UserName
                };
            }

            return null;
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

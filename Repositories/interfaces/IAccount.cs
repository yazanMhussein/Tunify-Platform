using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IAccount
    {
        public Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modelState);
        public Task<AccountDto> UserLogIn(string username, string password);
        public Task<AccountDto> userProfile(ClaimsPrincipal claimsPrincipal);
        public Task Logout();
        
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AccountUser> _signInManager;
        public JwtTokenService(IConfiguration configuration, SignInManager<AccountUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var securityKey = configuration["JWT:SecretKey"];

            if (securityKey == null)
            {
                throw new InvalidOperationException("JWT Secret key  is not exsist");

            }
            var secretBytes = Encoding.UTF8.GetBytes(securityKey);
            return new SymmetricSecurityKey(secretBytes);
        }
        public async Task<string> GenerateToken(AccountUser user, TimeSpan expiryDate)
        {
            var userPrincliple = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincliple == null) { return null; }
            var signinKey = GetSecurityKey(_configuration);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.UtcNow + expiryDate,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    claims: userPrincliple.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

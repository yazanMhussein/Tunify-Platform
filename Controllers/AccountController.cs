using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto RegisterDto)
        {
            var account = await _account.Register(RegisterDto, this.ModelState);

            if (ModelState.IsValid)
            {
                return account;
            }

            if (account == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var account = await _account.UserLogIn(loginDto.AccountName, loginDto.Password);
            if (account == null)
            {
                return Unauthorized();
            }
            return account;
        }
        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _account.Logout();
            return Ok(new {message = "You been Log out" });
        }
    }
}

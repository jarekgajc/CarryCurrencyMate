using Backend.Models.Accounts;
using Backend.Services.AccountServices;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("")]
        public async Task<Account> GetAccount()
        {
            return await _accountService.GetAccount(User.GetAccountId());
        }
    }
}

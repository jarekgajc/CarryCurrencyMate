using Backend.Services.AccountServices;
using Backend.Utils;
using Common.Models.Account;
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

        [HttpGet]
        public async Task<List<Account>> GetAccounts()
        {
            return await _accountService.GetAccounts();
        }

        [HttpGet("user")]
        public async Task<Account> GetUserAccount()
        {
            return await _accountService.GetUserAccount(User.GetUserId());
        }

        [HttpPost]
        public async Task<Account> CreateAccount(Account account)
        {
            return await _accountService.CreateAccount(account);
        }

        [HttpPut("{id}")]
        public async Task<Account> UpdateAccount(int id, Account account)
        {
            return await _accountService.UpdateAccount(id, account);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAccount(int id)
        {
            return await _accountService.DeleteAccount(id);
        }
    }
}

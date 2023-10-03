using Backend.Models.Account;
using Backend.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<List<Account>> GetAccounts()
        {
            return await accountService.GetAccounts();
        }

        [HttpPost]
        public async Task<Account> CreateAccount(Account account)
        {
            return await accountService.CreateAccount(account);
        }

        [HttpPut("{id}")]
        public async Task<Account?> UpdateAccount(int id, Account account)
        {
            return await accountService.UpdateAccount(id, account);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAccount(int id)
        {
            return await accountService.DeleteAccount(id);
        }
    }
}

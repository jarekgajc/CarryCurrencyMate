using Backend.Models.Accounts;
using Backend.Services.AccountPreferenceServices;
using Backend.Utils;
using Common.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/accounts/preferences")]
    [ApiController]
    public class AccountPreferenceController : ControllerBase
    {
        private readonly IAccountPreferenceService _accountPreferenceService;

        public AccountPreferenceController(IAccountPreferenceService accountPreferenceService)
        {
            _accountPreferenceService = accountPreferenceService;
        }

        [HttpGet("")]
        public async Task<AccountPreference?> GetAccountPreference()
        {
            return await _accountPreferenceService.GetAccountPreference(User.GetAccountId());
        }

        [HttpPost("")]
        public async Task<AccountPreference> CreateAccountPreference(AccountPreferenceDto accountPreference)
        {
            return await _accountPreferenceService.CreateAccountPreference(AccountPreference.FromDto(User.GetAccountId(), accountPreference));
        }

        [HttpPut("{id}")]
        public async Task<AccountPreference> UpdateAccountPreference(int id, AccountPreferenceDto accountPreference)
        {
            return await _accountPreferenceService.UpdateAccountPreference(id, AccountPreference.FromDto(User.GetAccountId(), accountPreference));
        }
    }
}

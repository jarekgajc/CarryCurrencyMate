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
        public async Task<AccountPreferenceDto?> GetAccountPreference()
        {
            return (await _accountPreferenceService.GetAccountPreference(User.GetAccountId()))?.ToDto();
        }

        [HttpPost("")]
        public async Task<AccountPreferenceDto> CreateAccountPreference(AccountPreferenceDto accountPreference)
        {
            return (await _accountPreferenceService.CreateAccountPreference(AccountPreference.FromDto(User.GetAccountId(), accountPreference))).ToDto();
        }

        [HttpPut("{id}")]
        public async Task<AccountPreferenceDto> UpdateAccountPreference(int id, AccountPreferenceDto accountPreference)
        {
            return (await _accountPreferenceService.UpdateAccountPreference(id, AccountPreference.FromDto(User.GetAccountId(), accountPreference))).ToDto();
        }
    }
}

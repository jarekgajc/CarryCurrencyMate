using Backend.Models.Accounts;
using Backend.Models.Users;

namespace Backend.Services.AccountPreferenceServices
{
    public interface IAccountPreferenceService
    {
        Task<AccountPreference?> GetAccountPreference(int accountId);
        Task<AccountPreference> CreateAccountPreference(AccountPreference accountPreference);
        Task<AccountPreference> UpdateAccountPreference(int id, AccountPreference accountPreference);
    }
}
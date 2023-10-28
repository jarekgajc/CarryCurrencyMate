using Backend.Data;
using Backend.Models.Accounts;
using Backend.Models.Exceptions;
using Backend.Services.AccountPreferenceServices;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.AccountServices
{
    public class AccountPreferenceService : IAccountPreferenceService
    {
        private readonly DataContext _dataContext;

        public AccountPreferenceService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AccountPreference?> GetAccountPreference(int accountId)
        {
            return await _dataContext.AccountPreferences.Where(accountPreference => accountPreference.AccountId == accountId).FirstOrDefaultAsync();
        }

        public async Task<AccountPreference> CreateAccountPreference(AccountPreference accountPreference)
        {
            if(await _dataContext.AccountPreferences.Where(preference => preference.AccountId == accountPreference.AccountId).AnyAsync())
            {
                throw new ApiException(new ResourceDoesNotExist());
            }
            _dataContext.AccountPreferences.Add(accountPreference);
            await _dataContext.SaveChangesAsync();

            return accountPreference;
        }

        public async Task<AccountPreference> UpdateAccountPreference(int id, AccountPreference accountPreference)
        {
            if (id != accountPreference.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }
            var current = await _dataContext.AccountPreferences
                .Where(preference => preference.Id == id && preference.AccountId == accountPreference.AccountId)
                .FirstOrDefaultAsync() ?? throw new ApiException(new ResourceDoesNotExist());

            _dataContext.Entry(current).CurrentValues.SetValues(accountPreference);
            await _dataContext.SaveChangesAsync();

            return current;
        }
        
    }
}

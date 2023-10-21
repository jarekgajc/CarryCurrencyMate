using Backend.Data;
using Backend.Models.Accounts;
using Backend.Models.Exceptions;
using Backend.Models.Users;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Backend.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;

        public AccountService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _dataContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccount(int id)
        {
            return await _dataContext.Accounts.FindAsync(id) ?? throw new ApiException(new ResourceDoesNotExist());
        }

        public async Task<Account> GetAccountIncludeObservers(int id)
        {
            return await _dataContext.Accounts.Where(account => account.Id == id).Include(account => account.Observers).FirstOrDefaultAsync() ?? throw new ApiException(new ResourceDoesNotExist());
        }

        public async Task<Account> GetOrCreateUserAccount(User user)
        {
            Account? account = await _dataContext.Accounts.Where(account => account.User.Id == user.Id).FirstOrDefaultAsync();
            account ??= await CreateAccount(new Account
                {
                    User = user,
                    Observers = new List<Models.Observers.Observer>()
                });
            return account;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            _dataContext.Accounts.Add(account);
            await _dataContext.SaveChangesAsync();

            return account;
        }

        public async Task<Account> UpdateAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }
            var current = await _dataContext.Accounts.FindAsync(id) ?? throw new ApiException(new ResourceDoesNotExist());
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var current = await _dataContext.Accounts.FindAsync(id);
            if (current == null)
            {
                return false;
            }

            _dataContext.Accounts.Remove(current);
            await _dataContext.SaveChangesAsync();

            return true;
        }
        
    }
}

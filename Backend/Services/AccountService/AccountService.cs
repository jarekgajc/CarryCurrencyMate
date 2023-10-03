using Backend.Data;
using Backend.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext dataContext;

        public AccountService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await dataContext.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccount(int id)
        {
            return await dataContext.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAccount(Account account)
        {
            dataContext.Accounts.Add(account);
            await dataContext.SaveChangesAsync();

            return account;
        }

        public async Task<Account?> UpdateAccount(int id, Account account)
        {
            var current = await dataContext.Accounts.FindAsync(id);
            if (current == null)
            {
                return null;
            }

            await dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var current = await dataContext.Accounts.FindAsync(id);
            if (current == null)
            {
                return false;
            }

            dataContext.Accounts.Remove(current);
            await dataContext.SaveChangesAsync();

            return true;
        }
        
    }
}

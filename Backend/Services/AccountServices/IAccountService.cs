using Common.Models.Accounts;

namespace Backend.Services.AccountServices
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
        Task<Account?> GetAccount(int id);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(int id, Account account);
        Task<bool> DeleteAccount(int id);
        Task<Account> GetUserAccount(int userId);
    }
}
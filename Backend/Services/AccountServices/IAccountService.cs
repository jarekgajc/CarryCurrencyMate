using Backend.Models.Accounts;
using Backend.Models.Users;

namespace Backend.Services.AccountServices
{
    public interface IAccountService
    {
        Task<Account> GetAccount(int id);
        Task<Account> GetAccountIncludeObservers(int id);
        Task<Account> GetAccountIncludeExchangers(int id);
        Task<Account> GetOrCreateUserAccount(User user);
    }
}
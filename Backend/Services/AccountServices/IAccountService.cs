using Backend.Models.Accounts;
using Backend.Models.Transactions;
using Backend.Models.Users;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.Services.AccountServices
{
    public interface IAccountService
    {
        Task<Account> GetAccount(int id);
        Task<Account> GetAccountIncludeObservers(int id);
        Task<Account> GetAccountIncludeExchangers(int id);
        Task<Account> GetOrCreateUserAccount(User user);
        IIncludableQueryable<Account, List<TransactionSource>> GetAccountIncludeTransactionSources(int id);
    }
}
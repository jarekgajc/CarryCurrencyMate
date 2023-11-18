using Backend.Data;
using Backend.Models.Accounts;
using Backend.Models.Exceptions;
using Backend.Models.Transactions;
using Backend.Services.AccountServices;
using Backend.Utils;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.Services.TransactionSourceServices
{
    public class TransactionSourceService : ITransactionSourceService
    {
        private readonly DataContext _dataContext;
        private readonly IAccountService _accountService;

        public TransactionSourceService(DataContext dataContext, IAccountService accountService)
        {
            _dataContext = dataContext;
            _accountService = accountService;
        }

        public async Task<List<TransactionSource>> GetTransactionSources(int accountId)
        {
            Account account = await _accountService.GetAccountIncludeTransactionSources(accountId).GetOrThrow();
            return account.TransactionSources;
        }

        public async Task<TransactionSource?> GetTransactionSource(int accountId, long id)
        {
            Account account = await _accountService.GetAccountIncludeTransactionSources(accountId).GetOrThrow();
            return account.TransactionSources.Find(transactionSource => id == transactionSource.Id);
        }

        public IIncludableQueryable<TransactionSource, List<Transaction>> GetTransactionSourceIncludeTransactions(int accountId, long id)
        {
            return _accountService.GetAccountIncludeTransactionSources(accountId)
                .SelectMany(account => account.TransactionSources)
                .Include(transactionSource => transactionSource.Transactions);
        }

        public async Task<TransactionSource> CreateTransactionSource(int accountId, TransactionSource transactionSource)
        {
            Account account = await _accountService.GetAccountIncludeTransactionSources(accountId).GetOrThrow();
            account.TransactionSources.Add(transactionSource);
            await _dataContext.SaveChangesAsync();

            return transactionSource;
        }

        public async Task<TransactionSource> UpdateTransactionSource(int accountId, long id, TransactionSource transactionSource)
        {
            if (id != transactionSource.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }

            TransactionSource current = await GetTransactionSource(accountId, id) ?? throw new ApiException(new ResourceDoesNotExist());

            current.Name = transactionSource.Name;
            current.InfoMap = transactionSource.InfoMap;
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteTransactionSource(int accountId, long id)
        {
            TransactionSource? current = (await GetTransactionSource(accountId, id));
            if (current == null)
            {
                return false;
            }

            _dataContext.TransactionSources.Remove(current);
            await _dataContext.SaveChangesAsync();

            return true;
        }

    }
}

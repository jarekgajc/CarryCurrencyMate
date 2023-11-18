using Backend.Data;
using Backend.Models.Exceptions;
using Backend.Models.Transactions;
using Backend.Services.TransactionSourceServices;
using Backend.Utils;
using Common.Models.Error.Api;
using Common.Models.Transactions;

namespace Backend.Services.TransactionServices
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _dataContext;
        private readonly ITransactionSourceService _transactionSourceService;

        public TransactionService(DataContext dataContext, ITransactionSourceService transactionSourceService)
        {
            _dataContext = dataContext;
            _transactionSourceService = transactionSourceService;
        }

        public async Task<List<Transaction>> GetTransactions(TransactionSourcePath path)
        {
            TransactionSource transactionSource = await _transactionSourceService.GetTransactionSourceIncludeTransactions(path.AccountId, path.TransactionSourceId).GetOrThrow();
            return transactionSource.Transactions;
        }

        public async Task<Transaction?> GetTransaction(TransactionSourcePath path, string id)
        {
            TransactionSource transactionSource = await _transactionSourceService.GetTransactionSourceIncludeTransactions(path.AccountId, path.TransactionSourceId).GetOrThrow();
            return transactionSource.Transactions.Find(transaction => id == transaction.Id);
        }

        public async Task<Transaction> CreateTransaction(TransactionSourcePath path, Transaction transaction)
        {
            TransactionSource transactionSource = await _transactionSourceService.GetTransactionSourceIncludeTransactions(path.AccountId, path.TransactionSourceId).GetOrThrow();
            transaction.Id = Guid.NewGuid().ToString("N");
            transactionSource.Transactions.Add(transaction);
            await _dataContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<Transaction> UpdateTransaction(TransactionSourcePath path, string id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }

            Transaction current = await GetTransaction(path, id) ?? throw new ApiException(new ResourceDoesNotExist());

            current.Currency = transaction.Currency;
            current.Amount = transaction.Amount;
            current.Time = transaction.Time;
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteTransaction(TransactionSourcePath path, string id)
        {
            Transaction? current = (await GetTransaction(path, id));
            if (current == null)
            {
                return false;
            }

            _dataContext.Transactions.Remove(current);
            await _dataContext.SaveChangesAsync();

            return true;
        }

    }
}

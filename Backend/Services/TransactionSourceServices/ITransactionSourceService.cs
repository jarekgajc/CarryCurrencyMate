using Backend.Models.Transactions;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.Services.TransactionSourceServices
{
    public interface ITransactionSourceService
    {
        Task<TransactionSource> CreateTransactionSource(int accountId, TransactionSource transactionSource);
        Task<bool> DeleteTransactionSource(int accountId, long id);
        Task<List<TransactionSource>> GetTransactionSources(int accountId);
        Task<TransactionSource> UpdateTransactionSource(int accountId, long id, TransactionSource transactionSource);
        IIncludableQueryable<TransactionSource, List<Transaction>> GetTransactionSourceIncludeTransactions(int accountId, long id);
    }
}
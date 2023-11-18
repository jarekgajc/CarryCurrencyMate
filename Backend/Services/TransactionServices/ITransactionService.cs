using Backend.Models.Transactions;
using Common.Models.Transactions;

namespace Backend.Services.TransactionServices
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(TransactionSourcePath path, Transaction transaction);
        Task<bool> DeleteTransaction(TransactionSourcePath path, string id);
        Task<List<Transaction>> GetTransactions(TransactionSourcePath path);
        Task<Transaction> UpdateTransaction(TransactionSourcePath path, string id, Transaction transaction);
    }
}
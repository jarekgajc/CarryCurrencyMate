using Backend.Models.Transactions;
using Backend.Services.TransactionServices;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Common.Models.Transactions;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/transaction-sources/{transactionSourceId}/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<List<TransactionDto>> GetTransactions(long transactionSourceId)
        {
            return (await _transactionService.GetTransactions(new TransactionSourcePath(User.GetAccountId(), transactionSourceId))).Select(transaction => transaction.ToDto()).ToList();
        }

        [HttpPost]
        public async Task<TransactionDto> CreateTransaction(long transactionSourceId, TransactionDto transaction)
        {
            return (await _transactionService.CreateTransaction(new TransactionSourcePath(User.GetAccountId(), transactionSourceId), Transaction.FromDto(transaction))).ToDto();
        }

        [HttpPut("{id}")]
        public async Task<TransactionDto> UpdateTransaction(long transactionSourceId, string id, TransactionDto transaction)
        {
            return (await _transactionService.UpdateTransaction(new TransactionSourcePath(User.GetAccountId(), transactionSourceId), id, Transaction.FromDto(transaction))).ToDto();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteTransaction(long transactionSourceId, string id)
        {
            return await _transactionService.DeleteTransaction(new TransactionSourcePath(User.GetAccountId(), transactionSourceId), id);
        }
    }
}

using Backend.Models.Transactions;
using Backend.Services.TransactionSourceServices;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Common.Models.Transactions;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/transaction-sources")]
    [ApiController]
    public class TransactionSourceController : ControllerBase
    {
        private readonly ITransactionSourceService _transactionService;

        public TransactionSourceController(ITransactionSourceService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<List<TransactionSourceDto>> GetTransactionSources()
        {
            return (await _transactionService.GetTransactionSources(User.GetAccountId())).Select(transaction => transaction.ToDto()).ToList();
        }

        [HttpPost]
        public async Task<TransactionSourceDto> CreateTransactionSource(TransactionSourceDto transaction)
        {
            return (await _transactionService.CreateTransactionSource(User.GetAccountId(), TransactionSource.FromDto(transaction))).ToDto();
        }

        [HttpPut("{id}")]
        public async Task<TransactionSourceDto> UpdateTransactionSource(long id, TransactionSourceDto transaction)
        {
            return (await _transactionService.UpdateTransactionSource(User.GetAccountId(), id, TransactionSource.FromDto(transaction))).ToDto();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteTransactionSource(long id)
        {
            return await _transactionService.DeleteTransactionSource(User.GetAccountId(), id);
        }
    }
}

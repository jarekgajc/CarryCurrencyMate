using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Models.Observations;
using Common.Models.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Transactions
{
    public class Transaction
    {
        [Column(TypeName = "char")]
        [StringLength(32)]
        public string Id { get; set; }
        public long SourceId { get; set; }
        public string ExternalId { get; set; }
        public Currency Currency { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }

        public TransactionDto ToDto()
        {
            return new TransactionDto()
            {
                Id = Id,
                SourceId = SourceId,
                ExternalId = ExternalId,
                Currency = Currency,
                Amount = Amount,
                Time = Time
            };
        }

        public static Transaction FromDto(TransactionDto dto)
        {
            return new Transaction()
            {
                Id = dto.Id,
                SourceId = dto.SourceId,
                ExternalId = dto.ExternalId,
                Currency = dto.Currency,
                Amount = dto.Amount,
                Time = dto.Time
            };
        }
    }
}

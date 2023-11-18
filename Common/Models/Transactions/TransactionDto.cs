using Common.Models.Observations;

namespace Common.Models.Transactions
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public long SourceId { get; set; }
        public string ExternalId { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time;
    }
}

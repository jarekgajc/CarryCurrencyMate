using Common.Models.Accounts;
using Common.Models.Observations;

namespace Common.Models.Transactions
{
    public class TransactionSourcePath : AccountPath
    {
        public long TransactionSourceId { get; }

        public TransactionSourcePath(int accountId, long transactionSourceId) : base(accountId)
        {
            TransactionSourceId = transactionSourceId;
        }
    }
}

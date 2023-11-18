namespace Common.Models.Transactions
{
    public class TransactionSourceDto
    {
        public long Id {get; set; }
        public string Name { get; set; }
        public Dictionary<string, TransactionSourceInfo> InfoMap { get; set; }
    }
}

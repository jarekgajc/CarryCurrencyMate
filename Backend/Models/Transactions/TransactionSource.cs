using Common.Models.Transactions;
using Common.Utils;

namespace Backend.Models.Transactions
{
    public class TransactionSource
    {
        public long Id {get; set; }
        public required string Name { get; set; }
        public required string InfoMap { get; set; }

        public required List<Transaction> Transactions { get; set; }

        public TransactionSourceDto ToDto()
        {
            return new TransactionSourceDto
            {
                Id = Id,
                Name = Name,
                InfoMap = DictionaryUtils.FromString(InfoMap, key => key, Enum.Parse<TransactionSourceInfo>)
            };
        }

        public static TransactionSource FromDto(TransactionSourceDto dto)
        {
            return new TransactionSource()
            {
                Id = dto.Id,
                Name = dto.Name,
                InfoMap = DictionaryUtils.ToString(dto.InfoMap),
                Transactions = null!
            };
        }
    }
}

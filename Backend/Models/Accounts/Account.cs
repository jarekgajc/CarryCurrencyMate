using Backend.Models.Exchangers;
using Backend.Models.Observers;
using Backend.Models.Transactions;
using Backend.Models.Users;
using Common.Models.Accounts;

namespace Backend.Models.Accounts
{
    public class Account
    {
        public int Id { get; set; }

        public required User User { get; set; }
        public required List<Observer> Observers { get; set; }
        public required List<Exchanger> Exchangers { get; set; }
        public required List<TransactionSource> TransactionSources { get; set; }

        public AccountDto ToDto() {
            return new AccountDto
            {
                Id = Id,
            };
        }
    }
}

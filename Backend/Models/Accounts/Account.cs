using Backend.Models.Observers;
using Backend.Models.Users;
using Common.Models.Accounts;

namespace Backend.Models.Accounts
{
    public class Account
    {
        public int Id { get; set; }

        public required User User { get; set; }
        public required List<Observer> Observers { get; set; }

        public AccountDto ToDto() {
            return new AccountDto
            {
                Id = Id
            };
        }
    }
}

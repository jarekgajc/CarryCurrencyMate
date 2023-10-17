using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models.Accounts
{
    public class Account
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public AccountDto ToDto() {
            return new AccountDto
            {
                Id = Id
            };
        }
    }
}

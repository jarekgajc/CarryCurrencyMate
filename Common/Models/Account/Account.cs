using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models.Account
{
    public class Account
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}

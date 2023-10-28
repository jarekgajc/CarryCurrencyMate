using Common.Models.Accounts;
using Common.Models.Observations;

namespace Backend.Models.Accounts
{
    public class AccountPreference
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }

        public required int AccountId;
        public Account? Account { get; set; }

        public static AccountPreference FromDto(int accountId, AccountPreferenceDto dto)
        {
            return new AccountPreference
            {
                Id = dto.Id,
                Currency = dto.Currency,
                AccountId = accountId,
            };
        }

        public AccountPreferenceDto ToDto() {
            return new AccountPreferenceDto
            {
                Id = Id,
                Currency = Currency
            };
        }
    }
}

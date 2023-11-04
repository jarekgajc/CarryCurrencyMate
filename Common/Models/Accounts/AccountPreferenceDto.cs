using Common.Models.Observations;

namespace Common.Models.Accounts; 

public class AccountPreferenceDto : IIdHolder<int> {
    public int Id { get; set; }
    public Currency Currency { get; set; }
}
namespace Common.Models.Accounts; 

public class AccountPath {
    public int AccountId { get; }

    public AccountPath(int accountId)
    {
        AccountId = accountId;
    }
}
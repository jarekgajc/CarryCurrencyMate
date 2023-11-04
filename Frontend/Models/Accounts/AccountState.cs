using Common.Models.Accounts;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Models.Accounts
{
    public class AccountState : ObjectState<AccountDto, int>
    {
        protected override string BaseUrl => "api/accounts";
    }
}

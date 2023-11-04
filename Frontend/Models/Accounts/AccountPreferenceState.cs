using Common.Models.Accounts;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Models.Accounts
{
    public class AccountPreferenceState : ObjectState<AccountPreferenceDto, int>
    {
        protected override string BaseUrl => "api/accounts/preferences";
    }
}

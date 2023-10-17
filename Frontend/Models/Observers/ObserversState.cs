using Common.Models.Observers;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Models.Observers
{
    public class ObserversState : ObjectsState<ObserverDto, long>
    {
        protected override string BaseUrl => "api/observers";

        public ObserverDto? Default => Objects.FirstOrDefault();
    }
}

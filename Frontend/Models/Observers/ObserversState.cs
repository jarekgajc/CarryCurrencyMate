using Common.Models.Observers;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Models.Observers
{
    public class ObserversState : ObjectsState<Observer, long>
    {
        protected override string BaseUrl => "api/observers";

        public Observer? Default => Objects.FirstOrDefault();
    }
}

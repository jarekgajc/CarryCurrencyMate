
using Frontend.Models.RequestLoader;

namespace Frontend.Models.Observer
{
    //TODO: namespace do liczby mnogiej
    public class ObserversState : ObjectsStateEditor<Common.Models.Observer.Observer, long>
    {
        protected override string BaseUrl => "api/observers/";

        public Common.Models.Observer.Observer? Default => Objects.FirstOrDefault();

        public ObserversState(HttpClient httpClient, LoadRequest loadRequest) : base(httpClient, loadRequest)
        {
        }

    }
}

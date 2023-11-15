using Common.Models.Exchangers;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Models.Exchangers
{
    public class ExchangersState : ObjectsState<ExchangerDto, long>
    {
        protected override string BaseUrl => "api/exchangers";

        public ExchangerDto? Default => Objects.FirstOrDefault();
    }
}

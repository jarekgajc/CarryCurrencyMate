using Backend.Models.Exceptions;
using Backend.Models.Exchanges;
using Common.Models.Exchangers.Sources;
using Common.Models.Exchanges;
using Common.Models.Observations;
using Common.Models.Observers.Sources;
using Common.Models.Sources;

namespace Backend.Services.ExchangeServices
{
    public class ExchangeService : IExchangeService
    {
        public async Task CreateExchange(ExchangeRequest exchangeRequest)
        {
            try
            {
                await IExchangerSource.GetInstance(exchangeRequest.Exchanger.Source).RequestExchange(exchangeRequest);
            }
            catch (SourceClientException e)
            {
                throw new ApiException(e.ToApiError());
            }
        }
    }
}

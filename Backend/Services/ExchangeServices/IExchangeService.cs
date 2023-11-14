using Backend.Models.Exchanges;
using Common.Models.Exchanges;
using Common.Models.Observations;

namespace Backend.Services.ExchangeServices;

public interface IExchangeService
{
    Task CreateExchange(ExchangeRequest exchangeRequest);
}
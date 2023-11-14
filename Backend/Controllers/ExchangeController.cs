using Backend.Services.ObservationServices;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Observations;
using Microsoft.AspNetCore.Authorization;
using Common.Utils;
using Backend.Models.Exceptions;
using Common.Models.Error.Api;
using Common.Models.Exchanges;
using Backend.Services.ExchangeServices;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpPost]
        public async Task CreateExchange(ExchangeRequest exchangeRequest)
        {
            await _exchangeService.CreateExchange(exchangeRequest);
        }
    }
}

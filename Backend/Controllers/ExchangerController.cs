using Backend.Models.Exchangers;
using Backend.Services.ExchangerServices;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Common.Models.Exchangers;
using Common.Models.Observers;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/exchangers")]
    [ApiController]
    public class ExchangerController : ControllerBase
    {
        private readonly IExchangerService _exchangerService;

        public ExchangerController(IExchangerService exchangerService)
        {
            _exchangerService = exchangerService;
        }

        [HttpGet]
        public async Task<List<ExchangerDto>> GetExchangers()
        {
            return (await _exchangerService.GetExchangers(User.GetAccountId())).Select(exchanger => exchanger.ToDto()).ToList();
        }

        [HttpPost]
        public async Task<ExchangerDto> CreateExchanger(ExchangerDto exchanger)
        {
            return (await _exchangerService.CreateExchanger(User.GetAccountId(), Exchanger.FromDto(exchanger))).ToDto();
        }

        [HttpPut("{id}")]
        public async Task<ExchangerDto> UpdateExchanger(long id, ExchangerDto exchanger)
        {
            return (await _exchangerService.UpdateExchanger(User.GetAccountId(), id, Exchanger.FromDto(exchanger))).ToDto();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteExchanger(long id)
        {
            return await _exchangerService.DeleteExchanger(User.GetAccountId(), id);
        }
    }
}

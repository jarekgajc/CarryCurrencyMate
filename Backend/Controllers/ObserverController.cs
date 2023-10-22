using Backend.Services.ObserverServices;
using Backend.Models.Observers;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Common.Models.Observers;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/observers")]
    [ApiController]
    public class ObserverController : ControllerBase
    {
        private readonly IObserverService _observerService;

        public ObserverController(IObserverService observerService)
        {
            _observerService = observerService;
        }

        [HttpGet]
        public async Task<List<ObserverDto>> GetObservers()
        {
            return (await _observerService.GetObservers(User.GetAccountId())).Select(observer => observer.ToDto()).ToList();
        }

        [HttpPost]
        public async Task<ObserverDto> CreateObserver(ObserverDto observer)
        {
            return (await _observerService.CreateObserver(User.GetAccountId(), Observer.FromDto(observer))).ToDto();
        }

        [HttpPut("{id}")]
        public async Task<ObserverDto> UpdateObserver(long id, ObserverDto observer)
        {
            return (await _observerService.UpdateObserver(User.GetAccountId(), id, Observer.FromDto(observer))).ToDto();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteObserver(long id)
        {
            return await _observerService.DeleteObserver(User.GetAccountId(), id);
        }
    }
}

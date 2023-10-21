using Backend.Services.ObserverServices;
using Backend.Models.Observers;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<List<Observer>> GetObservers()
        {
            return await _observerService.GetObservers(User.GetAccountId());
        }

        [HttpPost]
        public async Task<Observer> CreateObserver(Observer observer)
        {
            return await _observerService.CreateObserver(User.GetAccountId(), observer);
        }

        [HttpPut("{id}")]
        public async Task<Observer> UpdateObserver(long id, Observer observer)
        {
            return await _observerService.UpdateObserver(User.GetAccountId(), id, observer);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteObserver(long id)
        {
            return await _observerService.DeleteObserver(User.GetAccountId(), id);
        }
    }
}

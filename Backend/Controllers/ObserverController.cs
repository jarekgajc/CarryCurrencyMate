using Backend.Services.ObserverService;
using Common.Models.Observer;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
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
            return await _observerService.GetObservers();
        }

        [HttpPost]
        public async Task<Observer> CreateObserver(Observer observer)
        {
            return await _observerService.CreateObserver(observer);
        }

        [HttpPut("{id}")]
        public async Task<Observer> UpdateObserver(long id, Observer observer)
        {
            return await _observerService.UpdateObserver(id, observer);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteObserver(long id)
        {
            return await _observerService.DeleteObserver(id);
        }
    }
}

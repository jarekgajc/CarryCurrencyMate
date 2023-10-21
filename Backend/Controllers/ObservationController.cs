using Backend.Services.ObservationServices;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Observations;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/observations")]
    [ApiController]
    public class ObservationController : ControllerBase
    {
        private readonly IObservationService _observationService;

        public ObservationController(IObservationService observationService)
        {
            _observationService = observationService;
        }

        [HttpGet]
        public async Task<Observation> GetObservation([FromQuery] ObservationQuery query)
        {
            return await _observationService.GetObservation(query);
        }
    }
}

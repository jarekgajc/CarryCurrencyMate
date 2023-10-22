using Backend.Services.ObservationServices;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Observations;
using Microsoft.AspNetCore.Authorization;
using Common.Utils;
using Backend.Models.Exceptions;
using Common.Models.Error.Api;

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
        public async Task<Observation> GetObservation(string q)
        {
            ObservationQuery query = Base64Utils.ToObject<ObservationQuery>(q) ?? throw new ApiException(new ResourceDoesNotExist());
            return await _observationService.GetObservation(query);
        }
    }
}

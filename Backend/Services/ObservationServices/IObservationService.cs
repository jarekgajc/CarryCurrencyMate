
using Common.Models.Observations;

namespace Backend.Services.ObservationServices
{
    public interface IObservationService
    {
        Task<Observation> GetObservation(ObservationQuery query);
    }
}
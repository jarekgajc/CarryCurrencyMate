using Backend.Models.Exceptions;
using Common.Models.Observations;
using Common.Models.Observers.Sources;
using Common.Models.Sources;

namespace Backend.Services.ObservationServices
{
    public class ObservationService : IObservationService
    {
        public async Task<Observation> GetObservation(ObservationQuery query)
        {
            try
            {
                return await IObserverSource.GetInstance(query.Observer.Source).GetObservation(query);
            }
            catch (SourceClientException e)
            {
                throw new ApiException(e.ToApiError());
            }
        }
    }
}

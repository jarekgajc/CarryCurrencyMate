using Common.Models.Observations;
using Common.Models.Sources.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observers.Sources
{
    public interface IObserverSource
    {
        SourceAuthType SourceAuthType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <exception cref="SourceClientException">Thrown if anything fails</exception>
        /// <returns></returns>
        Task<Observation> GetObservation(ObservationQuery query);

        public static IObserverSource GetInstance(ObservationSource source)
        {
            return source switch
            {
                ObservationSource.Walutomat => new Walutomat(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}

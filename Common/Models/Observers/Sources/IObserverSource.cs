using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observers.Sources
{
    public interface IObserverSource
    {
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

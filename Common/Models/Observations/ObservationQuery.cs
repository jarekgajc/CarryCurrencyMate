using Common.Models.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observations
{
    public class ObservationQuery
    {
        public required Currency BaseCurrency { get; set; }
        public required List<Currency> Currencies { get; set; }
        public required TimeRange TimeRange { get; set; }
        public required ObserverDto Observer { get; set; }

        public Observation ToBaseObservation()
        {
            return new Observation {
                BaseCurrency = BaseCurrency,
                ExchangeRates = new List<ExchangeRate>()
            };
        }
    }

    public enum TimeRange
    {
        HOUR, DAY, WEEK, MONTH, YEAR
    }
}

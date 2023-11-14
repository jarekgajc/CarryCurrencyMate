using Common.Models.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Exchangers;

namespace Common.Models.Observations
{
    public class ObservationQuery
    {
        public required Currency BaseCurrency { get; set; }
        public required List<Currency> Currencies { get; set; }
        public required TimeRange TimeRange { get; set; }
        public required ObserverDto Observer { get; set; }

        public Observation ToObservationBase()
        {
            return new Observation {
                BaseCurrency = BaseCurrency,
                ExchangeRates = new List<ExchangeRate>()
            };
        }
    }

    public enum TimeRange
    {
        CURRENT, HOUR, DAY, WEEK, MONTH, YEAR
    }
}

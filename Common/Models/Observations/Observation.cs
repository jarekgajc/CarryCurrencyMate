using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observations
{
    public class Observation
    {
        public Currency BaseCurrency { get; set; }
        public required List<ExchangeRate> ExchangeRates { get; set; }
    }

    public class ExchangeRate
    {
        public Currency Currency { get; set; }
        public required List<ExchangeRateValue> Values { get; set; }
    }
    
    public class ExchangeRateValue
    {
        public decimal Avg { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public required DateTime Time { get; set; }
    }

    public class ObservationTableData
    {
        public Row[] Rows { get; set; }
        public ObservationTableData(Observation observation) {
            Rows = observation.ExchangeRates
                .SelectMany(exchangeRate => exchangeRate.Values.Select(value => new Row
                {
                    Currency = exchangeRate.Currency,
                    Buy = value.Buy,
                    Sell = value.Sell
                })).ToArray();
        }

        public class Row
        {
            public required Currency Currency { get; set; }
            public required decimal Buy { get; set; }
            public required decimal Sell { get; set; }
        }
    }

    public enum Currency : short
    {
        USD, EUR, PLN
    }
}

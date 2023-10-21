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
        public DateTime Time { get; set; }
    }

    public enum Currency
    {
        USD, EUR, PLN
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    public class CurrentExchangeRateResult
    {
        public required DateTime Ts { get; set; }
        public required string CurrencyPair { get; set; }
        public required string BuyRate { get; set; }
        public required string SellRate { get; set; }
    }
}

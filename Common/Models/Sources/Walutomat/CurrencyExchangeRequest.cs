using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    //"currencyPair=EURPLN&buySell=SELL&volume=90.00&volumeCurrency=EUR&submitId=test107&ts=2018-10-08T13:15:00.000Z"
    public class CurrencyExchangeRequest
    {
        public required bool DryRun { get; set; }
        public string? SubmitId { get; set; }
        public required string CurrencyPair { get; set; }
        public required string BuySell { get; set; }
        public required string Volume { get; set; }
        public required string VolumeCurrency { get; set; }
        public required DateTime Ts { get; set; }
    }
}

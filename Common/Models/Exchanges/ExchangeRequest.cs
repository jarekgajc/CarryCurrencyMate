using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Exchangers;
using Common.Models.Observations;
using Common.Models.Observers;

namespace Common.Models.Exchanges
{
    public class ExchangeRequest
    {
        public required ExchangeType Type { get; set; }
        public required Currency From { get; set; }
        public required Currency To { get; set; }
        public required decimal Value { get; set; }
        public required ExchangerDto Exchanger { get; set; }
        public DateTime Timestamp { get; set; }
        public required bool DryRun { get; set; }
    }
}

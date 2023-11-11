using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Observations;

namespace Common.Models.Exchanges
{
    public class ExchangeDto
    {
        public required Currency From { get; set; }
        public required Currency To { get; set; }
        public long ObserverId { get; set; }
        public required decimal Value { get; set; }
        public required long Timestamp { get; set; }
    }
}

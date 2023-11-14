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
        public string Id { get; set; } = string.Empty;
        public required string SourceId { get; set; }
        public required Volume From { get; set; }
        public required Volume To { get; set; }
        public required long ExchangerId { get; set; }
        public required long Timestamp { get; set; }
    }
}

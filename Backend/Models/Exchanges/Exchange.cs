using Backend.Models.Exchangers;
using Backend.Models.Observers;
using Backend.Models.Sources.Auths;
using Common.Models;
using Common.Models.Exchangers;
using Common.Models.Exchanges;
using Elfie.Serialization;
using Humanizer;

namespace Backend.Models.Exchanges
{
    public class Exchange
    {
        public string Id { get; set; } = string.Empty;
        public required string SourceId { get; set; }
        public required Volume From { get; set; }
        public required Volume To { get; set; }
        public required long Timestamp { get; set; }

        public required long ExchangerId { get; set; }
        public Exchanger? Exchanger { get; set; }

        public static Exchange FromDto(ExchangeDto dto)
        {
            return new Exchange()
            {
                Id = dto.Id,
                SourceId = dto.SourceId,
                From = dto.From,
                To = dto.To,
                Timestamp = dto.Timestamp,
                ExchangerId = dto.ExchangerId
            };
        }

        public ExchangeDto ToDto()
        {
            return new ExchangeDto()
            {
                Id = Id,
                SourceId = SourceId,
                From = From,
                To = To,
                Timestamp = Timestamp,
                ExchangerId = ExchangerId
            };
        }
    }
}

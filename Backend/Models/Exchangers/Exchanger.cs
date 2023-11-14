using Backend.Models.Observers;
using Backend.Models.Sources.Auths;
using Common.Models.Exchangers;
using Common.Models.Observers;

namespace Backend.Models.Exchangers
{
    public class Exchanger
    {
        public long Id { get; set; }
        public required ExchangeSource Source { get; set; }
        public required SourceAuth SourceAuth { get; set; }

        public void Update(Exchanger other)
        {
            Source = other.Source;
            SourceAuth.Update(other.SourceAuth);
        }

        public static Exchanger FromDto(ExchangerDto dto)
        {
            return new Exchanger
            {
                Id = dto.Id,
                Source = dto.Source,
                SourceAuth = SourceAuth.FromDto(dto.SourceAuth)
            };
        }

        public ExchangerDto ToDto()
        {
            return new ExchangerDto
            {
                Id = Id,
                Source = Source,
                SourceAuth = SourceAuth.ToDto()
            };
        }
    }
}

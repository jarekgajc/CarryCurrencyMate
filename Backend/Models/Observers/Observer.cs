using Backend.Models.Accounts;
using Backend.Models.Sources.Auths;
using Common.Models.Observers;

namespace Backend.Models.Observers;

public class Observer
{
    public long Id { get; set; }
    public required ObservationSource Source { get; set; }
    public required SourceAuth SourceAuth { get; set; }

    public void Update(Observer other)
    {
        Source = other.Source;
        SourceAuth.Update(other.SourceAuth);
    }

    public static Observer FromDto(ObserverDto dto)
    {
        return new Observer
        {
            Id = dto.Id,
            Source = dto.Source,
            SourceAuth = SourceAuth.FromDto(dto.SourceAuth)
        };
    }

    public ObserverDto ToDto() {
        return new ObserverDto
        {
            Id = Id,
            Source = Source,
            SourceAuth = SourceAuth.ToDto()
        };
    }
}

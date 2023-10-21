using Backend.Models.Accounts;
using Backend.Models.Sources.Auths;
using Common.Models.Observers;

namespace Backend.Models.Observers;

public class Observer
{
    public long Id { get; set; }
    public required ObservationSource Source { get; set; }
    public required SourceAuth SourceAuth { get; set; }

    public ObserverDto ToDto() {
        return new ObserverDto
        {
            Id = Id,
            Source = Source,
            SourceAuth = SourceAuth.ToDto()
        };
    }
}

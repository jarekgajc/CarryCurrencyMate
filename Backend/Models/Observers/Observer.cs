using Backend.Models.Sources.Auths;
using Common.Models.Observers;

namespace Backend.Models.Observers;

public class Observer
{
    //TODO: should have connection to Account
    public long Id { get; set; }
    public ObservationSource Source { get; set; }
    public SourceAuth SourceAuth { get; set; } = new SourceAuth();

    public ObserverDto ToDto() {
        return new ObserverDto
        {
            Id = Id,
            Source = Source,
            SourceAuth = SourceAuth.ToDto()
        };
    }
}

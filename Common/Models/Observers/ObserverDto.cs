using Common.Models.Sources.Auths;

namespace Common.Models.Observers; 

public class ObserverDto : IIdHolder<long>, ISourceAuthHolder
{
    public long Id { get; set; }
    public ObservationSource Source { get; set; }
    public SourceAuthDto SourceAuth { get; set; } = new SourceAuthDto();
}
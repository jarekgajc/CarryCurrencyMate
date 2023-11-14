using Common.Models.Sources.Auths;

namespace Common.Models.Exchangers; 

public class ExchangerDto : IIdHolder<long>, ISourceAuthHolder
{
    public long Id { get; set; }
    public ExchangeSource Source { get; set; }
    public SourceAuthDto SourceAuth { get; set; } = new SourceAuthDto();
}
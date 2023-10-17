using Common.Models.Sources.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observers;

public class Observer : IIdHolder<long>, ISourceAuthHolder
{
    //TODO: should have connection to Account
    public long Id { get; set; }
    public ObservationSource Source { get; set; }
    public SourceAuth SourceAuth { get; set; } = new SourceAuth();
}

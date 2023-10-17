using Common.Models.Sources.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observers.Sources
{
    internal class Walutomat : IObserverSource
    {
        public SourceAuthType SourceAuthType => SourceAuthType.ApiKey;
    }
}

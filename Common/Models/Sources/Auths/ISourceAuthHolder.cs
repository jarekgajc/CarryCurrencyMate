using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Auths
{
    public interface ISourceAuthHolder
    {
        SourceAuth SourceAuth { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Auths
{
    public class SourceAuth
    {
        public long Id { get; set; }
        //TODO: encrypt it
        public string? ApiKey { get; set; }
    }
}

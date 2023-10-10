using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observer;

public class Observer
{
    //TODO: should have connection to Account
    public long Id { get; set; }
    public ObservationSource Source { get; set; }
}

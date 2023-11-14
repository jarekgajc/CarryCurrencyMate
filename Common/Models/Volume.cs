using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Observations;

namespace Common.Models
{
    public class Volume
    {
        public Currency Currency { get; set; }
        public decimal Value { get; set; }
    }
}

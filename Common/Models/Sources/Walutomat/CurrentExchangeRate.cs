using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    public class CurrentExchangeRate
    {
        public bool success { get; set; }
        public required Result result { get; set; }

        public class Result
        {
            public required DateTime ts { get; set; }
            public required string currencyPair { get; set; }
            public required string buyRate { get; set; }
            public required string sellRate { get; set; }
        }

    }
}

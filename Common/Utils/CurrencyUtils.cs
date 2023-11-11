using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Observations;

namespace Common.Utils
{
    public static class CurrencyUtils
    {
        public static bool FromPair(string pair, out Currency from, out Currency to)
        {
            return Enum.TryParse(pair[..3], out from) & Enum.TryParse(pair[3..3], out to);
        }

        public static string ToPair(Currency from, Currency to)
        {
            return $"{from}{to}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Observations;

namespace Common.Utils
{
    public static class DecimalUtils
    {
        public static string Prettify(this decimal value)
        {
            return value.ToString("0.00");
        }
    }
}

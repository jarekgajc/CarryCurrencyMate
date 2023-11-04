using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class EnumUtils
    {
        public static List<T> GetList<T>()
        {
            return ((T[])Enum.GetValues(typeof(T))).ToList();
        }
    }
}

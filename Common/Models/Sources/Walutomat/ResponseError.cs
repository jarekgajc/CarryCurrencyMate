using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    internal class ResponseError
    {
        public required string Key { get; set; }
        public required string Description { get; set; }
        public required List<Data> ErrorData { get; set; }

        public class Data
        {
            public required string Key { get; set; }
            public required string Value { get; set; }
        }
    }
}

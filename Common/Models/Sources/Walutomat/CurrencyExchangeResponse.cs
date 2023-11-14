using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    internal class CurrencyExchangeResponse : IResponse
    {
        public bool Success { get; set; }
        public List<ResponseError>? Errors { get; set; }
        public CurrencyExchangeResult? Result { get; set; }
    }
}

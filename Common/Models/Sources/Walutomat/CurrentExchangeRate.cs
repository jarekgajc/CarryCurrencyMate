using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    //"{\"success\":false,\"errors\":[{\"key\":\"CURRENCY_NOT_SUPPORTED\",\"description\":\"Unsupported currency pair.\",\"errorData\":[]}]}"
    internal class CurrentExchangeRate : IResponse
    {
        public bool Success { get; set; }
        public List<ResponseError>? Errors { get; set; }
        public CurrentExchangeRateResult? Result { get; set; }
    }
}

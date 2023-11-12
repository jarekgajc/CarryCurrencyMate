using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    //"{\"success\":false,\"errors\":[{\"key\":\"CURRENCY_NOT_SUPPORTED\",\"description\":\"Unsupported currency pair.\",\"errorData\":[]}]}"
    public class CurrencyExchangeRequest
    {
        public bool success { get; set; }
        public List<Error>? errors { get; set; }
        public Result? result { get; set; }

        public List<string>? GetErrorsDescriptions()
        {
            if (errors == null)
                return null;

            return errors.Select(error  => error.description.ToString()).ToList();
        }

        public class Result
        {
            public required DateTime ts { get; set; }
            public required string currencyPair { get; set; }
            public required string buyRate { get; set; }
            public required string sellRate { get; set; }
        }

        public class Error
        {
            public required string key { get; set; }
            public required string description { get; set; }
            public required List<Data> errorData { get; set; }

            public class Data
            {
                public required string key { get; set; }
                public required string value { get; set; }
            }
        }

    }
}

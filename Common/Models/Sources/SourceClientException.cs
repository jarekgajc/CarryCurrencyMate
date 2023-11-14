using Common.Models.Error.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources
{
    public class SourceClientException : Exception
    {
        public List<string>? Errors { get; set; }

        public SourceClientException(List<string>? errors)
        {
            Errors = errors;
        }

        public SourceClientException(string error)
        {
            Errors = new List<string> {error};
        }

        public SourceClientException() {}

        public SourceClientException(HttpResponseMessage response)
        {
        }

        public ApiError ToApiError()
        {
            if(Errors != null)
            {
                return new SourceErrorThrown(Errors);
            }
            return new ConnectionToSourceFailed();
        }
    }
}

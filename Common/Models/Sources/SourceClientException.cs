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

        public SourceClientException() {}

        public SourceClientException(HttpResponseMessage response)
        {
        }

        public ApiError ToApiError()
        {
            return new ConnectionToSourceFailed();
        }
    }
}

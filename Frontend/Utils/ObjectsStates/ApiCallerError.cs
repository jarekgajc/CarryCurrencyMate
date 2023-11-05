using System.Net;
using Common.Models.Error.Api;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCallerError
    {
        public string Message { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public ApiError? ApiError { get; set; }


        public ApiCallerError(string message)
        {
            Message = message;
        }
    }
}

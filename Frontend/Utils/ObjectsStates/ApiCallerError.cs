using System.Net;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCallerError
    {
        public string Message { get; set; }
        public HttpStatusCode? StatusCode { get; set; }


        public ApiCallerError(string message)
        {
            Message = message;
        }
    }
}

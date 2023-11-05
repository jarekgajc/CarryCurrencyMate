using Common.Models;
using Common.Models.Error.Api;
using Frontend.Utils.ObjectsStates;
using MudBlazor;
using System.Net;
using System.Net.Http.Json;

namespace Frontend.Models.RequestLoaders
{
    public class RequestLoadController
    {
        public required Action OnStart { get; set; }
        public required Action<object> OnComplete { get; set; }
        public required Action<ApiCallerError> OnFail { get; set; }
    }
}

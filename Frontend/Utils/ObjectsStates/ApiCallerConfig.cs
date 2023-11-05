using Common.Models;
using Frontend.Models.RequestLoaders;
using System.Net.Http.Json;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCallerConfig
    {
        public bool Background { get; set; }
        public event Action? OnStart;
        public event Action<object>? OnComplete;
        public event Action<ApiCallerError>? OnFail;

        public void InvokeStart()
        {
            OnStart?.Invoke();
        }

        public void InvokeComplete(object response)
        {
            OnComplete?.Invoke(response);
        }

        public void InvokeFail(ApiCallerError error)
        {
            OnFail?.Invoke(error);
        }

        public ApiCallerConfig AddOnFail(Action<ApiCallerError> onFail)
        {
            OnFail += onFail;
            return this;
        }
    }
}

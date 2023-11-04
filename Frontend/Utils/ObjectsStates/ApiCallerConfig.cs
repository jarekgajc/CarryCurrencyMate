using Common.Models;
using Frontend.Models.RequestLoaders;
using System.Net.Http.Json;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCallerConfig<T>
    {
        public bool Background { get; set; }
        public event Action<T>? OnComplete;
        public event Action<ApiCallerError>? OnFail;

        public void InvokeComplete(T response)
        {
            OnComplete?.Invoke(response);
        }

        public void InvokeFail(ApiCallerError error)
        {
            OnFail?.Invoke(error);
        }
    }
}

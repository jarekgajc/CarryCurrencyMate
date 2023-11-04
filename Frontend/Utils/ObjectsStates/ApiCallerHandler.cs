using Common.Models;
using Common.Models.Error.Api;
using Frontend.Models.RequestLoaders;
using MudBlazor;
using System.Net;
using System.Net.Http.Json;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCallerHandler<T> where T : class
    {
        private readonly ApiCallerConfig<T> _config;

        public ApiCallerHandler(ApiCallerConfig<T>? config)
        {
            _config = config ?? new ApiCallerConfig<T>();
        }

        public async Task<T?> HandleResponse(Func<Task<HttpResponseMessage>> load)
        {
            //TODO: LoadRequest powinien subskrybować onComplete i onFail
            //TODO: use proper loader if load background
            HttpResponseMessage? response = await LoadRequest(load);
            if (response == null)
                return null;

            T? result = await response.Content.ReadFromJsonAsync<T>();
            if (result != null)
            {
                _config.InvokeComplete(result);
            }
            return result;
        }

        private async Task<HttpResponseMessage?> LoadRequest(Func<Task<HttpResponseMessage>> load)
        {
            try
            {
                // await Task.Delay(3000);
                HttpResponseMessage? response = await load();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return response;
                    case HttpStatusCode.NoContent:
                        return null;
                    case HttpStatusCode.BadRequest:
                    {
                        var apiError = await response.Content.ReadFromJsonAsync<ApiError>();
                        if (apiError != null)
                        {
                            ShowError(new ApiCallerError(apiError.Code.ToString()));
                            return null;
                        }

                        break;
                    }
                }

                ShowHttpStatusCodeError(response.StatusCode);
            } catch (HttpRequestException e)
            {
                if (e.StatusCode != null)
                {
                    ShowHttpStatusCodeError(e.StatusCode);
                } else
                {
                    ShowError(new ApiCallerError("Something went wrong"));
                }
            }

            return null;
        }

        private void ShowHttpStatusCodeError(HttpStatusCode? httpStatusCode)
        {
            if (httpStatusCode != null)
            {
                ShowError(new ApiCallerError("Http request failed: " + httpStatusCode)
                {
                    StatusCode = httpStatusCode
                });
            } else
            {
                ShowError(new ApiCallerError("Something went wrong"));
            }
        }

        private void ShowError(ApiCallerError error)
        {
            _config.InvokeFail(error);
        }
    }
}

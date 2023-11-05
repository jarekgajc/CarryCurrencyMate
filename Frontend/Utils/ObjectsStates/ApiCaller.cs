using Common.Models;
using Common.Models.Error.Api;
using Frontend.Models.RequestLoaders;
using MudBlazor;
using System.Net;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCaller : IRequestLoader
    {
        public string BaseUrl { get; set; }
        public HttpClient HttpClient { get; set; } = default!;
        public RequestLoadController RequestLoadController { get; set; }

        public ApiCaller(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public async Task<T?> GetItem<T, TId>(TId id, ApiCallerConfig? config = null) where T : class
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetObject<T>(() => HttpClient.GetAsync($"/{BaseUrl}/{id}"));
        }

        public async Task<T?> GetItems<T>(ApiCallerConfig? config = null) where T : class
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetObject<T>(() => HttpClient.GetAsync($"/{BaseUrl}"));
        }

        public async Task<T?> CreateItem<T>(T item, ApiCallerConfig? config = null) where T : class
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetObject<T>(() => HttpClient.PostAsJsonAsync($"/{BaseUrl}", item));
        }

        public async Task<T?> UpdateItem<T, TId>(T item, ApiCallerConfig? config = null) where T : class, IIdHolder<TId>
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetObject<T>(() => HttpClient.PutAsJsonAsync($"/{BaseUrl}/{item.Id}", item));
        }

        public async Task<bool> DeleteItem()
        {
            throw new NotImplementedException();
            //var response = await RequestLoadController(() => HttpClient.DeleteAsync($"/{BaseUrl}/{id}"));
            //if (response == null || bool.Parse(await response.Content.ReadAsStringAsync()))
            //    return false;
            //onSuccess(id);
            return true;
        }


        public async Task<HttpResponseMessage?> Post<T>(T body, ApiCallerConfig? config = null)
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetResponse(() => HttpClient.PostAsJsonAsync($"/{BaseUrl}", body));
        }

        public async Task<HttpResponseMessage?> Get(ApiCallerConfig? config = null)
        {
            return await new ApiCallerHandler(RequestLoadController, config).GetResponse(() => HttpClient.GetAsync($"/{BaseUrl}"));
        }
    }
}

using Common.Models;
using Common.Models.Error.Api;
using Frontend.Models.RequestLoaders;
using MudBlazor;
using System.Net;
using System.Net.Http.Json;

namespace Frontend.Utils.ObjectsStates
{
    public class ApiCaller<TItem, TId> : IRequestLoader where TItem : class, IIdHolder<TId>, new()
    {
        public required string BaseUrl { get; set; }
        public HttpClient HttpClient { get; set; } = default!;
        public LoadRequest LoadRequest { get; set; } = default!;

        public async Task<T?> GetItem<T>(TId id, ApiCallerConfig<T>? config = null) where T : class
        {
            return await new ApiCallerHandler<T>(config).HandleResponse(() => HttpClient.GetAsync($"/{BaseUrl}/{id}"));
        }

        public async Task<T?> GetItems<T>(ApiCallerConfig<T>? config = null) where T : class
        {
            return await new ApiCallerHandler<T>(config).HandleResponse(() => HttpClient.GetAsync($"/{BaseUrl}"));
        }

        public async Task<T?> CreateItem<T>(T item, ApiCallerConfig<T>? config = null) where T : class
        {
            return await new ApiCallerHandler<T>(config).HandleResponse(() => HttpClient.PostAsJsonAsync($"/{BaseUrl}", item));
        }

        public async Task<T?> UpdateItem<T>(T item, ApiCallerConfig<T>? config = null) where T : class, IIdHolder<TId>
        {
            return await new ApiCallerHandler<T>(config).HandleResponse(() => HttpClient.PutAsJsonAsync($"/{BaseUrl}/{item.Id}", item));
        }

        public async Task<bool> DeleteItem(TId id, Action<TId> onSuccess)
        {
            throw new NotImplementedException();
            //var response = await LoadRequest(() => HttpClient.DeleteAsync($"/{BaseUrl}/{id}"));
            //if (response == null || bool.Parse(await response.Content.ReadAsStringAsync()))
            //    return false;
            //onSuccess(id);
            return true;
        }

        

    }
}

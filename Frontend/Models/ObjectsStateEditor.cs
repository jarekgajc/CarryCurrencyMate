using Common.Models;
using Frontend.Models.RequestLoader;
using System.Net.Http.Json;

namespace Frontend.Models
{
    public abstract class ObjectsStateEditor<TObject, TId> where TObject : IIdHolder<TId>
    {
        private List<TObject>? _objects;
        private readonly HttpClient _httpClient;
        private readonly LoadRequest _loadRequest;

        protected abstract string BaseUrl { get; }

        public List<TObject> Objects => _objects ??= new List<TObject>();

        public ObjectsStateEditor(HttpClient httpClient, LoadRequest loadRequest)
        {
            _httpClient = httpClient;
            _loadRequest = loadRequest;
        }

        public async Task<bool> GetObjects()
        {
            var response = await _loadRequest(() => _httpClient.GetAsync($"/{BaseUrl}"));
            if(response == null)
                return false;
            _objects = (await response.Content.ReadFromJsonAsync<List<TObject>>())!;
            return true;
        }

        public async Task<bool> CreateObject(TObject obj)
        {
            var response = await _loadRequest(() => _httpClient.PostAsJsonAsync($"/{BaseUrl}", obj));
            if (response == null)
                return false;
            _objects.Add((await response.Content.ReadFromJsonAsync<TObject>())!);
            return true;
        }

        public async Task<bool> UpdateObject(TObject obj)
        {
            var response = await _loadRequest(() => _httpClient.PutAsJsonAsync($"/{BaseUrl}/{obj.Id}", obj));
            if (response == null)
                return false;
            int index = _objects.FindIndex(o => o.Id.Equals(obj.Id));
            _objects[index] = (await response.Content.ReadFromJsonAsync<TObject>())!;
            return true;
        }

        public async Task<bool> DeleteObject(TId id)
        {
            var response = await _loadRequest(() => _httpClient.DeleteAsync($"/{BaseUrl}/{id}"));
            if (response == null || bool.Parse(await response.Content.ReadAsStringAsync()))
                return false;
            return true;
        }

    }
    
}

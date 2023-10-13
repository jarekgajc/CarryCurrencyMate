using Common.Models;
using Frontend.Models.RequestLoaders;
using System.Net.Http.Json;

namespace Frontend.Utils.ObjectsStates
{
    public abstract class ObjectsState<TObject, TId> : IRequestLoader where TObject : IIdHolder<TId>
    {
        private List<TObject>? _objects;

        protected abstract string BaseUrl { get; }
        
        public HttpClient HttpClient { get; set; }
        public LoadRequest LoadRequest { get; set; }

        public bool Valid { get; private set; }
        public List<TObject> Objects => _objects ??= new List<TObject>();

        public async Task<bool> GetObjects()
        {
            var response = await LoadRequest(() => HttpClient.GetAsync($"/{BaseUrl}"));
            if(response == null)
                return false;
            _objects = (await response.Content.ReadFromJsonAsync<List<TObject>>())!;
            Valid = true;
            return true;
        }

        public async Task<bool> CreateObject(TObject obj)
        {
            var response = await LoadRequest(() => HttpClient.PostAsJsonAsync($"/{BaseUrl}", obj));
            if (response == null)
                return false;
            _objects.Add((await response.Content.ReadFromJsonAsync<TObject>())!);
            return true;
        }

        public async Task<bool> UpdateObject(TObject obj)
        {
            var response = await LoadRequest(() => HttpClient.PutAsJsonAsync($"/{BaseUrl}/{obj.Id}", obj));
            if (response == null)
                return false;
            int index = _objects.FindIndex(o => o.Id.Equals(obj.Id));
            _objects[index] = (await response.Content.ReadFromJsonAsync<TObject>())!;
            return true;
        }

        public async Task<bool> DeleteObject(TId id)
        {
            var response = await LoadRequest(() => HttpClient.DeleteAsync($"/{BaseUrl}/{id}"));
            if (response == null || bool.Parse(await response.Content.ReadAsStringAsync()))
                return false;
            return true;
        }

    }
    
}

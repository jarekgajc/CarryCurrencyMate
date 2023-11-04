using Frontend.Models.RequestLoaders;

namespace Frontend.Shared.Providers; 

public class ObjectsStateFactory {
    private readonly HttpClient _httpClient;

    public ObjectsStateFactory(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public T Create<T>(LoadRequest loadRequest) where T : IRequestLoaderHolder, new() {
        T result = new T();
        result.RequestLoader.HttpClient = _httpClient;
        result.RequestLoader.LoadRequest = loadRequest;
        return result;
    }
}
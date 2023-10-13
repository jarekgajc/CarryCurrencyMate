using Frontend.Models.RequestLoaders;

namespace Frontend.Shared.Providers; 

public class ObjectsStateFactory {
    private readonly HttpClient _httpClient;

    public ObjectsStateFactory(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public T Create<T>(LoadRequest? loadRequest) where T : IRequestLoader, new() {
        T result = new T();
        result.HttpClient = _httpClient;
        result.LoadRequest = loadRequest;
        return result;
    }
}
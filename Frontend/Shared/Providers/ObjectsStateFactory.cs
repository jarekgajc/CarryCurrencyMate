using Frontend.Models.RequestLoaders;

namespace Frontend.Shared.Providers;

public class ObjectsStateFactory {
    private readonly HttpClient _httpClient;

    public ObjectsStateFactory(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public T Create<T>(RequestLoadController requestLoadController) where T : IRequestLoaderHolder, new() {
        T result = new T();
        result.RequestLoader.HttpClient = _httpClient;
        result.RequestLoader.RequestLoadController = requestLoadController;
        return result;
    }
}
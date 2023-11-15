using Frontend.Models.RequestLoaders;

namespace Frontend.Shared.Providers;

public class ObjectsStateFactory
{
    private readonly HttpClient _httpClient;
    private readonly Dictionary<Type, object> _cachedObjectsStates = new Dictionary<Type, object>();

    public ObjectsStateFactory(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public T Create<T>(RequestLoadController requestLoadController) where T : IRequestLoaderHolder, new()
    {
        T result = new T();
        return SetRequestLoaderHolderValues(result, requestLoadController);
    }

    private T SetRequestLoaderHolderValues<T>(T objectsState, RequestLoadController requestLoadController) where T : IRequestLoaderHolder
    {
        objectsState.RequestLoader.HttpClient = _httpClient;
        objectsState.RequestLoader.RequestLoadController = requestLoadController;
        return objectsState;
    }

    public T CreateOrGetCached<T>(RequestLoadController requestLoadController) where T : IRequestLoaderHolder, new()
    {
        Type type = typeof(T);
        T result = _cachedObjectsStates.TryGetValue(type, out object? cachedObjectsState) ? (T) cachedObjectsState : new T();
        _cachedObjectsStates[type] = result;
        return SetRequestLoaderHolderValues(result, requestLoadController);
    }
}
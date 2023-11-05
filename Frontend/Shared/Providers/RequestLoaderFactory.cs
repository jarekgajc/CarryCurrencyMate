using Frontend.Models.RequestLoaders;
using Frontend.Utils.ObjectsStates;

namespace Frontend.Shared.Providers;

public class RequestLoaderFactory {
    private readonly HttpClient _httpClient;

    public RequestLoaderFactory(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public ApiCaller CreateApiCaller(string baseUrl, RequestLoadController requestLoadController)
    {
        ApiCaller apiCaller = new ApiCaller(baseUrl)
        {
            RequestLoadController = requestLoadController,
            HttpClient = _httpClient
        };
        return apiCaller;
    }
}
using Common.Models.Error.Api;

namespace Frontend.Models.RequestLoaders; 

public delegate Task<HttpResponseMessage?> LoadRequest(Func<Task<HttpResponseMessage>> load, Action<ApiError>? onFail = null);
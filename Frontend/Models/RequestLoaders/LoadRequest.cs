namespace Frontend.Models.RequestLoaders; 

public delegate Task<HttpResponseMessage?> LoadRequest(Func<Task<HttpResponseMessage>> load);
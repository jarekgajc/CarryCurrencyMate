namespace Frontend.Models.RequestLoader; 

public delegate Task<HttpResponseMessage?> LoadRequest(Func<Task<HttpResponseMessage>> load);
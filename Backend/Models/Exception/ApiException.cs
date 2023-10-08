using Common.Models.Error.Api;

namespace Backend.Models.Exception; 

public class ApiException : System.Exception {
    public ApiError ApiError { get; }

    public ApiException(ApiError apiError) {
        ApiError = apiError;
    }
}
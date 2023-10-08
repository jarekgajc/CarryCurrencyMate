namespace Common.Models.Error.Api; 

public class ApiError {
    public ApiErrorCode Code { get; }
    public string? Data { get; protected set; }

    public ApiError()
    {
    }

    protected ApiError(ApiErrorCode code)
    {
        Code = code;
    }
}
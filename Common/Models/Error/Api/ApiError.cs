namespace Common.Models.Error.Api; 

public class ApiError {
    public ApiErrorCode Code { get; set; }
    public string? Data { get; set; }

    public ApiError()
    {
    }

    protected ApiError(ApiErrorCode code)
    {
        Code = code;
    }
}
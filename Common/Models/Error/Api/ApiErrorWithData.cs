using System.Text.Json;

namespace Common.Models.Error.Api; 

public abstract class ApiErrorWithData<T> : ApiError {
    protected ApiErrorWithData(ApiErrorCode code, T data) : base(code) {
        Data = JsonSerializer.Serialize(data);
    }
}
namespace Common.Models.Error.Api; 

public class ConnectionToSourceFailed : ApiError {
    public new const ApiErrorCode Code = ApiErrorCode.ConnectionToSourceFailed;
    
    public ConnectionToSourceFailed() : base(Code) {
    }
}
namespace Common.Models.Error.Api; 

public class CredentialsNotFound : ApiError {
    public new const ApiErrorCode Code = ApiErrorCode.CredentialsNotFound;
    
    public CredentialsNotFound() : base(Code) {
    }
}
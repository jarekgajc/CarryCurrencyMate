namespace Common.Models.Error.Api; 

public class ResourceDoesNotExist : ApiError {
    public new const ApiErrorCode Code = ApiErrorCode.ItemDoesNotExist;
    
    public ResourceDoesNotExist() : base(Code) {
    }
}
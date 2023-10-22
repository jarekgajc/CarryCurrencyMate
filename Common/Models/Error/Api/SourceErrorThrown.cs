namespace Common.Models.Error.Api; 

public class SourceErrorThrown : ApiError {
    public new const ApiErrorCode Code = ApiErrorCode.SourceErrorThrown;
    
    public SourceErrorThrown(List<string> errors) : base(Code) {
        Data = string.Join("\n", errors);
    }
}
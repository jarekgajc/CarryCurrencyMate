﻿namespace Common.Models.Error.Api; 

public enum ApiErrorCode {
    CredentialsNotFound,
    ItemDoesNotExist,
    ConnectionToSourceFailed,
    SourceErrorThrown
}
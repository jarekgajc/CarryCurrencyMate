using System.Security.Claims;
using Backend.Models.Exceptions;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.Utils
{
    public static class IncludableQueryableUtils
    {
        public static async Task<T1> GetOrThrow<T1, T2>(this IIncludableQueryable<T1, T2> queryable)
        {
            return await queryable.FirstOrDefaultAsync() ?? throw new ApiException(new ResourceDoesNotExist());
        }
    }
}

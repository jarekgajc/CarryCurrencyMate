using System.Security.Claims;

namespace Backend.Utils
{
    public static class ClaimsPrincipalUtils
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}

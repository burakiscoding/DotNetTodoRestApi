using System.Security.Claims;

namespace DotNetTodoRestApi.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(e => e.Type == ClaimTypes.GivenName)?.Value;
        }
    }
}

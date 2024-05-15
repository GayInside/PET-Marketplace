using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Domain.Services
{
    public class ContextService(IHttpContextAccessor httpContextAccessor)
    {
        public HttpContext GetHttpContext() =>
            httpContextAccessor.HttpContext;

        public string? GetUsername() =>
            httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value ?? null;

        public string? GetUserRole() =>
            httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value ?? null;
    }
}

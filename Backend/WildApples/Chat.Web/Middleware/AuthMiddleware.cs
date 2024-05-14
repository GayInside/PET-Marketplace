using Chat.Domain.Services;

namespace Chat.Web.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "ApiKey";
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.ToString().StartsWith("/chat"))
            {
                await _next.Invoke(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(API_KEY, out
                var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }

            var apiKey = "Token";
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            //var authToken = context.Request.Headers[AuthService.AUTH_HEADER_NAME];

            //if (string.IsNullOrEmpty(authToken) || !authToken.Any())
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await context.Response.WriteAsync("Unauthorize request");
            //    return;
            //}

            //var authService = context.RequestServices.GetService<AuthService>() ?? throw new Exception("No such service");
            //if (!authService.ValidateToken(authToken))
            //{
            //    context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //    await context.Response.WriteAsync("Access forbidden");
            //    return;
            //}

            await _next.Invoke(context);
        }
    }
}

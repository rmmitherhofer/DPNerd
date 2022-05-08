using Microsoft.AspNetCore.Http;

namespace DPNerd.Swagger.Core.Middleware;

public class SwaggerAuthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public SwaggerAuthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next.Invoke(context);
    }
}

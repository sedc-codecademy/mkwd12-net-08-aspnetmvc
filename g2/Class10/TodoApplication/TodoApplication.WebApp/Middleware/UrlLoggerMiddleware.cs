using Microsoft.AspNetCore.Http.Extensions;

namespace TodoApplication.WebApp.Middleware
{
    public class UrlLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public UrlLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Console.WriteLine($"Request log: {UriHelper.GetDisplayUrl(httpContext.Request)}");
            await _next(httpContext);
        }
    }
}

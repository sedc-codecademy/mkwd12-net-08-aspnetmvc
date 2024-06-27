namespace Class08.Middleware
{
    public class MiddleWare2
    {
        private readonly RequestDelegate _next;
        public MiddleWare2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //check in console when triggering/accessing different urls in our application
            Console.WriteLine($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            //This line goes to the next middleware component in the pipeline on the next component in our middleware =>
            await this._next(context);
        }
    }
}

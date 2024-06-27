//using Microsoft.AspNetCore.Http;
//using System;

//namespace Class08.Middleware
//{
//    public class UrlLoggerMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly HttpContext _context;
//        public UrlLoggerMiddleware(RequestDelegate next, HttpContext context)
//        {
//            _context = context;
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContent context)
//        {
//            Console.WriteLine($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
//            await this._next(context);
//        }
//    }
//}

//for some reason, the code here didnt work but the same code works in middleware2 
//most probably some VS bug, which is why this is commented and we use middleware2 class in program.cs

using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class IgnoreRouteMiddleware
    {
        private readonly RequestDelegate next;

        // You can inject a dependency here that gives you access
        // to your ignored route configuration.
        public IgnoreRouteMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.HasValue && context.Request.Path.Value.EndsWith("aspx"))
            {
                //context.Response.StatusCode = 404;
                Console.WriteLine("Ignored!");
                return;
            }
            await next.Invoke(context);
        }
    }
}
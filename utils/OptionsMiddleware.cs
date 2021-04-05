using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Backend.utils
{
    /// <summary>
    ///     Due to the IApplicationBuilder.useCors() not working with our dotnet graphql server, we have to create
    ///     our own middleware which intercepts the requests and applies preflight information in the case where the method
    ///     is OPTIONS.
    /// </summary>
    public class OptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public OptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        private Task BeginInvoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin",
                new[]
                {
                    (string) context.Request.Headers["Origin"]
                }); // This accepts all origins as it simply echoes the origin back
            context.Response.Headers.Add("Access-Control-Allow-Headers",
                new[] {"Origin, X-Requested-With, Content-Type, Accept"});
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] {"GET, POST, OPTIONS"});
            context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] {"true"});

            // For non-OPTIONS requests we want to continue the network pipeline, but for OPTIONS we want to terminate with 204 No Content.
            // Without this, GraphQL server gets very(!) upset and tells the client that it only accepts GET and POST requests. What a picky eater.
            if (context.Request.Method != "OPTIONS") return _next.Invoke(context);

            context.Response.StatusCode = 204; // No Content

            return context.Response.CompleteAsync();
        }
    }

    public static class OptionsMiddlewareExtensions
    {
        public static void UseOptions(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<OptionsMiddleware>();
        }
    }
}
using System.Threading.Tasks;
using Backend.utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace BackendTests.Web
{
    public class OptionsMiddlewareTest
    {
        private readonly OptionsMiddleware _optionsMiddleware = new(_ => Task.CompletedTask);

        [Fact]
        public void Invocation()
        {
            _optionsMiddleware.Invoke(new DefaultHttpContext()).ShouldBeAssignableTo<Task>();
        }

        [Fact]
        public async void BeginInvoke()
        {
            var context = new DefaultHttpContext();

            await _optionsMiddleware.Invoke(context);

            context.Response.Headers["Access-Control-Allow-Headers"]
                .ShouldBe(new[] {"Origin, X-Requested-With, Content-Type, Accept"});
            context.Response.Headers["Access-Control-Allow-Methods"].ShouldBe(new[] {"GET, POST, OPTIONS"});
            context.Response.Headers["Access-Control-Allow-Credentials"].ShouldBe(new[] {"true"});
        }

        [Fact]
        public async void BeginInvokeWithOptionsMethod()
        {
            var context = new DefaultHttpContext();

            context.Request.Method = "OPTIONS";

            await _optionsMiddleware.Invoke(context);

            context.Response.StatusCode.ShouldBe(204);
        }

        [Fact]
        public static void UseMiddleware()
        {
            IApplicationBuilder builder = new ApplicationBuilder(null!);
            Should.NotThrow(() => builder.UseOptions());
        }
    }
}
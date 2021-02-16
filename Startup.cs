using Backend.API.Queries;
using Backend.API.Schemas;
using Backend.API.Services;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IDataRetrievalService, DataRetrievalService>()
                .AddSingleton<IForecastDataRetrievalService, ForecastDataRetrievalService>()
                .AddSingleton<TodoSchema>()
                .AddSingleton<TodoQuery>()
                .AddSingleton<ForecastSchema>()
                .AddSingleton<ForecastQuery>()
                .AddHttpContextAccessor()

                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx =>
                        logger.LogError("{Error} occured", ctx.OriginalException.Message);
                })

                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(ForecastSchema))
                .AddGraphTypes(typeof(TodoSchema));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseWebSockets();
            // Replaced the HttpMiddleware with paths for each schema
           // app.UseGraphQL<ForecastSchema, GraphQLHttpMiddleware<ForecastSchema>>();
            app.UseGraphQL<ForecastSchema>("/api/forecast");
            //app.UseGraphQL<TodoSchema, GraphQLHttpMiddleware<TodoSchema>>();
            app.UseGraphQL<TodoSchema>("/api/todo");

            app.UseGraphQLWebSockets<ForecastSchema>();
            app.UseGraphQLWebSockets<TodoSchema>();

            /*
             * This will create two endpoints, based on https://github.com/graphql-dotnet/examples/blob/master/src/AspNetCoreMulti/Example/Startup.cs
             */
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                GraphQLEndPoint = "/api/forecast",
                Path = "/ui/playground",
                BetaUpdates = true,
                RequestCredentials = RequestCredentials.Omit,
                HideTracingResponse = false,

                EditorCursorShape = EditorCursorShape.Line,
                EditorTheme = EditorTheme.Dark,
                EditorFontSize = 14,
                EditorReuseHeaders = true,

                PrettierPrintWidth = 80,
                PrettierTabWidth = 2,
                PrettierUseTabs = true,

                SchemaDisableComments = false,
                SchemaPollingEnabled = true,
                SchemaPollingEndpointFilter = "*localhost*",
                SchemaPollingInterval = 5000
            });
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                GraphQLEndPoint = "/api/todo",
                Path = "/ui/playground",
                BetaUpdates = true,
                RequestCredentials = RequestCredentials.Omit,
                HideTracingResponse = false,

                EditorCursorShape = EditorCursorShape.Line,
                EditorTheme = EditorTheme.Dark,
                EditorFontSize = 14,
                EditorReuseHeaders = true,

                PrettierPrintWidth = 80,
                PrettierTabWidth = 2,
                PrettierUseTabs = true,

                SchemaDisableComments = false,
                SchemaPollingEnabled = true,
                SchemaPollingEndpointFilter = "*localhost*",
                SchemaPollingInterval = 5000
            });
        }
    }
}
using System.Net.Http.Headers;
using Backend.API.Queries;
using Backend.API.Schemas;
using Backend.API.Services;
using Backend.Models.Base.Metadata;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            // DP on database
            services.Configure<MetadataDatabaseSettings>(
                Configuration.GetSection(nameof(MetadataDatabaseSettings)));

            services.AddSingleton<IMetadataDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MetadataDatabaseSettings>>().Value);

            services.AddSingleton<IMetaDataService, MetaDataService>();

            // If configuration specifies mocking should be enabled, don't create HTTP clients and simply inject
            // mocked services as singletons.
            if (Configuration.GetValue<bool>("MockRequests"))
                services.AddSingleton<IMetAPIService, MetAPIServiceMocked>();
            else
                services.AddHttpClient<IMetAPIService, MetAPIService>(client =>
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(
                        "DVT/1.0 (fredrik.malmo@icloud.com)"); // api.met.no requires contact email
                });

            services
                .AddSingleton<RootSchema>()
                .AddSingleton<RootQuery>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx =>
                        logger.LogError("{Error} occured", ctx.OriginalException.Message);
                })
                .AddSystemTextJson(_ => { }, _ => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(RootSchema));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseWebSockets();
            // Replaced the HttpMiddleware with paths for each schema
            app.UseGraphQL<RootSchema, GraphQLHttpMiddleware<RootSchema>>();

            app.UseGraphQLWebSockets<RootSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
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
using System;
using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.MetAPI.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IServiceProvider serviceProvider)
        {
            var metAPIService = (IMetAPIService) serviceProvider.GetService(typeof(IMetAPIService));
            var metadataService = (IMetadataService) serviceProvider.GetService(typeof(IMetadataService));

            Field<ForecastType>("forecast", "Latitude and Longitude defaults to the coordinates of Trondheim",
                new QueryArguments
                {
                    new QueryArgument<FloatGraphType>
                    {
                        Name = "lat", Description = "The lat (dec) of the forecast to retrieve.",
                        DefaultValue = 63.446827
                    },
                    new QueryArgument<FloatGraphType>
                    {
                        Name = "lon", Description = "The long (dec) of the forecast to retrieve.",
                        DefaultValue = 10.421906
                    }
                },
                context =>
                    metAPIService?.GetCompactForecast(
                        context.GetArgument<float>("lat"),
                        context.GetArgument<float>("lon")));

            Field<StoredMetadataType>("metadata", "metadata for the different data sources",
                new QueryArguments
                {
                    new QueryArgument<StringGraphType>
                    {
                        Name = "name", Description = "The name of the metadata document to use",
                        DefaultValue = "befolkningstall"
                    }
                },
                context => metadataService?.GetMetadata(
                    context.GetArgument<string>("name")));
        }
    }
}
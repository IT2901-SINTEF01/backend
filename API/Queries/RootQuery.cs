using Backend.API.Services;
using Backend.Models.MetAPI;
using Backend.Models.MetAPI.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IDataRetrievalService dataRetrievalService)
        {
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
                    dataRetrievalService.GetForecast(
                        context.GetArgument<float>("lat"),
                        context.GetArgument<float>("lon")));
        }
    }
}
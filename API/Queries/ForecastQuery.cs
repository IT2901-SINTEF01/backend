using Backend.API.MetAPI;
using Backend.API.Services;
using GraphQL;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class ForecastQuery : ObjectGraphType
    {
        public ForecastQuery(IForecastDataRetrievalService forecastDataRetrievalService)
        {
            Field<ForecastType>("forecast", arguments: new QueryArguments()
                {
                    new QueryArgument<FloatGraphType>(){Name = "lat", Description = "The lat (dec) of the forecast to retrieve.", DefaultValue = 63},
                    new QueryArgument<FloatGraphType>(){Name = "lon", Description = "The long (dec) of the forecast to retrieve.", DefaultValue = 10}
                },
                // Two arguments that are used
                // todo: Add support for decimals, only works with integers for now.
                resolve: context =>
                    forecastDataRetrievalService.GetForecast(
                        context.GetArgument<float>("lat"),
                        context.GetArgument<float>("lon")));
        }
        
    }
}
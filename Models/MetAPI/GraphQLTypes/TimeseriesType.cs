using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class TimeseriesType : ObjectGraphType<Timeseries>
    {
        public TimeseriesType()
        {
            Field(timeseries => timeseries.ForecastData, false, typeof(ForecastDataType))
                .Description("The forecast-data");
            Field(timeseries => timeseries.Time).Description("The time for forecast-data");
        }
    }
}
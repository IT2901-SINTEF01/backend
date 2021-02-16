using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class TimeseriesType : ObjectGraphType<Timeseries>
    {
        public TimeseriesType()
        {
            Field(timeseries => timeseries.ForecastData, false, typeof(ForecastDataType));
            Field(timeseries => timeseries.Time);
        }
    }
}
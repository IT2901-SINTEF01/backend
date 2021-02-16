using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class TimeseriesType : ObjectGraphType<Forecast.Timeseries>
    {
        public TimeseriesType()
        {
            Field(timeseries => timeseries.ForecastData, false, typeof(ForecastDataType));
            Field(timeseries => timeseries.Time);
        }
    }
}
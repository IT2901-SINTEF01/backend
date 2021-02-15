using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class PropertiesType : ObjectGraphType<Forecast.Properties>
    {
        public PropertiesType()
        {
            Field(properties => properties.Meta, false, typeof(MetaType));
            Field(context => context.Timeseries, false, typeof(ListGraphType<TimeseriesType>));
        }
    }
}
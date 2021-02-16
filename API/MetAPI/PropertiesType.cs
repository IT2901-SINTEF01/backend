using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class PropertiesType : ObjectGraphType<Properties>
    {
        public PropertiesType()
        {
            Field(properties => properties.Meta, false, typeof(MetaType));
            Field(context => context.Timeseries, false, typeof(ListGraphType<TimeseriesType>));
        }
    }
}
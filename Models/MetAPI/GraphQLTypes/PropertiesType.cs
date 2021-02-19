using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class PropertiesType : ObjectGraphType<Properties>
    {
        public PropertiesType()
        {
            Field(properties => properties.Meta, false, typeof(MetaType));
            Field(context => context.Timeseries, false, typeof(ListGraphType<TimeseriesType>))
                .Description("A list of forecast-data of each timeseries");
        }
    }
}
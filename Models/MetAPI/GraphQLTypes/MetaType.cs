using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class MetaType : ObjectGraphType<Meta>
    {
        public MetaType()
        {
            Field(meta => meta.Units, false, typeof(UnitsType)).Description("The units used in parameters returned");
            Field(meta => meta.UpdatedAt).Description("Timeseries of when forecast was last updatet");
        }
    }
}
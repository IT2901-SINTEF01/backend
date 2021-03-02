using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class AxisType : ObjectGraphType<Axis>
    {
        public AxisType()
        {
            Field(axis => axis.Name);
            Field(axis => axis.Limit, false, typeof(LimitType));
            Field(axis => axis.Type);
        }
    }
}
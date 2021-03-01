using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
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
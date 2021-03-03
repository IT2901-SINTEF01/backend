using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class AxesType : ObjectGraphType<Axes>
    {
        public AxesType()
        {
            Field(axes => axes.X, false, typeof(AxisType));
            Field(axes => axes.Y, false, typeof(AxisType));
        }
    }
}
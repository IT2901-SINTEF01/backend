using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
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
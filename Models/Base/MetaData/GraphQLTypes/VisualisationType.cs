using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class VisualisationType : ObjectGraphType<Visualisation>
    {
        public VisualisationType()
        {
            Field(visualisation => visualisation.Axes, false, typeof(ListGraphType<AxesType>));
            Field(visualisation => visualisation.Segments, false, typeof(ListGraphType<SegmentType>));
            Field(visualisation => visualisation.Threshold);
            Field(visualisation => visualisation.Type);
        }
    }
}
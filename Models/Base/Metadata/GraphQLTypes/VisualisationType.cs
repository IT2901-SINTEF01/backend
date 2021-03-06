using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class VisualisationType : ObjectGraphType<Visualisation>
    {
        public VisualisationType()
        {
            Field(visualisation => visualisation.Axes, false, typeof(AxesType));
            Field(visualisation => visualisation.Segments, false, typeof(ListGraphType<SegmentType>));
            Field(visualisation => visualisation.Threshold, true);
            Field(visualisation => visualisation.Type);
        }
    }
}
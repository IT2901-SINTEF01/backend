using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class VisualisationType : ObjectGraphType<Visualisation>
    {
        public VisualisationType()
        {
            Field(visualisation => visualisation.Axes, false, typeof(AxesType));
            Field(visualisation => visualisation.Segments, false, typeof(SegmentType));
            Field(visualisation => visualisation.Threshold, false, typeof(StringGraphType));
            Field(visualisation => visualisation.Type);
        }
    }
}
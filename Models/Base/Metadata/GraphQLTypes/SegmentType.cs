using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class SegmentType : ObjectGraphType<Segment>
    {
        public SegmentType()
        {
            Field(segment => segment.Name);
            Field(segment => segment.Value, false, typeof(ListGraphType<IntGraphType>));
        }
    }
}
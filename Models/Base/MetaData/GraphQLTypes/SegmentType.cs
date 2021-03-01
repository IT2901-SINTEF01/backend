using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
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
using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class SegmentValueType : ObjectGraphType<Value>
    {
        public SegmentValueType()
        {
            Field(value => value.NumberInt);
        }
    }
}
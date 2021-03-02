using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class LimitType : ObjectGraphType<Limit>
    {
        public LimitType()
        {
            Field(limit => limit.NumberInt);
        }
    }
}
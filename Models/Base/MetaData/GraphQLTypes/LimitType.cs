using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class LimitType : ObjectGraphType<Limit>
    {
        public LimitType()
        {
            Field(limit => limit.NumberInt);
        }
    }
}
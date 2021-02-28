using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class IdType : ObjectGraphType<Id>
    {
        public IdType()
        {
            Field(id => id.Oid);
        }
    }
}
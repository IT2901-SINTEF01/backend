using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class AxesDescType : ObjectGraphType<X>
    {
        public AxesDescType()
        {
            Field(x => x.Name);
            Field(x => x.Limit, false, typeof(LimitType));
            Field(x => x.Type);
        }
    }
}
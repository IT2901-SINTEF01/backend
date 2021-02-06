using Backend.API.Queries.Resolvers;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class SampleQuery : ObjectGraphType
    {
        public SampleQuery()
        {
            Field<StringGraphType>("value", resolve: context => SampleResolver.Value());
        }
    }
}
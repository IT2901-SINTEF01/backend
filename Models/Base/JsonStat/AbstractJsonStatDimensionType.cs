using Backend.utils.GraphQLTypes;
using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public class AbstractJsonStatDimensionType<T> : ObjectGraphType<T> where T : AbstractJsonStatDimension
    {
        public AbstractJsonStatDimensionType()
        {
            Field(poco => poco.Id, false, typeof(ListGraphType<StringGraphType>));
            Field(poco => poco.Role, false, typeof(DictionaryStringCollectionStringType));
            Field(poco => poco.Size, false, typeof(ListGraphType<IntGraphType>));
        }
    }
}
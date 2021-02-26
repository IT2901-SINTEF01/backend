using System.Collections.Generic;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    internal class DictionaryStringIntType : ObjectGraphType<Dictionary<string, int>>
    {
        public DictionaryStringIntType()
        {
            Field(obj => obj.Keys, false, typeof(ListGraphType<StringGraphType>));
            Field(obj => obj.Values, false, typeof(ListGraphType<IntGraphType>));
        }
    }
}
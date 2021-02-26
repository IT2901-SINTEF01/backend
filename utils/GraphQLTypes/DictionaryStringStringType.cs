using System.Collections.Generic;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    internal class DictionaryStringStringType : ObjectGraphType<Dictionary<string, string>>
    {
        public DictionaryStringStringType()
        {
            Field(obj => obj.Keys, false, typeof(ListGraphType<StringGraphType>));
            Field(obj => obj.Values, false, typeof(ListGraphType<StringGraphType>));
        }
    }
}
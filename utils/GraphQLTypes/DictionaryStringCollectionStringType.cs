using System.Collections.Generic;
using System.Collections.ObjectModel;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    public class DictionaryStringCollectionStringType : ObjectGraphType<Dictionary<string, Collection<string>>>
    {
        public DictionaryStringCollectionStringType()
        {
            Field(obj => obj.Keys, false, typeof(ListGraphType<StringGraphType>));
            Field(obj => obj.Values, false, typeof(ListGraphType<ListGraphType<StringGraphType>>));
        }
    }
}
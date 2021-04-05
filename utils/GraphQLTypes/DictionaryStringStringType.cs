using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    [SuppressMessage("Rule Category", "CA1812", Justification = "The class is instantiated by GraphQL.")]
    public class DictionaryStringStringType : ObjectGraphType<Dictionary<string, string>>
    {
        public DictionaryStringStringType()
        {
            Field(obj => obj.Keys, false, typeof(ListGraphType<StringGraphType>));
            Field(obj => obj.Values, false, typeof(ListGraphType<StringGraphType>));
        }
    }
}
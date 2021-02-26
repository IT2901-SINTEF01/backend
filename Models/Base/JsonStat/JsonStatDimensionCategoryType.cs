using Backend.utils.GraphQLTypes;
using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public sealed class JsonStatDimensionCategoryType : ObjectGraphType<JsonStatDimensionCategory>
    {
        public JsonStatDimensionCategoryType()
        {
            Field(category => category.Index, false, typeof(DictionaryStringIntType));
            Field(category => category.Label, false, typeof(DictionaryStringStringType));
        }
    }
}
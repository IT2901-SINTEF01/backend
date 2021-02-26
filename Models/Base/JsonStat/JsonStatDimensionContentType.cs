using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public sealed class JsonStatDimensionContentType : ObjectGraphType<JsonStatDimensionContent>
    {
        public JsonStatDimensionContentType()
        {
            Field(content => content.Label);
            Field(content => content.Category, false, typeof(JsonStatDimensionCategoryType));
        }
    }
}
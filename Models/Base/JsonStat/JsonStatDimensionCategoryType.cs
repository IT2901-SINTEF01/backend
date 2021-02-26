using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public sealed class JsonStatDimensionCategoryType : ObjectGraphType<JsonStatDimensionCategory>
    {
        public JsonStatDimensionCategoryType()
        {
            //Field(category => category.Index);
            //Field(category => category.Label);
        }
    }
}
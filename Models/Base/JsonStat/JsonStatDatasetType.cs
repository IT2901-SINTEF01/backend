using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public class JsonStatDatasetType<T, TU> : ObjectGraphType<JsonStatDataset<T>> where T : AbstractJsonStatDimension
    {
        public JsonStatDatasetType()
        {
            Field(poco => poco.Label);
            Field(poco => poco.Source);
            Field(poco => poco.Updated);
            Field(poco => poco.Value, false, typeof(ListGraphType<IntGraphType>));
            Field(poco => poco.Dimension, false, typeof(TU));
        }
    }
}
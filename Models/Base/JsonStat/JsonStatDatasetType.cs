using GraphQL.Types;

namespace Backend.Models.Base.JsonStat
{
    public abstract class JsonStatDatasetType<T1, T2> : ObjectGraphType<JsonStatDataset<T1>>
        where T1 : AbstractJsonStatDimension
    {
        /// <summary>
        /// Set of JSONStat Dataset Type resolution.
        /// </summary>
        /// <param name="overrideValueResolution">Since you can only declare a field once, we have to add the option to override the resolution of the field.</param>
        protected JsonStatDatasetType(bool overrideValueResolution = false)
        {
            Field(poco => poco.Label);
            Field(poco => poco.Source);
            Field(poco => poco.Updated);

            if (!overrideValueResolution)
                Field(poco => poco.Value, false, typeof(ListGraphType<IntGraphType>));

            Field(poco => poco.Dimension, false, typeof(T2));
        }
    }
}
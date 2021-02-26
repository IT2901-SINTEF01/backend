using Backend.Models.SSB.POCO;
using GraphQL.Types;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class AgesInNorwayType : ObjectGraphType<AgesInNorway>
    {
        public AgesInNorwayType()
        {
            Field(poco => poco.Dataset, false, typeof(AgesInNorwayDatasetType))
                .Description("Dataset containing population statistics for Norway.");
        }
    }
}
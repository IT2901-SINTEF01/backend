using Backend.Models.SSB.POCO;
using GraphQL.Types;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class PopulationInNorwayType : ObjectGraphType<PopulationPerMunicipalityNorway>
    {
        public PopulationInNorwayType()
        {
            Field(poco => poco.Dataset, false, typeof(PopulationInNorwayDatasetType))
                .Description("Dataset containing population statistics for Norway.");
        }
    }
}
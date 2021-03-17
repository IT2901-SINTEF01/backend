using Backend.API.Services;
using Backend.Models.SSB.POCO;
using Backend.utils.GraphQLTypes;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class PopulationInNorwayType : ObjectGraphTypeWithMetadata<PopulationPerMunicipalityNorway>
    {
        public PopulationInNorwayType(IMetadataService metadataService) : base(metadataService, "SSB population data")
        {
            Field(poco => poco.Dataset, false, typeof(PopulationInNorwayDatasetType))
                .Description("Dataset containing population statistics for Norway.");
        }
    }
}
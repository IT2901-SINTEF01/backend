using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.SSBPopulationStatistics.GraphQLTypes;
using Backend.Models.SSBPopulationStatistics.POCO;
using Backend.utils.GraphQLTypes;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class PopulationInNorwayType : ObjectGraphTypeWithMetadata<PopulationPerMunicipalityNorway>
    {
        public PopulationInNorwayType(IMetadataService metadataService) : base(metadataService,
            DatasourceId.SsbPopulation)
        {
            Field(poco => poco.Dataset, false, typeof(PopulationInNorwayDatasetType))
                .Description("Dataset containing population statistics for Norway.");
        }
    }
}
using Backend.Models.Base.JsonStat;
using Backend.Models.SSBPopulationStatistics.POCO;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public sealed class
        PopulationInNorwayDatasetType : JsonStatDatasetType<PopulationPerMunicipalityNorway.PopulationInNorwayDimension,
            PopulationInNorwayDimensionType>
    {
    }
}
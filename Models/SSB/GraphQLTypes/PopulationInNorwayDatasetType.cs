using Backend.Models.Base.JsonStat;
using Backend.Models.SSB.POCO;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class
        PopulationInNorwayDatasetType : JsonStatDatasetType<PopulationPerMunicipalityNorway.PopulationInNorwayDimension,
            PopulationInNorwayDimensionType>
    {
    }
}
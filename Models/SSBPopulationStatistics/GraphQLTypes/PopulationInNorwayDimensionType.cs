using Backend.Models.Base.JsonStat;
using Backend.Models.SSB.POCO;

namespace Backend.Models.SSB.GraphQLTypes
{
    public class PopulationInNorwayDimensionType : AbstractJsonStatDimensionType<
        PopulationPerMunicipalityNorway.PopulationInNorwayDimension>
    {
        public PopulationInNorwayDimensionType()
        {
            Field(poco => poco.Region, false, typeof(JsonStatDimensionContentType));
            Field(poco => poco.Tid, false, typeof(JsonStatDimensionContentType));
        }
    }
}
using Backend.Models.Base.JsonStat;
using Backend.Models.SSB.POCO;

namespace Backend.Models.SSB.GraphQLTypes
{
    public class AgesInNorwayDimensionType : AbstractJsonStatDimensionType<AgesInNorway.AgesInNorwayDimension>
    {
        public AgesInNorwayDimensionType()
        {
            Field(poco => poco.Region, false, typeof(JsonStatDimensionContentType));
            Field(poco => poco.Tid, false, typeof(JsonStatDimensionContentType));
        }
    }
}
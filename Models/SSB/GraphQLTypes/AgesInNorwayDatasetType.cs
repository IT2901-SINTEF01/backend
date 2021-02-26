using Backend.Models.Base.JsonStat;
using Backend.Models.SSB.POCO;
using GraphQL.Types;

namespace Backend.Models.SSB.GraphQLTypes
{
    public sealed class AgesInNorwayDatasetType : JsonStatDatasetType<AgesInNorway.AgesInNorwayDimension, AgesInNorwayDimensionType>
    {
        public AgesInNorwayDatasetType()
        {
        }
    }
}
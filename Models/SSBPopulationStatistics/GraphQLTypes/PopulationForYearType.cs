using Backend.Models.SSBPopulationStatistics.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public class PopulationForYearType : ObjectGraphType<PopulationForYear>
    {
        public PopulationForYearType()
        {
            Field(poco => poco.Population);
            Field(poco => poco.Year);
        }
    }
}
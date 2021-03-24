using Backend.Models.SSBPopulationStatistics.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public class LabeledValueType : ObjectGraphType<LabeledValue>
    {
        public LabeledValueType()
        {
            Field(poco => poco.municipality);
            Field(poco => poco.populationForYear, false, typeof(ListGraphType<PopulationForYearType>));
        }
    }
}
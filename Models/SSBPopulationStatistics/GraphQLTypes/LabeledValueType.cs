using Backend.Models.SSBPopulationStatistics.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public class LabeledValueType : ObjectGraphType<LabeledValue>
    {
        public LabeledValueType()
        {
            Field(poco => poco.Municipality);
            Field(poco => poco.PopulationForYear, false, typeof(ListGraphType<PopulationForYearType>));
        }
    }
}
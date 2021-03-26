using Backend.Models.SSBPopulationStatistics.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    /// <summary>
    /// The population for a set of years, labelled with the municipality for which it is associated.
    /// </summary>
    public class LabeledValueType : ObjectGraphType<LabeledValue>
    {
        public LabeledValueType()
        {
            Field(poco => poco.Municipality);
            Field(poco => poco.PopulationForYear, false, typeof(ListGraphType<PopulationForYearType>));
        }
    }
}

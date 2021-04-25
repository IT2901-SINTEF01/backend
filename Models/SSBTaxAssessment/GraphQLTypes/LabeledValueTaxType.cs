using Backend.Models.SSBTaxAssessment.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    /// <summary>
    ///     The population for a set of years, labelled with the municipality for which it is associated.
    /// </summary>
    public class LabeledValueTaxType : ObjectGraphType<LabeledValueTax>
    {
        public LabeledValueTaxType()
        {
            Field(poco => poco.Municipality);
            Field(poco => poco.TaxesForYear, false, typeof(ListGraphType<TaxesForYearType>));
        }
    }
}
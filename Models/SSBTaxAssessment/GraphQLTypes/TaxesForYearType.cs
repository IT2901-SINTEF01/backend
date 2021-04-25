using Backend.Models.SSBTaxAssessment.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxesForYearType : ObjectGraphType<TaxesForAGivenYear>
    {
        public TaxesForYearType()
        {
            Field(poco => poco.Taxes);
            Field(poco => poco.Year);
        }
    }
}
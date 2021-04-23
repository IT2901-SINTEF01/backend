using Backend.Models.Base.JsonStat;
using Backend.Models.SSBTaxAssessment.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxAssessmentDatasetType : JsonStatDatasetType<TaxAssessment.TaxAssesmentDimension, TaxAssessmentDimensionType>
    {
        public TaxAssessmentDatasetType() : base(true)
        {
            Field(dataset => dataset.Value, false, typeof(ListGraphType<IntGraphType>));
        }
    }
}
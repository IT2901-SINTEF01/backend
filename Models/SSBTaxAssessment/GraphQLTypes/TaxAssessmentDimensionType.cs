using Backend.Models.Base.JsonStat;
using Backend.Models.SSBTaxAssessment.POCO;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxAssessmentDimensionType : AbstractJsonStatDimensionType<TaxAssessment.TaxAssesmentDimension>
    {
        public TaxAssessmentDimensionType()
        {
            Field(poco => poco.Region, false, typeof(JsonStatDimensionContentType));
            Field(poco => poco.Tid, false, typeof(JsonStatDimensionContentType));
        }
    }
}
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils.GraphQLTypes;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxAssessmentType : ObjectGraphTypeWithMetadata<TaxAssessment>
    {
        public TaxAssessmentType(IMetadataService metadataService) : base(metadataService, DatasourceId.SsbTax)
        {
            Field(assessment => assessment.Dataset, false, typeof(TaxAssessmentDatasetType));
        }
    }
}
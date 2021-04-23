
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils.GraphQLTypes;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxAssesmentType : ObjectGraphTypeWithMetadata<TaxAssessment>
    {
        public TaxAssesmentType(IMetadataService metadataService) : base(metadataService, DatasourceId.SsbPopulation)
        {
            Field(assessment => assessment.Dataset, false, typeof(TaxAssessmentDatasetType));
        }
    }
}
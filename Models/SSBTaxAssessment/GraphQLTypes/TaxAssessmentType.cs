using System.Collections.Generic;
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils.GraphQLTypes;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxAssessmentType : ObjectGraphTypeWithMetadata<TaxAssessment>
    {
        public TaxAssessmentType(IMetadataService metadataService) : base(metadataService, DatasourceId.SsbTax)
        {
            Field(assessment => assessment.Dataset, false, typeof(TaxAssessmentDatasetType))
                .Argument<ListGraphType<StringGraphType>>(Name = "municipalities",
                    Description = "Which municipalities to get the population for.",
                    argument => { argument.DefaultValue = new List<string>(); })
                .Argument<ListGraphType<StringGraphType>>(Name = "years",
                    Description = "Which years to get the population for.",
                    argument => { argument.DefaultValue = new List<string>(); })
                .Description("Dataset containing population statistics for Norway.");
        }
    }
}
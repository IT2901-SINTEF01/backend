using System.Collections.Generic;
using System.Linq;
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils;
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
            
            Field<ListGraphType<ListGraphType<StringGraphType>>>("municipalitiesWithKeys",
                "A nested list with the key for the municipality, followed by the human readable name.", null, _ =>
                {
                    var keys = NorwayTools.MunicipalityCodeToIndexTaxes.Keys;
                    var values = NorwayTools.MunicipalityCodeToMunicipalityNameTaxes.Values;

                    return keys.Zip(values)
                        .Select<(string, string), List<string>>(el => new List<string> {el.Item1, el.Item2});
                }
            );
        }
    }
}
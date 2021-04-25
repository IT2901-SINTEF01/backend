using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.Models.Base.JsonStat;
using Backend.Models.SSBPopulationStatistics.GraphQLTypes;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils;
using GraphQL;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class
        TaxAssessmentDatasetType : JsonStatDatasetType<TaxAssessment.TaxAssessmentDimension, TaxAssessmentDimensionType>
    {
        public TaxAssessmentDatasetType() : base(true)
        {
            Field<ListGraphType<LabeledValueTaxType>>("value", "The values for the selected municipalities and years.",
                null,
                context =>
                {
                    var municipalities = context.Parent.GetArgument<List<string>>("municipalities");
                    var years = context.Parent.GetArgument<List<string>>("years");

                    var municipalityEntrySize = context.Source.Dimension.Size[0];

                    return (from municipality in municipalities
                        let municipalityYears = context.Source.Value
                            .Skip(NorwayTools.MunicipalityCodeToIndexTaxes[municipality] * municipalityEntrySize)
                            .Take(municipalityEntrySize)
                            .ToList()
                        select new LabeledValueTax
                        {
                            Municipality = NorwayTools.MunicipalityCodeToMunicipalityNameTaxes[municipality],
                            TaxesForYear = new Collection<TaxesForAGivenYear>(years.Select(year =>
                                    new TaxesForAGivenYear
                                        {Year = year, Taxes = municipalityYears[NorwayTools.YearToIndexTaxes[year]]})
                                .ToList())
                        }).ToList();
                });
        }
    }
}
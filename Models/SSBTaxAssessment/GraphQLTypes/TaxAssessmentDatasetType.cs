using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.Models.Base.JsonStat;
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
                    var skipSize = context.Source.Dimension.Size[3];
                    var municipalityEntrySize = context.Source.Dimension.Size[0];
                    var totalRowsPerMunicipality = context.Source.Dimension.Size[2] * context.Source.Dimension.Size[3];
                    return (from municipality in municipalities
                        let municipalityYears = context.Source.Value
                            .Skip(NorwayTools.MunicipalityCodeToIndexTaxes[municipality] * totalRowsPerMunicipality)
                            .Take(municipalityEntrySize)
                            .ToList()
                        select new LabeledValueTax
                        {
                            Municipality = NorwayTools.MunicipalityCodeToMunicipalityNameTaxes[municipality],
                            TaxesForYear = new Collection<TaxesForAGivenYear>(years.Select(year =>
                                    new TaxesForAGivenYear
                                    {
                                        Year = year,
                                        Brutto = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize],
                                        LonnInnt = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 1],
                                        Uskstt = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 2],
                                        AllmennInnt =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 3],
                                        BankInn = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 4],
                                        BrFormue = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 5],
                                        Gjeld = municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 6],
                                        MedianBtoInnt =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 7],
                                        MedianLonnInnt =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 8],
                                        MedianUtlignSkatt =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 9],
                                        MedianAlmInnt =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 10],
                                        MedianBankInns =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 11],
                                        MedianBtoFormue =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 12],
                                        MedianGjeld =
                                            municipalityYears[NorwayTools.YearToIndexTaxes[year] * skipSize + 13]
                                    })
                                .ToList())
                        }).ToList();
                });
        }
    }
}
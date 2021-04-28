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
                            TaxesForYear = new Collection<AnnualTaxes>(years.Select(year =>
                                    {
                                        var yearIndex = NorwayTools.YearToIndexTaxes[year];
                                        return new AnnualTaxes
                                        {
                                            Year = year,
                                            Brutto = municipalityYears[yearIndex * skipSize],
                                            LonnInnt = municipalityYears[yearIndex * skipSize + 1],
                                            Uskstt = municipalityYears[yearIndex * skipSize + 2],
                                            AllmennInnt = municipalityYears[yearIndex * skipSize + 3],
                                            BankInn = municipalityYears[yearIndex * skipSize + 4],
                                            BrFormue = municipalityYears[yearIndex * skipSize + 5],
                                            Gjeld = municipalityYears[yearIndex * skipSize + 6],
                                            MedianBtoInnt = municipalityYears[yearIndex * skipSize + 7],
                                            MedianLonnInnt = municipalityYears[yearIndex * skipSize + 8],
                                            MedianUtlignSkatt = municipalityYears[yearIndex * skipSize + 9],
                                            MedianAlmInnt = municipalityYears[yearIndex * skipSize + 10],
                                            MedianBankInns = municipalityYears[yearIndex * skipSize + 11],
                                            MedianBtoFormue = municipalityYears[yearIndex * skipSize + 12],
                                            MedianGjeld = municipalityYears[yearIndex * skipSize + 13]
                                        };
                                    }
                                )
                                .ToList())
                        }).ToList();
                });
        }
    }
}
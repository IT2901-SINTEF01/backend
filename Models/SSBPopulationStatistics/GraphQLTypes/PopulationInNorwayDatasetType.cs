using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.Models.Base.JsonStat;
using Backend.Models.SSBPopulationStatistics.POCO;
using Backend.utils;
using GraphQL;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public sealed class
        PopulationInNorwayDatasetType : JsonStatDatasetType<PopulationPerMunicipalityNorway.PopulationInNorwayDimension,
            PopulationInNorwayDimensionType>
    {
        public PopulationInNorwayDatasetType() : base(true)
        {
            Field<ListGraphType<LabeledValueType>>("value", "The values for the selected municipalities and years.",
                null,
                context =>
                {
                    var municipalities = context.Parent.GetArgument<List<string>>("municipalities");
                    var years = context.Parent.GetArgument<List<string>>("years");

                    var municipalityEntrySize = context.Source.Dimension.Size[1];

                    return (from municipality in municipalities
                        let municipalityYears = context.Source.Value
                            .Skip(NorwayTools.MunicipalityCodeToIndex[municipality] * municipalityEntrySize)
                            .Take(municipalityEntrySize)
                            .ToList()
                        select new LabeledValue
                        {
                            Municipality = NorwayTools.MunicipalityCodeToMunicipalityName[municipality],
                            PopulationForYear = new Collection<PopulationForAGivenYear>(years.Select(year =>
                                    new PopulationForAGivenYear
                                    {
                                        Year = year,
                                        Population = municipalityYears[NorwayTools.YearToIndexPopulation[year]]
                                    })
                                .ToList())
                        }).ToList();
                }
            );
        }
    }
}
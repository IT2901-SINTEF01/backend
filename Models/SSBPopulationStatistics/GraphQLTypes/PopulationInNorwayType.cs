using System.Collections.Generic;
using System.Linq;
using Backend.API.Services;
using Backend.Models.SSBPopulationStatistics.POCO;
using Backend.utils;
using Backend.utils.GraphQLTypes;
using GraphQL.Types;

namespace Backend.Models.SSBPopulationStatistics.GraphQLTypes
{
    public sealed class PopulationInNorwayType : ObjectGraphTypeWithMetadata<PopulationPerMunicipalityNorway>
    {
        public PopulationInNorwayType(IMetadataService metadataService) : base(metadataService,
            "Befolkning. Kommuner, pr. 1.1., 1986 - siste år")
        {
            Field(poco => poco.Dataset,
                    false, typeof(PopulationInNorwayDatasetType))
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
                    var keys = NorwayTools.MunicipalityCodeToMunicipalityName.Keys;
                    var values = NorwayTools.MunicipalityCodeToMunicipalityName.Values;

                    return keys.Zip(values)
                        .Select<(string, string), List<string>>(el => new List<string>() {el.Item1, el.Item2});
                }
            );

            Field<ListGraphType<StringGraphType>>(
                "years",
                "The available years from which to retrieve population statistics",
                null,
                _ => NorwayTools.YearToYearString.Keys);
        }
    }
}
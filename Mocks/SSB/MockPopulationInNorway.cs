using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Backend.Models.Base.JsonStat;
using Backend.Models.SSB.POCO;
using Backend.utils;
using Bogus;

namespace Backend.Mocks.SSB
{
    /// <summary>
    /// This class contains logic for mocking the population in Norway
    /// by municipality, using the JSON-stat format. The municipalities
    /// and their codes are hardcoded, and the population rates ascending
    /// in a pseudorandom fashion.
    /// </summary>
    public sealed class MockPopulationInNorway
    {
        [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
        public static PopulationPerMunicipalityNorway GenerateSampleAgesInNorway()
        {
            var numYears = NorwayTools.YearToIndex.Count;
            var numMunicipalities = NorwayTools.MunicipalityCodeToIndex.Count;
            const int approxPopulationNorway = 5391369;

            var region = new Faker<JsonStatDimensionContent>()
                .RuleFor(o => o.Category, _ => new JsonStatDimensionCategory()
                {
                    Index = NorwayTools.MunicipalityCodeToIndex,
                    Label = NorwayTools.MunicipalityCodeToMunicipalityName
                })
                .RuleFor(o => o.Label, _ => "Label");
            var time = new Faker<JsonStatDimensionContent>()
                .RuleFor(o => o.Category, _ => new JsonStatDimensionCategory()
                {
                    Index = NorwayTools.YearToIndex,
                    Label = NorwayTools.YearToYearString
                })
                .RuleFor(o => o.Label, _ => "År");

            var dimension = new Faker<PopulationPerMunicipalityNorway.PopulationInNorwayDimension>()
                .RuleFor(o => o.Region, _ => region)
                .RuleFor(o => o.Tid, _ => time)
                .RuleFor(o => o.Id, _ => new Collection<string> {"Region", "Tid"})
                .RuleFor(o => o.Role,
                    _ => new Dictionary<string, Collection<string>>
                        {{"time", new Collection<string> {"Tid"}}, {"metric", new Collection<string> {"ContentsCode"}}})
                .RuleFor(o => o.Size,
                    _ => new Collection<int> {numMunicipalities, numYears});

            var dateNow = DateTime.Now;

            var dataset = new Faker<JsonStatDataset<PopulationPerMunicipalityNorway.PopulationInNorwayDimension>>()
                .RuleFor(o => o.Dimension, _ => dimension)
                .RuleFor(o => o.Label, _ => "07459: Befolkning, etter region, år og statistikkvariabel")
                .RuleFor(o => o.Source, _ => "Statistisk sentralbyrå")
                .RuleFor(o => o.Updated,
                    _ => dateNow.AddDays(-dateNow.Day).AddHours(-dateNow.Hour).AddMinutes(-dateNow.Minute)
                        .AddSeconds(-dateNow.Second).AddMilliseconds(-dateNow.Millisecond))
                .RuleFor(o => o.Value, f =>
                {
                    var outArray = new Collection<int>();
                    var approximatePopulationPerMunicipality =
                        (int) Math.Floor((float) approxPopulationNorway / numMunicipalities);

                    for (var i = 0; i < numMunicipalities; i++)
                    {
                        outArray.Add(approximatePopulationPerMunicipality + f.Random.Int(-13000, 13000));
                    }

                    for (var i = 0; i < numYears - 1; i++)
                    {
                        for (var j = 0; j < numMunicipalities; j++)
                        {
                            var currentLength = outArray.Count;
                            var prevPopulationInThisMunicipality = outArray[currentLength - numMunicipalities];
                            outArray.Add(prevPopulationInThisMunicipality + f.Random.Int(1, 500));
                        }
                    }

                    return outArray;
                });

            return new PopulationPerMunicipalityNorway
            {
                Dataset = dataset
            };
        }
    }
}
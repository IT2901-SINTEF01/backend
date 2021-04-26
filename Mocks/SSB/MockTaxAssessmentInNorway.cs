using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Backend.Models.Base.JsonStat;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils;
using Bogus;

namespace Backend.Mocks.SSB
{
    public sealed class MockTaxAssessmentInNorway
    {
        [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
        public static TaxAssessment GenerateSampleTaxAssessments()
        {
            var numYears = NorwayTools.YearToIndexTaxes.Count;
            var numMunicipalities = NorwayTools.MunicipalityCodeToIndexTaxes.Count;
            const int numFields = 14;

            var region = new Faker<JsonStatDimensionContent>()
                .RuleFor(o => o.Category, _ => new JsonStatDimensionCategory
                {
                    Index = NorwayTools.MunicipalityCodeToIndexTaxes,
                    Label = NorwayTools.MunicipalityCodeToMunicipalityNameTaxes
                })
                .RuleFor(o => o.Label, _ => "Label");

            var time = new Faker<JsonStatDimensionContent>()
                .RuleFor(o => o.Category, _ => new JsonStatDimensionCategory
                {
                    Index = NorwayTools.YearToIndexTaxes,
                    Label = NorwayTools.YearToYearStringTaxes,
                })
                .RuleFor(o => o.Label, _ => "År");

            var dimension = new Faker<TaxAssessment.TaxAssessmentDimension>()
                .RuleFor(o => o.Region, _ => region)
                .RuleFor(o => o.Tid, _ => time)
                .RuleFor(o => o.Id, _ => new Collection<string> {"Region", "Alder", "Tid", "ContentsCode"})
                .RuleFor(o => o.Role,
                    _ => new Dictionary<string, Collection<string>>
                        {{"time", new Collection<string> {"Tid"}}, {"metric", new Collection<string> {"ContentsCode"}}})
                .RuleFor(o => o.Size,
                    _ => new Collection<int> {numMunicipalities, 1, numYears, numFields});

            var dateNow = DateTime.Now;

            var dataset = new Faker<JsonStatDataset<TaxAssessment.TaxAssessmentDimension>>()
                .RuleFor(o => o.Dimension, _ => dimension)
                .RuleFor(o => o.Label,
                    _ =>
                        "Hovedposter fra skatteoppgjøret. Personer, etter alder. Gjennomsnitt og median (kr). Kommuner, 1999 - siste år")
                .RuleFor(o => o.Source, _ => "Statistisk sentralbyrå")
                .RuleFor(o => o.Updated,
                    _ => dateNow.AddDays(-dateNow.Day).AddHours(-dateNow.Hour).AddMinutes(-dateNow.Minute)
                        .AddSeconds(-dateNow.Second).AddMilliseconds(-dateNow.Millisecond))
                .RuleFor(o => o.Value, f =>
                {
                    var outArray = new Collection<int>();

                    for (var i = 0; i < numMunicipalities; i++)
                    {
                        for (var j = 0; j < numYears; j++)
                        {
                            for (var k = 0; k < numFields; k++)
                            {
                                if (j == 0)
                                {
                                    outArray.Add(f.Random.Int(0, 1000000));
                                }
                                else
                                {
                                    outArray.Add(outArray[(j - 1) * numFields] + f.Random.Int(-50000, 50000));
                                }
                            }
                        }
                    }

                    return outArray;
                });
            return new TaxAssessment
            {
                Dataset = dataset
            };
        }
    }
}

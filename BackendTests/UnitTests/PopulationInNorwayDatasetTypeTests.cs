using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.Models.Base.JsonStat;
using Backend.Models.SSBPopulationStatistics.GraphQLTypes;
using Backend.Models.SSBPopulationStatistics.POCO;
using GraphQL;
using GraphQL.Execution;
using Shouldly;
using Xunit;

namespace BackendTests.UnitTests
{
    public static class PopulationInNorwayDatasetTypeTests
    {
        [Fact]
        public static void PopulationInNorwayDatasetCorrectOutput()
        {
            var actor = new PopulationInNorwayDatasetType();

            Assert.NotNull(actor.GetField("value"));

            var expected = new LabeledValue()
            {
                Municipality = "Halden",
                PopulationForYear = new Collection<PopulationForYear>()
                {
                    new()
                    {
                        Population = 100,
                        Year = "1986"
                    }
                }
            };

            var actual = (List<LabeledValue>) actor.GetField("value").Resolver.Resolve(new ResolveFieldContext()
            {
                Parent = new ResolveFieldContext()
                {
                    Arguments = new Dictionary<string, ArgumentValue>()
                    {
                        {
                            "municipalities",
                            new ArgumentValue(new List<string>() {"K-3001"}, ArgumentSource.Variable)
                        },
                        {"years", new ArgumentValue(new List<string>() {"1986"}, ArgumentSource.Variable)}
                    }
                },
                Source = new JsonStatDataset<PopulationPerMunicipalityNorway.PopulationInNorwayDimension>()
                {
                    Dimension = new PopulationPerMunicipalityNorway.PopulationInNorwayDimension()
                    {
                        Size = new Collection<int>() {359, 36, 1}
                    },
                    Value = new Collection<int>() {100}
                }
            });

            actual[0].Municipality.ShouldBe(expected.Municipality);
            actual[0].PopulationForYear[0].Population.ShouldBe(expected.PopulationForYear[0].Population);
            actual[0].PopulationForYear[0].Year.ShouldBe(expected.PopulationForYear[0].Year);
        }

        [Fact]
        public static void PopulationInNorwayDatasetCorrectOutputSecondMunicipality()
        {
            var actor = new PopulationInNorwayDatasetType();

            Assert.NotNull(actor.GetField("value"));

            var expected = new LabeledValue()
            {
                Municipality = "Moss",
                PopulationForYear = new Collection<PopulationForYear>()
                {
                    new()
                    {
                        Population = 37,
                        Year = "1987"
                    }
                }
            };

            var actual = (List<LabeledValue>) actor.GetField("value").Resolver.Resolve(new ResolveFieldContext()
            {
                Parent = new ResolveFieldContext()
                {
                    Arguments = new Dictionary<string, ArgumentValue>()
                    {
                        {
                            "municipalities",
                            new ArgumentValue(new List<string>() {"K-3002"}, ArgumentSource.Variable)
                        },
                        {"years", new ArgumentValue(new List<string>() {"1987"}, ArgumentSource.Variable)}
                    }
                },
                Source = new JsonStatDataset<PopulationPerMunicipalityNorway.PopulationInNorwayDimension>()
                {
                    Dimension = new PopulationPerMunicipalityNorway.PopulationInNorwayDimension()
                    {
                        Size = new Collection<int>() {359, 36, 1}
                    },
                    Value = new Collection<int>(Enumerable.Range(0, 360).ToList())
                }
            });

            actual[0].Municipality.ShouldBe(expected.Municipality);
            actual[0].PopulationForYear[0].Population.ShouldBe(expected.PopulationForYear[0].Population);
            actual[0].PopulationForYear[0].Year.ShouldBe(expected.PopulationForYear[0].Year);
        }
    }
}
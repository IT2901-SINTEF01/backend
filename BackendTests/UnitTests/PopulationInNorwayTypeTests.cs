using System.Collections.Generic;
using System.Linq;
using Backend.API.Services;
using Backend.Models.SSBPopulationStatistics.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.UnitTests
{
    public sealed class PopulationInNorwayTypeTests
    {
        private readonly PopulationInNorwayType objectGraph = new(new MetadataServiceMocked());
        
        [Fact]
        public void MunicipalitiesWithKeys()
        {
            var field = objectGraph.GetField("municipalitiesWithKeys");
            field.ShouldNotBeNull();
            
            var result = (IEnumerable<List<string>>) field.Resolver.Resolve(new ResolveFieldContext());
            var list = result.ToList();
            
            list[0][0].ShouldBe("K-3001");
            list[0][1].ShouldBe("Halden");
        }

        [Fact]
        public void Years()
        {
            var field = objectGraph.GetField("years");
            field.ShouldNotBeNull();
            
            var result = (IEnumerable<string>) field.Resolver.Resolve(new ResolveFieldContext());
            var list = result.ToList();
            
            list.ShouldContain("1986");
            list.ShouldContain("2021");
            foreach (var year in Enumerable.Range(1986, 35))
            {
                list.ShouldContain(year.ToString());
            }
        }
    }
}
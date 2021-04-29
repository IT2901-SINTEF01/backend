using System.Collections.Generic;
using System.Linq;
using Backend.API.Services;
using Backend.Models.SSBTaxAssessment.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.TaxAssessment
{
    public class TaxAssessmentTypeTest
    {
        private readonly TaxAssessmentType _objectGraph = new(new MetadataServiceMocked());

        [Fact]
        public void EnsureMunicipalitiesAreResolvedWithKeys()
        {
            var field = _objectGraph.GetField("municipalitiesWithKeys");
            field.ShouldNotBeNull();

            var result = (IEnumerable<List<string>>) field.Resolver.Resolve(new ResolveFieldContext());
            var list = result.ToList();

            list[0][0].ShouldBe("0101");
            list[0][1].ShouldBe("Halden (-2019)");
        }
    }
}
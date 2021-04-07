using System.Linq;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.Metadata
{
    public class VisualisationTypeTest
    {
        private readonly VisualisationType _visualisationType = new();

        private object ResolveField(string fieldName)
        {
            return _visualisationType.GetField(fieldName).Resolver.Resolve(new ResolveFieldContext
            {
                Source = MockMetadata.GenerateStoredMetadata().Generate().Visualisations.First()
            });
        }

        [Fact]
        public void TestType()
        {
            _visualisationType.ShouldBeOfType<VisualisationType>();
        }

        [Fact]
        public void CorrectTypes()
        {
            ResolveField("Type").ShouldBeOneOf("linechart", "thresholdchart");
        }
    }
}
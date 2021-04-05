using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.MetAPI.GraphQLTypes;
using GraphQL;
using GraphQL.Resolvers;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers
{
    public class ObjectGraphTypeWithMetadataTest
    {
        private readonly ForecastType _forecastType = new(new MetadataServiceMocked());

        [Fact]
        public void RetrieveMetadataForObject()
        {
            var resolvedMetadataTask = _forecastType.GetField("metadata").Resolver.ResolveAsync(new ResolveFieldContext());
            
            resolvedMetadataTask.Result.ShouldBeOfType<StoredMetadata>();
            resolvedMetadataTask.Result.ShouldNotBeNull();
        }
    }
}
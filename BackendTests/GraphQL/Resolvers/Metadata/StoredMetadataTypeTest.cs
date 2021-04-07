using System.Collections.ObjectModel;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.Base.Metadata.POCO;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.Metadata
{
    public class StoredMetadataTypeTest
    {
        private readonly StoredMetadataType _storedMetadataType = new();

        private object ResolveField(string fieldName)
        {
            return _storedMetadataType.GetField(fieldName).Resolver.Resolve(new ResolveFieldContext
            {
                Source = MockMetadata.GenerateStoredMetadata().Generate()
            });
        }

        [Fact]
        public void CorrectTypes()
        {
            ResolveField("Id").ShouldBeOfType<string>();
            ResolveField("Name").ShouldBeOfType<string>();
            ResolveField("Description").ShouldBeOfType<string>();
            ResolveField("Tags").ShouldBeOfType<Collection<string>>();
            ResolveField("DatasourceId").ShouldBeOfType<string>();
            ResolveField("Source").ShouldBeOfType<string>();
            ResolveField("Updated").ShouldBeOfType<string>();
            ResolveField("Published").ShouldBeOfType<string>();
            ResolveField("Visualisations").ShouldBeOfType<Collection<Visualisation>>();
        }

        [Fact]
        public void DatasourceIdCorrectValue()
        {
            ResolveField("DatasourceId").ShouldBeOneOf(DatasourceId.SsbPopulation.Value, DatasourceId.MetAPI.Value);
        }

        [Fact]
        public void NonNullableFieldsAreNotNull()
        {
            ResolveField("Tags").ShouldNotBeNull();
            ResolveField("Visualisations").ShouldNotBeNull();
        }
    }
}
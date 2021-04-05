using System.Collections.ObjectModel;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata.POCO;
using Moq;
using Shouldly;
using Xunit;

namespace BackendTests.UnitTests
{
    public class MetadataTest
    {
        private readonly StoredMetadata _storedMetadata = MockMetadata.GenerateStoredMetadata();
        private readonly Collection<StoredMetadata> _storedMetadatas = MockMetadata.GenerateMultipleStoredMetadata();

        [Fact]
        public void MetadataShouldReturnData()
        {
            _storedMetadata.ShouldNotBeNull();
        }

        [Fact]
        public void MetadatasShouldReturnData()
        {
            _storedMetadatas.Count.ShouldBe(10);
        }

        [Fact]
        public void MetadataHasUrl()
        {
            _storedMetadata.Source.ShouldContain("http");
        }

        [Fact]
        public void DatasourceIdIsCorrectType()
        {
            foreach (var storedMetadata in _storedMetadatas)
            {
                storedMetadata.DatasourceId.ShouldBeOneOf(DatasourceId.SsbPopulation.Value, DatasourceId.MetAPI.Value);
            }
        }
    }
}
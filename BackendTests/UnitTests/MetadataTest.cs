using System.Collections.ObjectModel;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata.POCO;
using Xunit;

namespace BackendTests.UnitTests
{
    public class MetadataTest
    {
        private readonly StoredMetadata _storedMetadata;
        private readonly Collection<StoredMetadata> _storedMetadatas;

        public MetadataTest()
        {
            _storedMetadata = MockMetadata.GenerateStoredMetadata();
            _storedMetadatas = MockMetadata.GenerateMultipleStoredMetadata();
        }

        [Fact]
        public void MetadataShouldReturnData()
        {
            Assert.NotNull(_storedMetadata);
        }

        [Fact]
        public void MetadatasShouldReturnData()
        {
            Assert.NotNull(_storedMetadatas);
        }

        [Fact]
        public void MetaDataHasUrl()
        {
            Assert.Contains("http", _storedMetadata.Source);
        }

        [Fact]
        public void MetadatasHasGivenLength()
        {
            Assert.Equal(10, _storedMetadatas.Count);
        }
    }
}

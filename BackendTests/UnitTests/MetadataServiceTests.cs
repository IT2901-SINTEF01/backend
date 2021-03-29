using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Bogus;
using Xunit;

namespace BackendTests.UnitTests
{
    public class MetadataServiceTests
    {
        private readonly MetadataServiceMocked _metadataServiceMocked;

        public MetadataServiceTests()
        {
            _metadataServiceMocked = new MetadataServiceMocked();
        }

        [Fact]
        public void MetadataServiceMockedIsCorrectType()
        {
            Assert.IsType<Task<StoredMetadata>>(_metadataServiceMocked.GetMetadata(DatasourceId.MET_API));
            Assert.IsType<Task<Collection<StoredMetadata>>>(_metadataServiceMocked.GetAllMetadata());
        }

        [Fact]
        public void MetadataServiceMockedIsNotNull()
        {
            Assert.NotNull(_metadataServiceMocked.GetMetadata(DatasourceId.SSB_POPULATION));
            Assert.NotNull(_metadataServiceMocked.GetAllMetadata());
        }
    }
}
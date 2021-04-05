using System.Collections.Generic;
using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Moq;
using Shouldly;
using Xunit;

namespace BackendTests.Services
{
    public class MetadataServiceTests
    {
        private readonly MetadataServiceMocked _metadataServiceMocked;

        public MetadataServiceTests()
        {
            _metadataServiceMocked = new MetadataServiceMocked();
        }

        [Fact]
        public void CorrectTypesAndNotNull()
        {
            _metadataServiceMocked.GetMetadata(It.IsAny<DatasourceId>()).Result.ShouldBeOfType(typeof(StoredMetadata));
            _metadataServiceMocked.GetAllMetadata().Result.ShouldBeAssignableTo(typeof(IEnumerable<StoredMetadata>));
        }

        [Fact]
        public void OneStoredMetadata()
        {
            _metadataServiceMocked.GetMetadata(It.IsAny<DatasourceId>()).Result.ShouldNotBeNull();
        }

        [Fact]
        public void ListOfStoredMetadata()
        {
            // Make sure we get back one or more items
            _metadataServiceMocked.GetAllMetadata().Result.Count.ShouldBePositive();
        }
    }
}
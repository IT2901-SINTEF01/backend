using Backend.Models.Base.Metadata.POCO;
using Xunit;

namespace BackendTests.UnitTests
{
    public class DatasourceIdTest
    {
        private readonly DatasourceId _datasourceId;

        public DatasourceIdTest()
        {
            _datasourceId = new DatasourceId("DUMMY_SOURCE");
        }

        [Fact]
        public void DataSourceIdReturnsCorrectValue()
        {
            Assert.Equal("DUMMY_SOURCE", _datasourceId.Value);
        }

        [Fact]
        public void DatasourceIdHasExistingSources()
        {
            Assert.Equal("SSB_POPULATION", DatasourceId.SSB_POPULATION.Value);
            Assert.Equal("MET_API", DatasourceId.MET_API.Value);
        }
    }
}
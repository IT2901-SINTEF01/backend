using Backend.Models.Base.Metadata.POCO;
using Xunit;

namespace BackendTests.POCO
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
        public static void DatasourceIdHasExistingSources()
        {
            Assert.Equal("SSB_POPULATION", DatasourceId.SsbPopulation.Value);
            Assert.Equal("MET_API", DatasourceId.MetAPI.Value);
            Assert.Equal("SSB_TAX", DatasourceId.SsbTax.Value);
        }
    }
}
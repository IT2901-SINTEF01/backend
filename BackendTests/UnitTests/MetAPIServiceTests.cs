using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Backend.API.Services;
using Moq;
using Xunit;

namespace BackendTests.UnitTests
{
    [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
    public class MetAPIServiceTests
    {
        private readonly float _lat;
        private readonly float _lon;
        private readonly MetAPIService _metAPIService;
        private readonly MetAPIServiceMocked _metAPIServiceMocked;


        public MetAPIServiceTests()
        {
            _metAPIServiceMocked = new MetAPIServiceMocked();
            _lon = 63.42f;
            _lat = 10.38f;
            var httpClient = Mock.Of<HttpClient>();
            _metAPIService = new MetAPIService(httpClient);
        }

        [Fact]
        public void MetAPIServiceMockedIsNotNull()
        {
            Assert.NotNull(_metAPIServiceMocked.GetCompactForecast(_lat, _lon));
        }

        [Fact]
        public void MetAPIServiceMockedIsCorrectType()
        {
            Assert.IsType<MetAPIServiceMocked>(_metAPIServiceMocked);
        }

        [Fact]
        public void MetAPIServiceIsNotNull()
        {
            Assert.NotNull(_metAPIService.GetCompactForecast(_lat, _lon));
        }

        [Fact]
        public void MetAPIServiceIsCorrectType()
        {
            Assert.IsType<MetAPIService>(_metAPIService);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Backend.API.Services;
using Backend.Mocks.MetAPI;
using Backend.Models.MetAPI.POCO;
using Moq;
using Moq.Protected;
using Shouldly;
using Xunit;

namespace BackendTests.Services
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

            // Set up a handler to intercept HTTP requests and return a JSON serialised
            // compact forecast object.
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(Compact.GenerateSampleForecast(_lon, _lat)))
                });

            _metAPIService = new MetAPIService(new HttpClient(handlerMock.Object));
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
        public void CorrectReturnedData()
        {
            _metAPIService.GetCompactForecast(_lat, _lon).Result.ShouldBeOfType<Forecast>();
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
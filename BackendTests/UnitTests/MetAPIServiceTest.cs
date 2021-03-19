using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.API.Services;
using BackendTests.MockHelpers;
using Xunit;

namespace BackendTests.UnitTests
{
    public class MetAPIServiceTest
    {
        private MetAPIService _service;
        private MetAPIServiceMocked _mockedService;
        private HttpClient _httpClient;
        private float lon = 60f;
        private float lat = 10f;
        private const string URL = "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=10&lon=60";

        [Fact]
        public async Task MetAPIServiceShouldReturnData()
        {
            _mockedService = new MetAPIServiceMocked();

            _httpClient = HttpClientMocker.SetupHttpClientMock(URL, await CreateForecastAsString());

            _service = new MetAPIService(_httpClient);

            var result = _service.GetCompactForecast(lat, lon);

            Assert.NotNull(result);
        }

        private async Task<string> CreateForecastAsString()
        {
            var result = await _mockedService.GetCompactForecast(lat, lon).ConfigureAwait(false);
            return JsonSerializer.Serialize(result);
        }
    }
}
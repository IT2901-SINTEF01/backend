using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.API.Services;
using BackendTests.MockHelpers;
using Xunit;

namespace BackendTests.UnitTests
{
    public class PopulationInNorwayServiceTests
    {
        private const string Url = "https://data.ssb.no/api/v0/dataset/26975.json?lang=no";
        private HttpClient _httpClient;
        private PopulationInNorwayServiceMocked _mockedService;
        private PopulationInNorwayService _service;

        [Fact]
        public async Task PopulationInNorwayServiceShouldReturnData()
        {
            _mockedService = new PopulationInNorwayServiceMocked();

            _httpClient =
                HttpClientMocker.SetupHttpClientMock(Url,
                    await CreatePopulationInNorwayAsString().ConfigureAwait(false));

            _service = new PopulationInNorwayService(_httpClient);

            var result = _service.GetPopulationsInNorway();

            Assert.NotNull(result);
        }

        private async Task<string> CreatePopulationInNorwayAsString()
        {
            var result = await _mockedService.GetPopulationsInNorway();
            return JsonSerializer.Serialize(result);
        }
    }
}
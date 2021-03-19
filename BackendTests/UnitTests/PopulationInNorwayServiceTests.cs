using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Backend.API.Services;
using Backend.Models.SSB.POCO;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BackendTests.UnitTests
{
    public class PopulationInNorwayServiceTests
    {
        private PopulationInNorwayService _service;
        private PopulationInNorwayServiceMocked _mockedService;
        private HttpClient _httpClient;
        private readonly string URL = "https://data.ssb.no/api/v0/dataset/26975.json?lang=no";

        [Fact]
        public async Task PopulationInNorwayServiceShouldReturnData()
        {
            _mockedService = new PopulationInNorwayServiceMocked();

            _httpClient = HttpMocker.HttpMocker.SetupHttpClientMock(URL, await CreatePopulationInNorwayAsString());

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
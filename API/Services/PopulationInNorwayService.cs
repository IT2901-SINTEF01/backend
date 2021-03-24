using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Mocks.SSB;
using Backend.Models.SSB.POCO;

namespace Backend.API.Services
{
    public interface IPopulationInNorwayService
    {
        public Task<PopulationPerMunicipalityNorway> GetPopulationsInNorway();
    }

    public class PopulationInNorwayService : IPopulationInNorwayService
    {
        private readonly HttpClient _httpClient;

        public PopulationInNorwayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PopulationPerMunicipalityNorway> GetPopulationsInNorway()
        {
            var response =
                await _httpClient.GetAsync("https://data.ssb.no/api/v0/dataset/26975.json?lang=no");
            return await response.Content.ReadFromJsonAsync<PopulationPerMunicipalityNorway>();
        }
    }

    public class PopulationInNorwayServiceMocked : IPopulationInNorwayService
    {
        public async Task<PopulationPerMunicipalityNorway> GetPopulationsInNorway()
        {
            return await Task.FromResult(MockPopulationInNorway.GenerateSamplePopulationsInNorway()).ConfigureAwait(false);
        }
    }
}
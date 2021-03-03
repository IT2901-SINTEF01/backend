using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Mocks.MetAPI;
using Backend.Models.MetAPI.POCO;

namespace Backend.API.Services
{
    public interface IMetAPIService
    {
        public Task<Forecast> GetCompactForecast(float lat, float lon);
    }

    public class MetAPIService : IMetAPIService
    {
        private readonly HttpClient _httpClient;

        public MetAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Forecast> GetCompactForecast(float lat, float lon)
        {
            var newLat =
                lat.ToString(CultureInfo
                    .InvariantCulture); // Converts input to a float that use . instead of , (gets converted by graphQL somehow.)
            var newLon = lon.ToString(CultureInfo.InvariantCulture);
            var response =
                await _httpClient.GetAsync(
                    $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={newLat}&lon={newLon}");
            return await response.Content.ReadFromJsonAsync<Forecast>();
        }
    }

    public class MetAPIServiceMocked : IMetAPIService
    {
        public async Task<Forecast> GetCompactForecast(float lat, float lon)
        {
            return await Task.FromResult(Compact.GenerateSampleForecast(lon, lat));
        }
    }
}
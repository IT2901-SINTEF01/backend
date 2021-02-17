using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.API.MetAPI;

namespace Backend.API.Services
{
    public interface IDataRetrievalService
    {
        Task<Forecast> GetForecast(float lat, float lon);
    }

    public class DataRetrievalService : IDataRetrievalService
    {
        public DataRetrievalService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "DVT/1.0 (fredrik.malmo@icloud.com)");
        }

        private HttpClient HttpClient { get; }

        public async Task<Forecast> GetForecast(float lat, float lon)
        {
            var newLat =
                lat.ToString(CultureInfo
                    .InvariantCulture); // Converts input to a float that use . instead of , (gets converted by graphQL somehow.
            var newLon = lon.ToString(CultureInfo.InvariantCulture);
            var response =
                await HttpClient.GetAsync(
                    $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={newLat}&lon={newLon}");
            return await response.Content.ReadFromJsonAsync<Forecast>();
        }
    }
}
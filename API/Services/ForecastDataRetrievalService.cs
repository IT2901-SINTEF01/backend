using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.API.MetAPI;

namespace Backend.API.Services
{
    public interface IForecastDataRetrievalService
    {
        //HttpClient HttpClient { get; init; }

        Task<Forecast> GetForecast(float lat, float lon);
        
    }

    public class ForecastDataRetrievalService : IForecastDataRetrievalService
    {
        private HttpClient HttpClient { get; init; }
        public ForecastDataRetrievalService()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0");
        }
        public async Task<Forecast> GetForecast(float lat, float lon)
        {
            // todo: Add support for decimals to be used, also see ForecastQuery.cs
            HttpResponseMessage response = await this.HttpClient.GetAsync($"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lon}");
            return await response.Content.ReadFromJsonAsync<Forecast>();
        }
    }
}
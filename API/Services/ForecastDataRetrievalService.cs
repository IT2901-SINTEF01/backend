using System;
using System.Globalization;
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
        private HttpClient HttpClient { get; }
        public ForecastDataRetrievalService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0");
        }
        public async Task<Forecast> GetForecast(float lat, float lon)
        {
            // todo: Add support for decimals to be used, also see ForecastQuery.cs
            var new_lat = lat.ToString(CultureInfo.InvariantCulture); // Converts input to a float that use . instead of , (gets converted by graphQL somehow.
            var new_lon = lon.ToString(CultureInfo.InvariantCulture);
            HttpResponseMessage response = await HttpClient.GetAsync($"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={new_lat}&lon={new_lon}");
            return await response.Content.ReadFromJsonAsync<Forecast>();
        }
    }
}
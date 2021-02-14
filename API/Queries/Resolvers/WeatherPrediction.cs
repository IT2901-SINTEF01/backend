using System.Threading.Tasks;
using Backend.API.ObjectGraphTypes;

namespace Backend.API.Queries.Resolvers
{
    /// <summary>
    /// Defines the available functions from the rest of the application.
    /// </summary>
    public interface IWeatherPredictionResolver
    {
        public Task<WeatherPrediction> GetValue();
    }
    
    /// <summary>
    /// Defines the actual implementation of the resolver.
    /// </summary>
    public class WeatherPredictionResolver : IWeatherPredictionResolver
    {
        public WeatherPredictionResolver()
        {
        }

        /// <summary>
        /// (A)sync function that will retrieve the relevant data.
        /// </summary>
        /// <returns>The object that will be returned to the client.</returns>
        public async Task<WeatherPrediction> GetValue()
        {
            // Perform network requests here...
            return new WeatherPrediction("Hello from Resolver!", -13);
        }
    
    }
}
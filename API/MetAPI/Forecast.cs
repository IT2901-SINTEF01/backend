using System.Text.Json.Serialization;
using Backend.API.MetAPI.SubClasses;

namespace Backend.API.MetAPI
{
    public class Forecast
    {
        [JsonPropertyName("properties")]
        public Properties ForecastProperties { get; set; }
        
        [JsonPropertyName("geometry")]
        public Geometry ForecastGeometry { get; set; } 
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
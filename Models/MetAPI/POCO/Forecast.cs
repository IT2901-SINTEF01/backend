using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Forecast
    {
        [JsonPropertyName("properties")] public Properties ForecastProperties { get; set; }

        [JsonPropertyName("geometry")] public Geometry ForecastGeometry { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }
    }
}
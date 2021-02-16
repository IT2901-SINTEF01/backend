using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class ForecastData    {
        [JsonPropertyName("instant")]
        public Instant Instant { get; set; } 

        [JsonPropertyName("next_1_hours")]
        public Next1Hours Next1Hours { get; set; } 

        [JsonPropertyName("next_12_hours")]
        public Next12Hours Next12Hours { get; set; } 

        [JsonPropertyName("next_6_hours")]
        public Next6Hours Next6Hours { get; set; } 
    }
}
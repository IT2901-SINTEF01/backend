using System;
using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Timeseries
    {
        [JsonPropertyName("data")] public ForecastData ForecastData { get; set; }

        [JsonPropertyName("time")] public DateTime Time { get; set; }
    }
}
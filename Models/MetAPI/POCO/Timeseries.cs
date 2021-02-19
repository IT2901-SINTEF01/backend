using System;
using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Timeseries
    {
        [JsonPropertyName("data")] public ForecastData ForecastData { get; set; }

        [JsonPropertyName("time")] public DateTime Time { get; set; }
    }
}
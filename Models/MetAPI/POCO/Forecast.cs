﻿using System.Text.Json.Serialization;
using Backend.Models.Base.Metadata.POCO;

namespace Backend.Models.MetAPI.POCO
{
    public class Forecast
    {
        [JsonPropertyName("properties")] public Properties ForecastProperties { get; set; }

        [JsonPropertyName("geometry")] public Geometry ForecastGeometry { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("metadata")] public StoredMetadata StoredMetadata { get; set; }
    }
}
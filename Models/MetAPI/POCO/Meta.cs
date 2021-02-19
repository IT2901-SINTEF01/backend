using System;
using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Meta
    {
        [JsonPropertyName("units")] public Units Units { get; set; }

        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}
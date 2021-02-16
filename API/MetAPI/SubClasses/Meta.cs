using System;
using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Meta    {
        [JsonPropertyName("units")]
        public Units Units { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; } 
    }
}
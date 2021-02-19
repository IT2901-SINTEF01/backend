using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Instant
    {
        [JsonPropertyName("details")] public Details Details { get; set; }
    }
}
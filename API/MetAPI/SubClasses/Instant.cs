using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Instant
    {
        [JsonPropertyName("details")] public Details Details { get; set; }
    }
}
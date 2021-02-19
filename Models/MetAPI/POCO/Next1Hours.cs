using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Next1Hours
    {
        [JsonPropertyName("details")] public Details Details { get; set; }

        [JsonPropertyName("summary")] public Summary Summary { get; set; }
    }
}
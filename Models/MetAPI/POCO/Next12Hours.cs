using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Next12Hours
    {
        [JsonPropertyName("summary")] public Summary Summary { get; set; }

        [JsonPropertyName("details")] public Details Details { get; set; }
    }
}
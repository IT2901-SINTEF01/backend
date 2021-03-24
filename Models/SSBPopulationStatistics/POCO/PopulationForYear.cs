using System.Text.Json.Serialization;

namespace Backend.Models.SSBPopulationStatistics.POCO
{
    public class PopulationForYear
    {
        [JsonPropertyName("year")] public string Year;

        [JsonPropertyName("population")] public int Population;
    }
}
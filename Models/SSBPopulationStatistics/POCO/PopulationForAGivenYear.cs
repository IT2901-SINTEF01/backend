using System.Text.Json.Serialization;

namespace Backend.Models.SSBPopulationStatistics.POCO
{
    public class PopulationForAGivenYear
    {
        [JsonPropertyName("year")] public string Year { get; init; }

        [JsonPropertyName("population")] public int Population { get; init; }
    }
}
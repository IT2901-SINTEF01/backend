using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.SSBPopulationStatistics.POCO
{
    public class LabeledValue
    {
        [JsonPropertyName("municipality")] public string Municipality { get; init; }

        /// Format: [ [ year, population ] ]
        [JsonPropertyName("populationForYear")]
        public Collection<PopulationForAGivenYear> PopulationForYear { get; init; }
    }
}
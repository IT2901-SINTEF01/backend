using System.Text.Json.Serialization;
using Backend.Models.Base.JsonStat;

namespace Backend.Models.SSB.POCO
{
    public class PopulationPerMunicipalityNorway
    {
        [JsonPropertyName("dataset")] public JsonStatDataset<PopulationInNorwayDimension> Dataset { get; set; }

        public sealed class PopulationInNorwayDimension : AbstractJsonStatDimension
        {
            [JsonPropertyName("Region")] public JsonStatDimensionContent Region { get; set; }
            [JsonPropertyName("Tid")] public JsonStatDimensionContent Tid { get; set; }
        }
    }
}
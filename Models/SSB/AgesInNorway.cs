using System.Text.Json.Serialization;
using Backend.Models.Base.JsonStat;

namespace Backend.Models.SSB
{
    public class AgesInNorway
    {
        [JsonPropertyName("dataset")] public JsonStatDataset<AgesInNorwayDimension> Dataset { get; set; }

        public sealed class AgesInNorwayDimension : AbstractJsonStatDimension
        {
            [JsonPropertyName("Region")] public JsonStatDimensionContent Region { get; set; }
            [JsonPropertyName("Tid")] public JsonStatDimensionContent Tid { get; set; }
        }
    }
}

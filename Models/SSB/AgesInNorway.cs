using System.Text.Json.Serialization;
using Backend.Models.JsonStat;

namespace Backend.Models.SSB
{
    // Remove comments when merge-ready
    // Based on https://data.ssb.no/api/v0/dataset/26975.json?lang=no
    // https://data.ssb.no/api/v0/dataset/26975?lang=no
    public class AgesInNorway
    {
        /*
         * I tried abstracting this class as much as possible, so that the only thing
         * that has to be changed when creating a new JSON-stat object, only the dimension
         * needs to be changed.
         */
        [JsonPropertyName("dataset")] public JsonStatDataset Dataset { get; set; }

        public sealed class JsonStatDataset : AbstractJsonStatDataSet
        {
            [JsonPropertyName("dimension")] public JsonStatSpecificDimension Dimension { get; set; }
        }

        public sealed class JsonStatSpecificDimension : AbstractJsonStatDimension
        {
            [JsonPropertyName("Region")] public JsonStatDimensionContent Region { get; set; }
            [JsonPropertyName("Tid")] public JsonStatDimensionContent Tid { get; set; }
        }
    }
}
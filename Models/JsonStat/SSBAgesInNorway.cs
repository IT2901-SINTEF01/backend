using System.Text.Json.Serialization;

namespace Backend.Models.JsonStat
{
    // Remove comments when merge-ready
    // Based on https://data.ssb.no/api/v0/dataset/1074.json?lang=no
    public class SSBAgesInNorway
    {
        /*
         * I tried abstracting this class as much as possible, so that the only thing
         * that has to be changed when creating a new JSON-stat object, only the dimension
         * needs to be changed.
         */
        [JsonPropertyName("dataset")] public JsonStatDataset Dataset { get; set; }

        public class JsonStatDataset : JsonStatGenericDataset
        {
            [JsonPropertyName("dimension")] public JsonStatSpecificDimension Dimension { get; set; }
        }

        public class JsonStatSpecificDimension : JsonStatGenericDimension
        {
            /*
             * Changes are done here, the rest _should_ be equivalent for other json-stat objects
             */
            [JsonPropertyName("Region")] public JsonStatDimensionContent Region { get; set; }
            [JsonPropertyName("Alder")] public JsonStatDimensionContent Alder { get; set; }
            [JsonPropertyName("Tid")] public JsonStatDimensionContent Tid { get; set; }
        }
    }
}
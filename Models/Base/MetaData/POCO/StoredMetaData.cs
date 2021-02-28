using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class StoredMetaData
    {
        [JsonPropertyName("_id")] public Id Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("tags")] public List<string> Tags { get; set; }

        [JsonPropertyName("source")] public string Source { get; set; }

        [JsonPropertyName("updated")] public string Updated { get; set; }

        [JsonPropertyName("published")] public string Published { get; set; }

        [JsonPropertyName("visualisations")] public List<Visualisation> Visualisations { get; set; }
    }
}
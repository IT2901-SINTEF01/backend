using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Y
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("limit")] public List<Limit> Limit { get; set; }
    }
}
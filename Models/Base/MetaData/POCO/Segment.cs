using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Segment
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("value")] public List<Value> Value { get; set; }
    }
}
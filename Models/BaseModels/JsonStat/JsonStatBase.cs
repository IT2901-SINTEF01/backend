using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Backend.Models.SSB;

namespace Backend.Models.JsonStat
{
    public abstract class AbstractJsonStatDataSet
    {
        [JsonPropertyName("label")] public string Label { get; set; }
        [JsonPropertyName("source")] public string Source { get; set; }
        [JsonPropertyName("updated")] public DateTime Updated { get; set; }
        [JsonPropertyName("value")] public Collection<int> Value { get; set; }
    }

    public abstract class AbstractJsonStatDimension
    {
        [JsonPropertyName("id")] public Collection<string> Id { get; set; }
        [JsonPropertyName("size")] public Collection<int> Size { get; set; }
        [JsonPropertyName("role")] public Dictionary<string, Collection<string>> Role { get; set; }
    }

    public class JsonStatDimensionContent
    {
        [JsonPropertyName("label")] public string Label { get; set; }
        [JsonPropertyName("category")] public JsonStatDimensionCategory Category { get; set; }
    }

    public class JsonStatDimensionCategory
    {
        [JsonPropertyName("index")] public Dictionary<string, int> Index { get; set; }
        [JsonPropertyName("label")] public Dictionary<string, string> Label { get; set; }
    }
    
        public sealed class JsonStatDataset<T> : AbstractJsonStatDataSet where T : AbstractJsonStatDimension
        {
            [JsonPropertyName("dimension")] public T Dimension { get; set; }
        }
}
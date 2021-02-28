using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Visualisation
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("axes")] public Axes Axes { get; set; }

        [JsonPropertyName("segments")] public List<Segment> Segments { get; set; }

        [JsonPropertyName("threshold")] public Threshold Threshold { get; set; }
    }
}
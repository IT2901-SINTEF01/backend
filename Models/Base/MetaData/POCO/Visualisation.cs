using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Visualisation
    {
        public Visualisation(Collection<Segment> segments)
        {
            Segments = segments;
        }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("axes")] public Axes Axes { get; set; }

        [JsonPropertyName("segments")] public Collection<Segment> Segments { get; }

        [JsonPropertyName("threshold")] public Threshold Threshold { get; set; }
    }
}
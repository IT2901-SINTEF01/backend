using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.Metadata.POCO
{
    public class Visualisation
    {
        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [BsonElement("axes")]
        [JsonPropertyName("axes")]
        public Axes Axes { get; set; }

        [BsonElement("segments")]
        [JsonPropertyName("segments")]
        public Collection<Segment> Segments { get; set; }

        [BsonElement("threshold")]
        [JsonPropertyName("threshold")]
        public int Threshold { get; set; }
    }
}
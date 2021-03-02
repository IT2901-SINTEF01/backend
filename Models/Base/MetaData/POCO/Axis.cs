using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.Metadata.POCO
{
    public class Axis
    {
        public Axis(Collection<Limit> limit)
        {
            Limit = limit;
        }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [BsonElement("limit")]
        [JsonPropertyName("limit")]
        public Collection<Limit> Limit { get; }
    }
}
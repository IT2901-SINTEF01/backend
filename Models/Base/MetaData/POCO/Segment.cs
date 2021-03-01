using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Segment
    {
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("value")]
        [JsonPropertyName("value")]
        public Collection<int> Value { get; set; }
    }
}
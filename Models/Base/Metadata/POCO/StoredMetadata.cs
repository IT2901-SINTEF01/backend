using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.Metadata.POCO
{
    public class StoredMetadata
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [BsonElement("tags")]
        [JsonPropertyName("tags")]
        public Collection<string> Tags { get; set; }

        [BsonElement("source")]
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [BsonElement("updated")]
        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [BsonElement("published")]
        [JsonPropertyName("published")]
        public string Published { get; set; }

        [BsonElement("visualisations")]
        [JsonPropertyName("visualisations")]
        public Collection<Visualisation> Visualisations { get; set; }
    }
}
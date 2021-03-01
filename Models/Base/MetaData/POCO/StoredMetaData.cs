using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.MetaData.POCO
{
    public class StoredMetaData
    {
        public StoredMetaData(Collection<string> tags, string updated, Collection<Visualisation> visualisations)
        {
            Tags = tags;
            Updated = updated;
            Visualisations = visualisations;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")] public string Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("tags")] public Collection<string> Tags { get; }

        [JsonPropertyName("source")] public string Source { get; set; }

        [JsonPropertyName("updated")] public string Updated { get; }

        [JsonPropertyName("published")] public string Published { get; set; }

        [JsonPropertyName("visualisations")] public Collection<Visualisation> Visualisations { get; }
    }
}
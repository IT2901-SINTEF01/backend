using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.Metadata.POCO
{
    public class Threshold
    {
        [BsonElement("$numberInt")]
        [JsonPropertyName("$numberInt")]
        public string NumberInt { get; set; }
    }
}
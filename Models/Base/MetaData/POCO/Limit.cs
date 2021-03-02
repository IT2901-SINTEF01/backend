using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.Metadata.POCO
{
    public class Limit
    {
        [BsonElement("$numberInt")]
        [JsonPropertyName("$numberInt")]
        public string NumberInt { get; set; }
    }
}
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Value
    {
        [BsonElement("$numberInt")]
        [JsonPropertyName("$numberInt")]
        public int NumberInt { get; set; }
    }
}
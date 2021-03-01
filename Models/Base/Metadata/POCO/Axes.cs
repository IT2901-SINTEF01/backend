using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Axes
    {
        [BsonElement("x")]
        [JsonPropertyName("x")]
        public Axis X { get; set; }

        [BsonElement("y")]
        [JsonPropertyName("y")]
        public Axis Y { get; set; }
    }
}
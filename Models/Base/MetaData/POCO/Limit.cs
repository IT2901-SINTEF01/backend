using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Limit
    {
        [JsonPropertyName("$numberInt")] public string NumberInt { get; set; }
    }
}
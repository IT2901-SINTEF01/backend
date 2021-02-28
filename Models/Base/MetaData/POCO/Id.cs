using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Id
    {
        [JsonPropertyName("$oid")] public string Oid { get; set; }
    }
}
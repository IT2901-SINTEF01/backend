using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Axes
    {
        [JsonPropertyName("x")] public X X { get; set; }

        [JsonPropertyName("y")] public Y Y { get; set; }
    }
}
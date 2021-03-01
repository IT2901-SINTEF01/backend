using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Axes
    {
        [JsonPropertyName("x")] public Axis X { get; set; }

        [JsonPropertyName("y")] public Axis Y { get; set; }
    }
}
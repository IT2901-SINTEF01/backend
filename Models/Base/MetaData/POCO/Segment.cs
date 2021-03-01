using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Segment
    {
        public Segment(Collection<Value> value)
        {
            Value = value;
        }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("value")] public Collection<Value> Value { get; }
    }
}
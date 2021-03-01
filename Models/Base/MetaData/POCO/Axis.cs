using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.Base.MetaData.POCO
{
    public class Axis
    {
        public Axis(Collection<Limit> limit)
        {
            Limit = limit;
        }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("limit")] public Collection<Limit> Limit { get; }
    }
}
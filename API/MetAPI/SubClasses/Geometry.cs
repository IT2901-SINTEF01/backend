using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Geometry
    {
        public Geometry(Collection<float> coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonPropertyName("coordinates")] public Collection<float> Coordinates { get; }

        [JsonPropertyName("type")] public string Type { get; set; }
    }
}
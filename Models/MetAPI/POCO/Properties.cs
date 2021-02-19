using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Properties
    {
        public Properties()
        {
        }

        public Properties(Collection<Timeseries> timeseries)
        {
            Timeseries = timeseries;
        }

        [JsonPropertyName("meta")] public Meta Meta { get; set; }

        [JsonPropertyName("timeseries")] public Collection<Timeseries> Timeseries { get; set; }
    }
}
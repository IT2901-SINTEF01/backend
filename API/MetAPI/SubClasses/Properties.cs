using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Properties    {
        public Properties(Collection<Timeseries> timeseries)
        {
            Timeseries = timeseries;
        }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } 

        [JsonPropertyName("timeseries")]
        public  Collection<Timeseries> Timeseries { get; }
        
    }
}
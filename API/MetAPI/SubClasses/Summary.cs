using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Summary    {
        [JsonPropertyName("symbol_code")]
        public string SymbolCode { get; set; } 
    }
}
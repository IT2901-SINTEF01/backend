using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Summary
    {
        [JsonPropertyName("symbol_code")] public string SymbolCode { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Backend.Models.SSBTaxAssessment.POCO
{
    public class TaxesForAGivenYear
    {
        [JsonPropertyName("year")] public string Year { get; init; }

        [JsonPropertyName("taxes")] public int Taxes { get; init; }
    }
}
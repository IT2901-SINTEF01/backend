using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.SSBTaxAssessment.POCO
{
    public class LabeledValueTax
    {
        [JsonPropertyName("municipality")] public string Municipality { get; init; }

        /// Format: [ [ year, taxes ] ]
        [JsonPropertyName("taxesForYear")]
        public Collection<TaxesForAGivenYear> TaxesForYear { get; init; }
    }
}
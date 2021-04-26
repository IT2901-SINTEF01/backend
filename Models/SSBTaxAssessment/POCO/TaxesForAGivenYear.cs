using System.Text.Json.Serialization;

namespace Backend.Models.SSBTaxAssessment.POCO
{
    public class TaxesForAGivenYear
    {
        /// <summary>
        ///     Class names are derived from SSB's own codes in their documentation.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; init; }

        [JsonPropertyName("Brutto")] public int Brutto { get; set; }

        [JsonPropertyName("LonnInnt")] public int LonnInnt { get; set; }

        [JsonPropertyName("Uskstt")] public int Uskstt { get; set; }

        [JsonPropertyName("AllmennInnt")] public int AllmennInnt { get; set; }

        [JsonPropertyName("BankInn")] public int BankInn { get; set; }

        [JsonPropertyName("BrFormue")] public int BrFormue { get; set; }

        [JsonPropertyName("Gjeld")] public int Gjeld { get; set; }

        [JsonPropertyName("MedianBtoInnt")] public int MedianBtoInnt { get; set; }

        [JsonPropertyName("MedianLonnInnt")] public int MedianLonnInnt { get; set; }

        [JsonPropertyName("MedianUtlignSkatt")]
        public int MedianUtlignSkatt { get; set; }

        [JsonPropertyName("MedianAlmInnt")] public int MedianAlmInnt { get; set; }

        [JsonPropertyName("MedianBankInns")] public int MedianBankInns { get; set; }

        [JsonPropertyName("MedianBtoFormue")] public int MedianBtoFormue { get; set; }

        [JsonPropertyName("MedianGjeld")] public int MedianGjeld { get; set; }
    }
}
using System.Text.Json.Serialization;
using Backend.Models.Base.JsonStat;

namespace Backend.Models.SSBTaxAssessment.POCO
{
    public class TaxAssessment
    {
        [JsonPropertyName("dataset")] public JsonStatDataset<TaxAssessmentDimension> Dataset { get; set; }

        public sealed class TaxAssessmentDimension : AbstractJsonStatDimension
        {
            [JsonPropertyName("Region")] public JsonStatDimensionContent Region { get; set; }

            [JsonPropertyName("Tid")] public JsonStatDimensionContent Tid { get; set; }
        }
    }
}
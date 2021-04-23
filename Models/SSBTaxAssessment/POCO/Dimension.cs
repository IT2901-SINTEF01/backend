using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.SSBTaxAssessment.POCO
{
    public class Dimension
    {
        [JsonPropertyName("Region")]
        public Region Region { get; set; }

        [JsonPropertyName("Alder")]
        public Alder Alder { get; set; }

        [JsonPropertyName("Tid")]
        public Tid Tid { get; set; }

        [JsonPropertyName("ContentsCode")]
        public ContentsCode ContentsCode { get; set; }
    }
    public class Region
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("link")]
        public Link Link { get; set; }
    }
    public class Alder
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
    public class Tid
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
    public class ContentsCode
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("link")]
        public Link Link { get; set; }
    }
    
    public class Role
    {
        [JsonPropertyName("time")]
        public Collection<string> Time { get; set; }

        [JsonPropertyName("metric")]
        public Collection<string> Metric { get; set; }
    }
    public class Category
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
    public class Link
    {
        [JsonPropertyName("describedby")]
        public Collection<Describedby> Describedby { get; set; }
    }
    public class Describedby
    {
        [JsonPropertyName("extension")]
        public Extension Extension { get; set; }
    }
    public class Extension
    {
        [JsonPropertyName("Region")]
        public string Region { get; set; }

        [JsonPropertyName("Brutto")]
        public string Brutto { get; set; }

        [JsonPropertyName("LonnInnt")]
        public string LonnInnt { get; set; }

        [JsonPropertyName("Uskstt")]
        public string Uskstt { get; set; }

        [JsonPropertyName("AllmennInnt")]
        public string AllmennInnt { get; set; }

        [JsonPropertyName("BankInn")]
        public string BankInn { get; set; }

        [JsonPropertyName("BrFormue")]
        public string BrFormue { get; set; }

        [JsonPropertyName("Gjeld")]
        public string Gjeld { get; set; }

        [JsonPropertyName("MedianBtoInnt")]
        public string MedianBtoInnt { get; set; }

        [JsonPropertyName("MedianLonnInnt")]
        public string MedianLonnInnt { get; set; }

        [JsonPropertyName("MedianUtlignSkatt")]
        public string MedianUtlignSkatt { get; set; }

        [JsonPropertyName("MedianAlmInnt")]
        public string MedianAlmInnt { get; set; }

        [JsonPropertyName("MedianBankInns")]
        public string MedianBankInns { get; set; }

        [JsonPropertyName("MedianBtoFormue")]
        public string MedianBtoFormue { get; set; }

        [JsonPropertyName("MedianGjeld")]
        public string MedianGjeld { get; set; }
    }
}
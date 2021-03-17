namespace Backend.Models.Base.Metadata
{
    public class MetadataDatabaseSettings : IMetadataDatabaseSettings
    {
        public string MetadataCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMetadataDatabaseSettings
    {
        string MetadataCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}
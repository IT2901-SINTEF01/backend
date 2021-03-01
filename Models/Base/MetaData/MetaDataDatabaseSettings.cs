namespace Backend.Models.Base.MetaData
{
    public class MetaDataDatabaseSettings : IMetaDataDatabaseSettings
    {
        public string MetaDataCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMetaDataDatabaseSettings
    {
        string MetaDataCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
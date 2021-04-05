namespace Backend.Models.Base.Metadata.POCO
{
    public class DatasourceId
    {
        public DatasourceId(string value)
        {
            Value = value;
        }

        public string Value { get; }

        // Add the value of the datasource_id field in the Metadata-database
        public static DatasourceId SsbPopulation => new("SSB_POPULATION");

        public static DatasourceId MetAPI => new("MET_API");
    }
}
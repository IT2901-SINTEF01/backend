using Backend.API.Services;
using Backend.Models.Base.Metadata.POCO;
using Backend.Models.MetAPI.POCO;
using Backend.utils.GraphQLTypes;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class ForecastType : ObjectGraphTypeWithMetadata<Forecast>
    {
        public ForecastType(IMetadataService metadataService) : base(metadataService, DatasourceId.MET_API)
        {
            Field(forecast => forecast.ForecastGeometry, false, typeof(GeometryType))
                .Description("The Geo-Data used in the query");
            Field(forecast => forecast.ForecastProperties, false, typeof(PropertiesType))
                .Description("Data and meta-data returned");
            Field(forecast => forecast.Type);
        }
    }
}
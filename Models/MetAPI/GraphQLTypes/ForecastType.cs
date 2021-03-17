using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.MetAPI.POCO;
using Backend.utils.GraphQLTypes;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class ForecastType : ObjectGraphTypeWithMetadata<Forecast>
    {
        public ForecastType(IMetadataService metadataService) : base(metadataService, "MetAPI Forecast")
        {
            Field(forecast => forecast.ForecastGeometry, false, typeof(GeometryType))
                .Description("The Geo-Data used in the query");
            Field(forecast => forecast.ForecastProperties, false, typeof(PropertiesType))
                .Description("Data and meta-data returned");
            Field(forecast => forecast.Type);
        }
    }
}
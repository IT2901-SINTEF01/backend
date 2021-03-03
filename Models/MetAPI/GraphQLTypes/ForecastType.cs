using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class ForecastType : ObjectGraphType<Forecast>
    {
        public ForecastType(IMetadataService metadataService)
        {
            Field(forecast => forecast.ForecastGeometry, false, typeof(GeometryType))
                .Description("The Geo-Data used in the query");
            Field(forecast => forecast.ForecastProperties, false, typeof(PropertiesType))
                .Description("Data and meta-data returned");
            Field(forecast => forecast.Type);
            Field<StoredMetadataType>().ResolveAsync(context => metadataService.GetMetadata("MetAPI Forecast"))
                .Name("metadata").Description("Metadata for the forecast data source");
        }

        /*
         * The expression continues to resolve the type until the object is completely nested
         */
    }
}
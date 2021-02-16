using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public sealed class ForecastType: ObjectGraphType<Forecast>
    {
        public ForecastType()
        { 
            Field(forecast => forecast.ForecastGeometry, false, typeof(GeometryType)).Description("The Geo-Data used in the query");
            Field(forecast => forecast.ForecastProperties, false, typeof(PropertiesType)).Description("Data and meta-data returned");
            Field(forecast => forecast.Type);
        }
        /*
         * The expression continues to resolve the type until the object is completely nested
         */
    }
}
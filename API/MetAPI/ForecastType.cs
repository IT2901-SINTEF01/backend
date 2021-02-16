using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public sealed class ForecastType: ObjectGraphType<Forecast>
    {
        public ForecastType()
        { 
            Field(forecast => forecast.geometry, false, typeof(GeometryType));
            Field(forecast => forecast.properties, false, typeof(PropertiesType));
            Field(forecast => forecast.Type);
        }
        /*
         * The expression continues to resolve the type until the object is completely nested
         */
    }
}
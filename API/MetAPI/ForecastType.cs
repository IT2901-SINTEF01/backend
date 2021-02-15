using Backend.API.Data;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public sealed class ForecastType: ObjectGraphType<Forecast>
    {
        public ForecastType()
        { 
            Field(forecast => forecast.geometry, false, typeof(GeometryType));
            Field(forecast => forecast.properties, false, typeof(PropertiesType));
            Field(forecast => forecast.type);
        }
        
    }
}
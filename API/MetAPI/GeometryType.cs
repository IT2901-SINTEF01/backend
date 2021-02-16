using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class GeometryType : ObjectGraphType<Forecast.Geometry>
    {
        public GeometryType()
        {
            Field(geometry => geometry.Coordinates, false, typeof(ListGraphType<FloatGraphType>));
            Field(geometry => geometry.Type);
        }
    }
}